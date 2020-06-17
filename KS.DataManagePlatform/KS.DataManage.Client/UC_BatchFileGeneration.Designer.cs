namespace KS.DataManagePlatform
{
    partial class BatchFileGeneration
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
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelDate = new System.Windows.Forms.Label();
            this.buttonOneTouch = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
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
            this.labelGroupData.Location = new System.Drawing.Point(27, 24);
            this.labelGroupData.Name = "labelGroupData";
            this.labelGroupData.Size = new System.Drawing.Size(137, 12);
            this.labelGroupData.TabIndex = 0;
            this.labelGroupData.Text = "请选择要生成的分组数据";
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name,
            this.Status,
            this.Time,
            this.Remark});
            this.dataGridView.Location = new System.Drawing.Point(29, 52);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(588, 150);
            this.dataGridView.TabIndex = 1;
            // 
            // Name
            // 
            this.Name.HeaderText = "分组名称";
            this.Name.Name = "Name";
            this.Name.Width = 120;
            // 
            // Status
            // 
            this.Status.HeaderText = "生成状态";
            this.Status.Name = "Status";
            // 
            // Time
            // 
            this.Time.HeaderText = "耗时";
            this.Time.Name = "Time";
            this.Time.Width = 80;
            // 
            // Remark
            // 
            this.Remark.HeaderText = "备注";
            this.Remark.Name = "Remark";
            this.Remark.Width = 120;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(276, 241);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(29, 12);
            this.labelDate.TabIndex = 2;
            this.labelDate.Text = "日期";
            // 
            // buttonOneTouch
            // 
            this.buttonOneTouch.Location = new System.Drawing.Point(449, 235);
            this.buttonOneTouch.Name = "buttonOneTouch";
            this.buttonOneTouch.Size = new System.Drawing.Size(75, 23);
            this.buttonOneTouch.TabIndex = 3;
            this.buttonOneTouch.Text = "一键生成";
            this.buttonOneTouch.UseVisualStyleBackColor = true;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(542, 235);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 4;
            this.buttonClose.Text = "关闭";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(311, 235);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(105, 21);
            this.dateTimePicker.TabIndex = 5;
            // 
            // label1GroupName
            // 
            this.label1GroupName.AutoSize = true;
            this.label1GroupName.Location = new System.Drawing.Point(27, 241);
            this.label1GroupName.Name = "label1GroupName";
            this.label1GroupName.Size = new System.Drawing.Size(53, 12);
            this.label1GroupName.TabIndex = 6;
            this.label1GroupName.Text = "分组名称";
            // 
            // labelGroupGenerateStaus
            // 
            this.labelGroupGenerateStaus.AutoSize = true;
            this.labelGroupGenerateStaus.Location = new System.Drawing.Point(86, 241);
            this.labelGroupGenerateStaus.Name = "labelGroupGenerateStaus";
            this.labelGroupGenerateStaus.Size = new System.Drawing.Size(53, 12);
            this.labelGroupGenerateStaus.TabIndex = 7;
            this.labelGroupGenerateStaus.Text = "生成状态";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(217, 241);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(23, 12);
            this.labelTime.TabIndex = 9;
            this.labelTime.Text = "0秒";
            // 
            // label1GroupTime
            // 
            this.label1GroupTime.AutoSize = true;
            this.label1GroupTime.Location = new System.Drawing.Point(182, 241);
            this.label1GroupTime.Name = "label1GroupTime";
            this.label1GroupTime.Size = new System.Drawing.Size(29, 12);
            this.label1GroupTime.TabIndex = 8;
            this.label1GroupTime.Text = "耗时";
            // 
            // BatchFileGeneration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 290);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.label1GroupTime);
            this.Controls.Add(this.labelGroupGenerateStaus);
            this.Controls.Add(this.label1GroupName);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonOneTouch);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.labelGroupData);
            //this.Name = "BatchFileGeneration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "批量文件生成";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelGroupData;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Button buttonOneTouch;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label1GroupName;
        private System.Windows.Forms.Label labelGroupGenerateStaus;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label label1GroupTime;
    }
}