using LCardLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DKMObserver
{
    public partial class ObservePanel : Form
    {
        private class Organ
        {
            public int? code { get; set; }

            public string name { get; set; }
        }

        private dbIcmEntities db;
        public Guid patientId { get; set; }

        public int historyItem { get; set; }

        public ObservePanel()
        {
            db = new dbIcmEntities();
            InitializeComponent();
        }

        ~ObservePanel()
        {
            db.Dispose();
        }

        private void ObservePanel_Load(object sender, EventArgs e)
        {
            this.listOrgansTableAdapter.Fill(this.dbIcmDataSet.listOrgans);
            this.listObservPlansTableAdapter.Fill(this.dbIcmDataSet.listObservPlans);
            

            if (this.HasCard(new L761Card()))
            {
                cbCards.Items.Add(new L761Card());
            } 
            
            if (this.HasCard(new E154Card())) {
                cbCards.Items.Add(new E154Card());
            }

            if (cbCards.Items.Count == 0)
            {
                cbCards.Items.Add(new { CardName = "--- Карты не найдены ---" });
            }

            cbCards.DisplayMember = "CardName";
            this.cbCards.SelectedIndexChanged += new System.EventHandler(this.cbCards_SelectedIndexChanged);
            cbCards.SelectedIndex = 0;
        }

        private bool HasCard(ADCCard card)
        {
            var result = card.InitCard(160);
            card.StopCard();
            return result;
        }

        private void cbObservPlans_SelectedValueChanged(object sender, EventArgs e)
        {
            var cb = sender as ComboBox;
            if ((cb != null) && (cb.SelectedItem != null))
            {
                Console.WriteLine(e);
                this.makeObservePlanTree((cb.SelectedItem as DataRowView).Row as dbIcmDataSet.listObservPlansRow);
            }
        }

        private void makeObservePlanTree(dbIcmDataSet.listObservPlansRow row)
        {
            this.SuspendLayout();
            trPlanDetail.Nodes.Clear();

            //row.PlanCode;
            //using

            this.listObservPlanDetailsTableAdapter.Fill(this.dbIcmDataSet.listObservPlanDetails);
            this.listOrgansTableAdapter.Fill(this.dbIcmDataSet.listOrgans);

            var roots = this.db.listObservPlanDetails.Where(x => (x.PlanCode == row.PlanCode) && (x.Parent == null)).OrderBy(x => x.Name);

            foreach (var root in roots)
            {
                var nodeRoot = trPlanDetail.Nodes.Add(root.Name);
                nodeRoot.Tag = new Organ() { code = null, name = root.Name };
                makeNodes(nodeRoot, root.Item, root.OrganCode);
            }

            if (trPlanDetail.Nodes.Count > 0)
            {
                trPlanDetail.Nodes[0].Expand();
            }
            

            this.ResumeLayout();
        }

        private void makeNodes(TreeNode parentNode, int id, int? code)
        {
            var items = this.db.listObservPlanDetails.Where(x => (x.Parent == id)).OrderBy(x => x.Name).ToList();
            if (items.Count > 0)
            {
                foreach (var item in items)
                {
                    var node = parentNode.Nodes.Add(item.Name);
                    node.Tag = Tag = new Organ() { code = item.OrganCode, name = item.Name };
                    makeNodes(node, item.Item, item.OrganCode);
                }
            }
            else
            {
                if (code.HasValue)
                {
                    makeOrgans(parentNode, code.Value);
                }
            }
        }

        private void makeOrgans(TreeNode parentNode, int id)
        {
            var items = this.db.listOrgans.Where(x => (x.Parent == id)).OrderBy(x => x.OrganName).ToList();
            foreach (var item in items)
            {
                var node = parentNode.Nodes.Add(item.OrganName);
                node.Tag = Tag = new Organ() { code = item.OrganCode, name = item.OrganName };
                makeOrgans(node, item.OrganCode);
            }
        }

        private void checkButtonsEnabled()
        {
            var pd = (trPlanDetail.SelectedNode) != null ? trPlanDetail.SelectedNode.Tag as Organ : null;
            btnStart.Enabled = (pd != null) && (pd.code != null) && (cbCards.SelectedItem != null) && (cbCards.SelectedItem is ADCCard);
        }

        private void trPlanDetail_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.checkButtonsEnabled();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            var result = true;
            btnStart.Enabled = false;

            chart1.Series[0].Points.Clear();
            chart1.Visible = true;

            var wf = new WaitForm((int)nPause.Value);

            if (wf.ShowDialog() == DialogResult.OK)
            {
                var card = cbCards.SelectedItem as ADCCard;
                
                var reader = new DataReader(card, (int)nFreq.Value, (int)nDiagLen.Value);

                var progress = new Progress<int>(s => chart1.Series[0].Points.AddY(s));

                result = await Task.Run(() => reader.DoReadSample(progress));

                Console.WriteLine(reader.buffer.Count);

                var pd = trPlanDetail.SelectedNode.Tag as Organ;

                var data = Compressor.CompressArray(reader.buffer.ToArray());
                //var data = Compressor.ShortToByte(reader.buffer.ToArray());

                var dl = new List<byte>();

                dl.AddRange(Encoding.GetEncoding(1251).GetBytes("<?xml version=\"1.0\" encoding=\"windows-1251\"?>\r\n"));
                dl.AddRange(Encoding.GetEncoding(1251).GetBytes("<DKMData>\r\n\t<Samples Comment=\"\" DeviceName=\"\" AquireTime=\""));
                dl.AddRange(Encoding.GetEncoding(1251).GetBytes(DateTime.Now.ToString("yyyy-MM-dd|HH-mm-ss")));
                dl.AddRange(Encoding.GetEncoding(1251).GetBytes("\">\r\n\t\t<Sample BegTime=\"0\" Comment=\"\" Frequency=\"160\">"));
                dl.AddRange(data);
                dl.AddRange(Encoding.GetEncoding(1251).GetBytes("\r\n\t\t</Sample>\r\n\t</Samples>\r\n\t<TimeMarks/>\r\n</DKMData>"));

                var lastItem = 0;
                if (db.hstObservationDetails.Where(x => x.PatientID == this.patientId && x.HistoryItem == this.historyItem).Count() > 0)
                {
                    lastItem = db.hstObservationDetails
                        .Where(x => x.PatientID == this.patientId && x.HistoryItem == this.historyItem)
                        .Max(x => x.Item);
                }
                
                var detail = new hstObservationDetails();
                detail.PatientID = this.patientId;
                detail.HistoryItem = this.historyItem;
                detail.Item = lastItem + 1;
                detail.SortOrder = 10000000;
                detail.ObservDataTypeCode = 1;
                detail.PointName = pd.name;
                detail.OrganCode = pd.code;
                detail.Report = true;
                detail.DataType = "DKMData";
                detail.Notes = "";
                detail.RecStatus = "edt";
                detail.WhenCreated = DateTime.Now;
                detail.WhenEdited = DateTime.Now;
                detail.CreatorID = new Guid("10000000-0000-0000-0000-000000000000");
                detail.EditorID = new Guid("10000000-0000-0000-0000-000000000000");
                detail.WorkstationName = "local";

                db.hstObservationDetails.Add(detail);

                var detailData = new hstObservationDetailData();
                detailData.PatientID = this.patientId;
                detailData.HistoryItem = this.historyItem;
                detailData.Item = lastItem + 1;
                detailData.ChunkNum = 0;
                detailData.Data = dl.ToArray();
                detailData.RecStatus = "add";
                detailData.WhenCreated = DateTime.Now;
                detailData.CreatorID = new Guid("10000000-0000-0000-0000-000000000000");
                detailData.WorkstationName = "local";

                db.hstObservationDetailData.Add(detailData);

                db.SaveChanges();
            }


            chart1.Visible = false;
            btnStart.Enabled = result;
        }

        private void cbCards_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.checkButtonsEnabled();
        }

        private void btnStart_EnabledChanged(object sender, EventArgs e)
        {
            btnStart.BackColor = btnStart.Enabled ? Color.FromArgb(0, 192, 0) : SystemColors.Control;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
