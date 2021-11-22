
namespace DKMObserver
{
    partial class ObservePanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.cbObservPlans = new System.Windows.Forms.ComboBox();
            this.listObservPlansBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbIcmDataSet = new DKMObserver.dbIcmDataSet();
            this.listObservPlansTableAdapter = new DKMObserver.dbIcmDataSetTableAdapters.listObservPlansTableAdapter();
            this.trPlanDetail = new System.Windows.Forms.TreeView();
            this.listObservPlanDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listObservPlanDetailsTableAdapter = new DKMObserver.dbIcmDataSetTableAdapters.listObservPlanDetailsTableAdapter();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnMonitor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.listObservPlansBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbIcmDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listObservPlanDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Планы обследования";
            // 
            // cbObservPlans
            // 
            this.cbObservPlans.DataSource = this.listObservPlansBindingSource;
            this.cbObservPlans.DisplayMember = "PlanName";
            this.cbObservPlans.FormattingEnabled = true;
            this.cbObservPlans.Location = new System.Drawing.Point(11, 25);
            this.cbObservPlans.Name = "cbObservPlans";
            this.cbObservPlans.Size = new System.Drawing.Size(359, 21);
            this.cbObservPlans.TabIndex = 5;
            this.cbObservPlans.ValueMember = "PlanCode";
            this.cbObservPlans.SelectedValueChanged += new System.EventHandler(this.cbObservPlans_SelectedValueChanged);
            // 
            // listObservPlansBindingSource
            // 
            this.listObservPlansBindingSource.DataMember = "listObservPlans";
            this.listObservPlansBindingSource.DataSource = this.dbIcmDataSet;
            // 
            // dbIcmDataSet
            // 
            this.dbIcmDataSet.DataSetName = "dbIcmDataSet";
            this.dbIcmDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // listObservPlansTableAdapter
            // 
            this.listObservPlansTableAdapter.ClearBeforeFill = true;
            // 
            // trPlanDetail
            // 
            this.trPlanDetail.Location = new System.Drawing.Point(12, 52);
            this.trPlanDetail.Name = "trPlanDetail";
            this.trPlanDetail.Size = new System.Drawing.Size(358, 451);
            this.trPlanDetail.TabIndex = 7;
            this.trPlanDetail.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trPlanDetail_AfterSelect);
            // 
            // listObservPlanDetailsBindingSource
            // 
            this.listObservPlanDetailsBindingSource.DataMember = "listObservPlanDetails";
            this.listObservPlanDetailsBindingSource.DataSource = this.dbIcmDataSet;
            // 
            // listObservPlanDetailsTableAdapter
            // 
            this.listObservPlanDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            this.chart1.Location = new System.Drawing.Point(11, 509);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Name = "Series1";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(777, 124);
            this.chart1.TabIndex = 8;
            this.chart1.Text = "chart1";
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(643, 453);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(144, 49);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "Запуск диагностики";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnMonitor
            // 
            this.btnMonitor.Enabled = false;
            this.btnMonitor.Location = new System.Drawing.Point(472, 453);
            this.btnMonitor.Name = "btnMonitor";
            this.btnMonitor.Size = new System.Drawing.Size(145, 49);
            this.btnMonitor.TabIndex = 10;
            this.btnMonitor.Text = "Запуск мониторинга";
            this.btnMonitor.UseVisualStyleBackColor = true;
            this.btnMonitor.Click += new System.EventHandler(this.btnMonitor_Click);
            // 
            // ObservePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 640);
            this.Controls.Add(this.btnMonitor);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.trPlanDetail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbObservPlans);
            this.Name = "ObservePanel";
            this.Text = "Панель съема данных";
            this.Load += new System.EventHandler(this.ObservePanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listObservPlansBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbIcmDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listObservPlanDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbObservPlans;
        private dbIcmDataSet dbIcmDataSet;
        private System.Windows.Forms.BindingSource listObservPlansBindingSource;
        private dbIcmDataSetTableAdapters.listObservPlansTableAdapter listObservPlansTableAdapter;
        private System.Windows.Forms.TreeView trPlanDetail;
        private System.Windows.Forms.BindingSource listObservPlanDetailsBindingSource;
        private dbIcmDataSetTableAdapters.listObservPlanDetailsTableAdapter listObservPlanDetailsTableAdapter;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnMonitor;
    }
}