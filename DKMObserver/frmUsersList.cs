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
    public partial class frmUsersList : Form
    {
        public frmUsersList()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.vwHistory_ObservationTableAdapter.FillBy100(this.dbIcmDataSet.vwHistory_Observation);

        }

        private void openObserver()
        {
            if (dgvObserves.CurrentRow != null)
            {
                var drv = dgvObserves.CurrentRow.DataBoundItem as DataRowView;
                if (drv != null)
                {
                    var row = drv.Row as DKMObserver.dbIcmDataSet.vwHistory_ObservationRow;
                    (this.MdiParent as MainForm).openObserver(row.PatientID, row.HistoryItem, row.FName, row.IName, row.OName);
                }
            }
        }

        private void btnOpenObserver_Click(object sender, EventArgs e)
        {
            this.openObserver();
        }

        private void dgvObserves_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.openObserver();
        }

        private void frmUsersList_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = e.CloseReason == CloseReason.UserClosing;
        }

        private void tbRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                this.vwHistory_ObservationTableAdapter.FillBy100(this.dbIcmDataSet.vwHistory_Observation);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
