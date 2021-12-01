using DKMObserver.dbIcmDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DKMObserver
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private static short[] test = { 1, 2, 333, 276, 33, 221, 228, 22, 11, 98, 14 };

        private void button1_Click(object sender, EventArgs e)
        {
            //var en = Compressor.CompressArray(test);
            //Console.Write(en);

            var td = new dbIcmDataSet.hstObservationDetailDataDataTable();
            var ad = new hstObservationDetailDataTableAdapter();
            ad.Fill(td);

            foreach (dbIcmDataSet.hstObservationDetailDataRow row in td.Rows)
            {
                var str = System.Text.Encoding.GetEncoding(1251).GetString(row.Data);
                //var str = System.Text.Encoding.Default.GetString(row.Data);
                //var str = System.Text.Encoding.ASCII.GetString(row.Data);
                
                var re = new Regex("(?<=<Sample\\sBegTime=\"\\d+\"\\sComment=\"\"\\sFrequency=\"\\d+\">)(.*)(?=</Sample>)", RegexOptions.Singleline);
                var s = re.Matches(str);
                var data = System.Text.Encoding.GetEncoding(1251).GetBytes(s[0].Groups[1].Value);
                var samples = Compressor.UncompressArray(data);
                Console.WriteLine(samples.Length);
                str = re.Replace(str, "data");
                // var x = System.Xml.Linq.XDocument.Parse(str);
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(str);
                XmlElement xRoot = xDoc.DocumentElement;
                if (xRoot != null)
                {
                    foreach (XmlElement xnode in xRoot)
                    {
                        Console.WriteLine();
                    }
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dbIcmDataSet.vwHistory_Observation". При необходимости она может быть перемещена или удалена.
            this.vwHistory_ObservationTableAdapter.Fill(this.dbIcmDataSet.vwHistory_Observation);

        }

        private void btnOpenObserver_Click(object sender, EventArgs e)
        {
            if (dgvObserves.CurrentRow != null)
            {
                var drv = dgvObserves.CurrentRow.DataBoundItem as DataRowView;
                if (drv != null)
                {
                    var row = drv.Row as DKMObserver.dbIcmDataSet.vwHistory_ObservationRow;
;
                    Console.WriteLine(row.PatientID);
                    //var item = row.HistoryItem;
                    //var 

                    var op = new ObservePanel();
                    op.patientId = row.PatientID;
                    op.historyItem = row.HistoryItem;
                    op.ShowDialog();
                }
            }
            
        }
    }
}
