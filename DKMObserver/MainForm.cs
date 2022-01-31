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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        frmUsersList form;

        private void MainForm_Load(object sender, EventArgs e)
        {
            form = new frmUsersList();
            form.MdiParent = this;
            form.Show();
        }

        ObservePanel op = null;

        internal void openObserver(Guid patientId, int historyItem, string fName, string iName, string oName)
        {
            if (op != null)
            {
                op.Close();
                op.Dispose();
            }

            op = new ObservePanel();
            op.MdiParent = this;
            op.patientId = patientId;
            op.historyItem = historyItem;
            op.FName = fName;
            op.IName = iName;
            op.OName = oName;
            op.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                Properties.Settings.Default.Location = RestoreBounds.Location;
                Properties.Settings.Default.Size = RestoreBounds.Size;
                Properties.Settings.Default.Maximised = true;
                Properties.Settings.Default.Minimised = false;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.Location = Location;
                Properties.Settings.Default.Size = Size;
                Properties.Settings.Default.Maximised = false;
                Properties.Settings.Default.Minimised = false;
            }
            else
            {
                Properties.Settings.Default.Location = RestoreBounds.Location;
                Properties.Settings.Default.Size = RestoreBounds.Size;
                Properties.Settings.Default.Maximised = false;
                Properties.Settings.Default.Minimised = true;
            }
            Properties.Settings.Default.Save();
        }
    }
}
