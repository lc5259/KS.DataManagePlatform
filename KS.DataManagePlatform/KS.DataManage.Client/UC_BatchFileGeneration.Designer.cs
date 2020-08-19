namespace KS.DataManagePlatform
{
    partial class BatchFileGeneration11
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
            this.labelGroupData = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelDate = new System.Windows.Forms.Label();
            this.buttonOneTouch = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.kryDTPDate = new System.Windows.Forms.DateTimePicker();
            this.label1GroupName = new System.Windows.Forms.Label();
            this.labelGroupGenerateStaus = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.label1GroupTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // labelGroupData
            // 
            this.labelGroupData.AutoSize = true;
            this.labelGroupData.Location = new System.Drawing.Point(40, 24);
            this.labelGroupData.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGroupData.Name = "labelGroupData";
            this.labelGroupData.Size = new System.Drawing.Size(206, 18);
            this.labelGroupData.TabIndex = 0;
            this.labelGroupData.Text = "请选择要生成的分组数据";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.check,
            this.Name,
            this.Status,
            this.Time,
            this.Remark});
            this.dataGridView.Location = new System.Drawing.Point(43, 58);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(882, 294);
            this.dataGridView.TabIndex = 1;
            // 
            // check
            // 
            this.check.HeaderText = "";
            this.check.Name = "check";
            this.check.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.check.Width = 50;
            // 
            // Name
            // 
            this.Name.DataPropertyName = "DataName";
            this.Name.HeaderText = "分组名称";
            this.Name.Name = "Name";
            this.Name.Width = 120;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "DataStatus";
            this.Status.HeaderText = "生成状态";
            this.Status.Name = "Status";
            // 
            // Time
            // 
            this.Time.DataPropertyName = "DataTime";
            this.Time.HeaderText = "耗时";
            this.Time.Name = "Time";
            this.Time.Width = 80;
            // 
            // Remark
            // 
            this.Remark.DataPropertyName = "DataRemark";
            this.Remark.HeaderText = "备注";
            this.Remark.Name = "Remark";
            this.Remark.Width = 180;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(414, 386);
            this.labelDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(44, 18);
            this.labelDate.TabIndex = 2;
            this.labelDate.Text = "日期";
            // 
            // buttonOneTouch
            // 
            this.buttonOneTouch.Location = new System.Drawing.Point(674, 376);
            this.buttonOneTouch.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOneTouch.Name = "buttonOneTouch";
            this.buttonOneTouch.Size = new System.Drawing.Size(112, 34);
            this.buttonOneTouch.TabIndex = 3;
            this.buttonOneTouch.Text = "一键生成";
            this.buttonOneTouch.UseVisualStyleBackColor = true;
            this.buttonOneTouch.Click += new System.EventHandler(this.buttonOneTouch_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(813, 376);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(112, 34);
            this.buttonClose.TabIndex = 4;
            this.buttonClose.Text = "关闭";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // kryDTPDate
            // 
            this.kryDTPDate.Location = new System.Drawing.Point(466, 376);
            this.kryDTPDate.Margin = new System.Windows.Forms.Padding(4);
            this.kryDTPDate.Name = "kryDTPDate";
            this.kryDTPDate.Size = new System.Drawing.Size(156, 28);
            this.kryDTPDate.TabIndex = 5;
            // 
            // label1GroupName
            // 
            this.label1GroupName.AutoSize = true;
            this.label1GroupName.Location = new System.Drawing.Point(40, 386);
            this.label1GroupName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1GroupName.Name = "label1GroupName";
            this.label1GroupName.Size = new System.Drawing.Size(80, 18);
            this.label1GroupName.TabIndex = 6;
            this.label1GroupName.Text = "分组名称";
            this.label1GroupName.Visible = false;
            // 
            // labelGroupGenerateStaus
            // 
            this.labelGroupGenerateStaus.AutoSize = true;
            this.labelGroupGenerateStaus.Location = new System.Drawing.Point(129, 386);
            this.labelGroupGenerateStaus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGroupGenerateStaus.Name = "labelGroupGenerateStaus";
            this.labelGroupGenerateStaus.Size = new System.Drawing.Size(80, 18);
            this.labelGroupGenerateStaus.TabIndex = 7;
            this.labelGroupGenerateStaus.Text = "生成状态";
            this.labelGroupGenerateStaus.Visible = false;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(326, 386);
            this.labelTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(35, 18);
            this.labelTime.TabIndex = 9;
            this.labelTime.Text = "0秒";
            this.labelTime.Visible = false;
            // 
            // label1GroupTime
            // 
            this.label1GroupTime.AutoSize = true;
            this.label1GroupTime.Location = new System.Drawing.Point(273, 386);
            this.label1GroupTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1GroupTime.Name = "label1GroupTime";
            this.label1GroupTime.Size = new System.Drawing.Size(44, 18);
            this.label1GroupTime.TabIndex = 8;
            this.label1GroupTime.Text = "耗时";
            this.label1GroupTime.Visible = false;
            // 
            // BatchFileGeneration11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 435);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.label1GroupTime);
            this.Controls.Add(this.labelGroupGenerateStaus);
            this.Controls.Add(this.label1GroupName);
            this.Controls.Add(this.kryDTPDate);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonOneTouch);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.labelGroupData);
            this.Margin = new System.Windows.Forms.Padding(4);
            //this.Name = "BatchFileGeneration11";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "批量文件生成";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelGroupData;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Button buttonOneTouch;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.DateTimePicker kryDTPDate;
        private System.Windows.Forms.Label label1GroupName;
        private System.Windows.Forms.Label labelGroupGenerateStaus;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label label1GroupTime;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
    }
}