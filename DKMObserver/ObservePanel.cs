using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DKMObserver
{
    public partial class ObservePanel : Form
    {
        private dbIcmEntities db;

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
            this.listObservPlansTableAdapter.Fill(this.dbIcmDataSet.listObservPlans);

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

            var roots = this.db.listObservPlanDetails.Where(x => (x.PlanCode == row.PlanCode) && (x.Parent == null)).OrderBy(x => x.Name);

            foreach (var root in roots)
            {
                var nodeRoot = trPlanDetail.Nodes.Add(root.Item.ToString(), root.Name);
                nodeRoot.Tag = root;
                makeNodes(nodeRoot, root.Item);
            }

            this.ResumeLayout();
        }

        private void makeNodes(TreeNode parentNode, int id)
        {
            var items = this.db.listObservPlanDetails.Where(x => (x.Parent == id)).OrderBy(x => x.Name);
            foreach (var item in items)
            {
                var node = parentNode.Nodes.Add(item.Item.ToString(), item.Name);
                node.Tag = item;
                makeNodes(node, item.Item);
            }
        }

        private void trPlanDetail_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var pd = e.Node.Tag as listObservPlanDetails;
            btnStart.Enabled = (pd != null) && (pd.OrganCode != null);
            btnMonitor.Enabled = (pd != null) && (pd.OrganCode != null);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //
        }

        private void btnMonitor_Click(object sender, EventArgs e)
        {
            //
        }
    }
}
