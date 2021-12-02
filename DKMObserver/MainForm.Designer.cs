
namespace DKMObserver
{
    partial class MainForm
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
            this.btnOpenObserver = new System.Windows.Forms.Button();
            this.dgvObserves = new System.Windows.Forms.DataGridView();
            this.FName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Birthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SortOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.begTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.historyItemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vwHistoryObservationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbIcmDataSet = new DKMObserver.dbIcmDataSet();
            this.vwHistory_ObservationTableAdapter = new DKMObserver.dbIcmDataSetTableAdapters.vwHistory_ObservationTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObserves)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwHistoryObservationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbIcmDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenObserver
            // 
            this.btnOpenObserver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenObserver.Location = new System.Drawing.Point(624, 465);
            this.btnOpenObserver.Name = "btnOpenObserver";
            this.btnOpenObserver.Size = new System.Drawing.Size(172, 23);
            this.btnOpenObserver.TabIndex = 0;
            this.btnOpenObserver.Text = "Панель съема данных";
            this.btnOpenObserver.UseVisualStyleBackColor = true;
            this.btnOpenObserver.Click += new System.EventHandler(this.btnOpenObserver_Click);
            // 
            // dgvObserves
            // 
            this.dgvObserves.AllowUserToAddRows = false;
            this.dgvObserves.AllowUserToDeleteRows = false;
            this.dgvObserves.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvObserves.AutoGenerateColumns = false;
            this.dgvObserves.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvObserves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvObserves.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FName,
            this.IName,
            this.OName,
            this.Birthday,
            this.nameDataGridViewTextBoxColumn,
            this.begTimeDataGridViewTextBoxColumn,
            this.endTimeDataGridViewTextBoxColumn,
            this.SortOrder,
            this.historyItemDataGridViewTextBoxColumn,
            this.patientIDDataGridViewTextBoxColumn});
            this.dgvObserves.DataSource = this.vwHistoryObservationBindingSource;
            this.dgvObserves.Location = new System.Drawing.Point(12, 12);
            this.dgvObserves.Name = "dgvObserves";
            this.dgvObserves.ReadOnly = true;
            this.dgvObserves.Size = new System.Drawing.Size(784, 447);
            this.dgvObserves.TabIndex = 1;
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
            // SortOrder
            // 
            this.SortOrder.DataPropertyName = "SortOrder";
            this.SortOrder.HeaderText = "SortOrder";
            this.SortOrder.Name = "SortOrder";
            this.SortOrder.ReadOnly = true;
            this.SortOrder.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(106, 465);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Обследование";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // begTimeDataGridViewTextBoxColumn
            // 
            this.begTimeDataGridViewTextBoxColumn.DataPropertyName = "BegTime";
            this.begTimeDataGridViewTextBoxColumn.HeaderText = "Начало";
            this.begTimeDataGridViewTextBoxColumn.Name = "begTimeDataGridViewTextBoxColumn";
            this.begTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // endTimeDataGridViewTextBoxColumn
            // 
            this.endTimeDataGridViewTextBoxColumn.DataPropertyName = "EndTime";
            this.endTimeDataGridViewTextBoxColumn.HeaderText = "Окончание";
            this.endTimeDataGridViewTextBoxColumn.Name = "endTimeDataGridViewTextBoxColumn";
            this.endTimeDataGridViewTextBoxColumn.ReadOnly = true;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 500);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvObserves);
            this.Controls.Add(this.btnOpenObserver);
            this.Name = "MainForm";
            this.Text = "Исследования ДКМ";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvObserves)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwHistoryObservationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbIcmDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenObserver;
        private System.Windows.Forms.DataGridView dgvObserves;
        private dbIcmDataSet dbIcmDataSet;
        private System.Windows.Forms.BindingSource vwHistoryObservationBindingSource;
        private dbIcmDataSetTableAdapters.vwHistory_ObservationTableAdapter vwHistory_ObservationTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn FName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Birthday;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn begTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SortOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn historyItemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
    }
}

