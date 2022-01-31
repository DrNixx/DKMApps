
namespace DKMObserver
{
    partial class frmUsersList
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsersList));
            this.vwHistoryObservationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbIcmDataSet = new DKMObserver.dbIcmDataSet();
            this.vwHistory_ObservationTableAdapter = new DKMObserver.dbIcmDataSetTableAdapters.vwHistory_ObservationTableAdapter();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbOpenObserver = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvObserves = new System.Windows.Forms.DataGridView();
            this.FName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Birthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.begTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SortOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.historyItemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.vwHistoryObservationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbIcmDataSet)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObserves)).BeginInit();
            this.SuspendLayout();
            // 
            // vwHistoryObservationBindingSource
            // 
            this.vwHistoryObservationBindingSource.AllowNew = false;
            this.vwHistoryObservationBindingSource.DataMember = "vwHistory_Observation";
            this.vwHistoryObservationBindingSource.DataSource = this.dbIcmDataSet;
            this.vwHistoryObservationBindingSource.Filter = "";
            this.vwHistoryObservationBindingSource.Sort = "";
            // 
            // dbIcmDataSet
            // 
            this.dbIcmDataSet.DataSetName = "dbIcmDataSet";
            this.dbIcmDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vwHistory_ObservationTableAdapter
            // 
            this.vwHistory_ObservationTableAdapter.ClearBeforeFill = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbRefresh,
            this.toolStripSeparator1,
            this.tbOpenObserver});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(808, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbRefresh
            // 
            this.tbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tbRefresh.Image")));
            this.tbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbRefresh.Name = "tbRefresh";
            this.tbRefresh.Size = new System.Drawing.Size(81, 22);
            this.tbRefresh.Text = "Обновить";
            this.tbRefresh.ToolTipText = "Обновить";
            this.tbRefresh.Click += new System.EventHandler(this.tbRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbOpenObserver
            // 
            this.tbOpenObserver.Image = ((System.Drawing.Image)(resources.GetObject("tbOpenObserver.Image")));
            this.tbOpenObserver.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbOpenObserver.Name = "tbOpenObserver";
            this.tbOpenObserver.Size = new System.Drawing.Size(149, 22);
            this.tbOpenObserver.Text = "Панель съема данных";
            this.tbOpenObserver.ToolTipText = "Открыть панель съема данных";
            this.tbOpenObserver.Click += new System.EventHandler(this.btnOpenObserver_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvObserves);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(808, 475);
            this.panel1.TabIndex = 4;
            // 
            // dgvObserves
            // 
            this.dgvObserves.AllowUserToAddRows = false;
            this.dgvObserves.AllowUserToDeleteRows = false;
            this.dgvObserves.AutoGenerateColumns = false;
            this.dgvObserves.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvObserves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvObserves.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FName,
            this.IName,
            this.OName,
            this.Birthday,
            this.begTimeDataGridViewTextBoxColumn,
            this.SortOrder,
            this.historyItemDataGridViewTextBoxColumn,
            this.patientIDDataGridViewTextBoxColumn});
            this.dgvObserves.DataSource = this.vwHistoryObservationBindingSource;
            this.dgvObserves.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvObserves.Location = new System.Drawing.Point(0, 0);
            this.dgvObserves.Name = "dgvObserves";
            this.dgvObserves.ReadOnly = true;
            this.dgvObserves.Size = new System.Drawing.Size(808, 475);
            this.dgvObserves.TabIndex = 2;
            this.dgvObserves.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvObserves_CellDoubleClick);
            // 
            // FName
            // 
            this.FName.DataPropertyName = "FName";
            this.FName.HeaderText = "Фамилия";
            this.FName.Name = "FName";
            this.FName.ReadOnly = true;
            // 
            // IName
            // 
            this.IName.DataPropertyName = "IName";
            this.IName.HeaderText = "Имя";
            this.IName.Name = "IName";
            this.IName.ReadOnly = true;
            // 
            // OName
            // 
            this.OName.DataPropertyName = "OName";
            this.OName.HeaderText = "Отчество";
            this.OName.Name = "OName";
            this.OName.ReadOnly = true;
            // 
            // Birthday
            // 
            this.Birthday.DataPropertyName = "Birthday";
            this.Birthday.HeaderText = "Дата рождения";
            this.Birthday.Name = "Birthday";
            this.Birthday.ReadOnly = true;
            // 
            // begTimeDataGridViewTextBoxColumn
            // 
            this.begTimeDataGridViewTextBoxColumn.DataPropertyName = "BegTime";
            this.begTimeDataGridViewTextBoxColumn.HeaderText = "Дата";
            this.begTimeDataGridViewTextBoxColumn.Name = "begTimeDataGridViewTextBoxColumn";
            this.begTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // SortOrder
            // 
            this.SortOrder.DataPropertyName = "SortOrder";
            this.SortOrder.HeaderText = "SortOrder";
            this.SortOrder.Name = "SortOrder";
            this.SortOrder.ReadOnly = true;
            this.SortOrder.Visible = false;
            // 
            // historyItemDataGridViewTextBoxColumn
            // 
            this.historyItemDataGridViewTextBoxColumn.DataPropertyName = "HistoryItem";
            this.historyItemDataGridViewTextBoxColumn.HeaderText = "HistoryItem";
            this.historyItemDataGridViewTextBoxColumn.Name = "historyItemDataGridViewTextBoxColumn";
            this.historyItemDataGridViewTextBoxColumn.ReadOnly = true;
            this.historyItemDataGridViewTextBoxColumn.Visible = false;
            // 
            // patientIDDataGridViewTextBoxColumn
            // 
            this.patientIDDataGridViewTextBoxColumn.DataPropertyName = "PatientID";
            this.patientIDDataGridViewTextBoxColumn.HeaderText = "PatientID";
            this.patientIDDataGridViewTextBoxColumn.Name = "patientIDDataGridViewTextBoxColumn";
            this.patientIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.patientIDDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.patientIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // frmUsersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 500);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmUsersList";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Список обследований";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmUsersList_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vwHistoryObservationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbIcmDataSet)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvObserves)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private dbIcmDataSet dbIcmDataSet;
        private System.Windows.Forms.BindingSource vwHistoryObservationBindingSource;
        private dbIcmDataSetTableAdapters.vwHistory_ObservationTableAdapter vwHistory_ObservationTableAdapter;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tbOpenObserver;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvObserves;
        private System.Windows.Forms.DataGridViewTextBoxColumn FName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Birthday;
        private System.Windows.Forms.DataGridViewTextBoxColumn begTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SortOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn historyItemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientIDDataGridViewTextBoxColumn;
    }
}

