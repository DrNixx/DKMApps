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
    public partial class WaitForm : Form
    {
        private int waitTime = 10;

        private DateTime endTime;

        public WaitForm(int waitTime)
        {
            InitializeComponent();
            this.waitTime = waitTime;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var diff = (int)Math.Floor(endTime.Subtract(DateTime.Now).TotalSeconds);

            if (diff > 0)
            {
                label2.Text = string.Format("{0} сек", diff);
            } 
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void WaitForm_Shown(object sender, EventArgs e)
        {
            this.endTime = DateTime.Now.AddSeconds(this.waitTime);
            timer1.Start();
        }
    }
}
