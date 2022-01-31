
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.listObservPlansBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbIcmDataSet = new DKMObserver.dbIcmDataSet();
            this.listObservPlansTableAdapter = new DKMObserver.dbIcmDataSetTableAdapters.listObservPlansTableAdapter();
            this.listObservPlanDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listObservPlanDetailsTableAdapter = new DKMObserver.dbIcmDataSetTableAdapters.listObservPlanDetailsTableAdapter();
            this.listOrgansBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listOrgansTableAdapter = new DKMObserver.dbIcmDataSetTableAdapters.listOrgansTableAdapter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.trPlanDetail = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.cbObservPlans = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbPatient = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel4 = new System.Windows.Forms.Panel();
            this.nDiagLen = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nFreq = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nPause = new System.Windows.Forms.NumericUpDown();
            this.cbCards = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.listObservPlansBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbIcmDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listObservPlanDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listOrgansBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nDiagLen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPause)).BeginInit();
            this.SuspendLayout();
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
            // listObservPlanDetailsBindingSource
            // 
            this.listObservPlanDetailsBindingSource.DataMember = "listObservPlanDetails";
            this.listObservPlanDetailsBindingSource.DataSource = this.dbIcmDataSet;
            // 
            // listObservPlanDetailsTableAdapter
            // 
            this.listObservPlanDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // listOrgansBindingSource
            // 
            this.listOrgansBindingSource.DataMember = "listOrgans";
            this.listOrgansBindingSource.DataSource = this.dbIcmDataSet;
            // 
            // listOrgansTableAdapter
            // 
            this.listOrgansTableAdapter.ClearBeforeFill = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 386);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 66);
            this.panel1.TabIndex = 19;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(636, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(152, 46);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(11, 8);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(144, 49);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Запуск диагностики";
            this.btnStart.EnabledChanged += new System.EventHandler(this.btnStart_EnabledChanged);
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.trPlanDetail);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cbObservPlans);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(8);
            this.panel2.Size = new System.Drawing.Size(370, 386);
            this.panel2.TabIndex = 20;
            // 
            // trPlanDetail
            // 
            this.trPlanDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trPlanDetail.Location = new System.Drawing.Point(11, 52);
            this.trPlanDetail.Name = "trPlanDetail";
            this.trPlanDetail.Size = new System.Drawing.Size(347, 334);
            this.trPlanDetail.TabIndex = 10;
            this.trPlanDetail.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trPlanDetail_AfterSelect);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Планы обследования";
            // 
            // cbObservPlans
            // 
            this.cbObservPlans.DataSource = this.listObservPlansBindingSource;
            this.cbObservPlans.DisplayMember = "PlanName";
            this.cbObservPlans.FormattingEnabled = true;
            this.cbObservPlans.Location = new System.Drawing.Point(11, 25);
            this.cbObservPlans.Name = "cbObservPlans";
            this.cbObservPlans.Size = new System.Drawing.Size(347, 21);
            this.cbObservPlans.TabIndex = 8;
            this.cbObservPlans.ValueMember = "PlanCode";
            this.cbObservPlans.SelectedValueChanged += new System.EventHandler(this.cbObservPlans_SelectedValueChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbPatient);
            this.panel3.Controls.Add(this.chart1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(370, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.panel3.Size = new System.Drawing.Size(430, 386);
            this.panel3.TabIndex = 21;
            // 
            // lbPatient
            // 
            this.lbPatient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPatient.Location = new System.Drawing.Point(7, 204);
            this.lbPatient.Name = "lbPatient";
            this.lbPatient.Size = new System.Drawing.Size(411, 55);
            this.lbPatient.TabIndex = 10;
            this.lbPatient.Text = "lbName";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chart1.Location = new System.Drawing.Point(0, 262);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(422, 124);
            this.chart1.TabIndex = 9;
            this.chart1.Text = "chart1";
            this.chart1.Visible = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.nDiagLen);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.nFreq);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.nPause);
            this.panel4.Controls.Add(this.cbCards);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(422, 153);
            this.panel4.TabIndex = 0;
            // 
            // nDiagLen
            // 
            this.nDiagLen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nDiagLen.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nDiagLen.Location = new System.Drawing.Point(299, 120);
            this.nDiagLen.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nDiagLen.Name = "nDiagLen";
            this.nDiagLen.Size = new System.Drawing.Size(120, 20);
            this.nDiagLen.TabIndex = 26;
            this.nDiagLen.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(271, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Длительность диагностики";
            // 
            // nFreq
            // 
            this.nFreq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nFreq.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nFreq.Location = new System.Drawing.Point(139, 120);
            this.nFreq.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nFreq.Name = "nFreq";
            this.nFreq.Size = new System.Drawing.Size(120, 20);
            this.nFreq.TabIndex = 24;
            this.nFreq.Value = new decimal(new int[] {
            160,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(210, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Частота";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(263, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Пауза перед съемом данных";
            // 
            // nPause
            // 
            this.nPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nPause.Location = new System.Drawing.Point(299, 73);
            this.nPause.Name = "nPause";
            this.nPause.Size = new System.Drawing.Size(120, 20);
            this.nPause.TabIndex = 21;
            this.nPause.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // cbCards
            // 
            this.cbCards.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCards.FormattingEnabled = true;
            this.cbCards.Location = new System.Drawing.Point(271, 25);
            this.cbCards.Name = "cbCards";
            this.cbCards.Size = new System.Drawing.Size(151, 21);
            this.cbCards.TabIndex = 20;
            this.cbCards.SelectedIndexChanged += new System.EventHandler(this.cbCards_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(385, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Карта";
            // 
            // ObservePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 452);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ObservePanel";
            this.Text = "Панель съема данных";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ObservePanel_Load);
            this.Shown += new System.EventHandler(this.ObservePanel_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.listObservPlansBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbIcmDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listObservPlanDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listOrgansBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nDiagLen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPause)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private dbIcmDataSet dbIcmDataSet;
        private System.Windows.Forms.BindingSource listObservPlansBindingSource;
        private dbIcmDataSetTableAdapters.listObservPlansTableAdapter listObservPlansTableAdapter;
        private System.Windows.Forms.BindingSource listObservPlanDetailsBindingSource;
        private dbIcmDataSetTableAdapters.listObservPlanDetailsTableAdapter listObservPlanDetailsTableAdapter;
        private System.Windows.Forms.BindingSource listOrgansBindingSource;
        private dbIcmDataSetTableAdapters.listOrgansTableAdapter listOrgansTableAdapter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView trPlanDetail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbObservPlans;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.NumericUpDown nDiagLen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nFreq;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nPause;
        private System.Windows.Forms.ComboBox cbCards;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbPatient;
    }
}