namespace KS.DataManagePlatform
{
    partial class DelGroupConfig
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
            this.kryLbName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryCheckBoxAll = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.kryCheckedListBox = new ComponentFactory.Krypton.Toolkit.KryptonCheckedListBox();
            this.kryButtonOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryButtonCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // kryLbName
            // 
            this.kryLbName.Location = new System.Drawing.Point(50, 32);
            this.kryLbName.Name = "kryLbName";
            this.kryLbName.Size = new System.Drawing.Size(153, 20);
            this.kryLbName.TabIndex = 3;
            this.kryLbName.Values.Text = "请选择要删除的分组数据";
            // 
            // kryCheckBoxAll
            // 
            this.kryCheckBoxAll.Location = new System.Drawing.Point(60, 58);
            this.kryCheckBoxAll.Name = "kryCheckBoxAll";
            this.kryCheckBoxAll.Size = new System.Drawing.Size(49, 20);
            this.kryCheckBoxAll.TabIndex = 4;
            this.kryCheckBoxAll.Values.Text = "全选";
            this.kryCheckBoxAll.CheckedChanged += new System.EventHandler(this.kryCheckBoxAll_CheckedChanged);
            // 
            // kryCheckedListBox
            // 
            this.kryCheckedListBox.CheckOnClick = true;
            this.kryCheckedListBox.Location = new System.Drawing.Point(60, 84);
            this.kryCheckedListBox.Name = "kryCheckedListBox";
            this.kryCheckedListBox.Size = new System.Drawing.Size(269, 137);
            this.kryCheckedListBox.TabIndex = 5;
            this.kryCheckedListBox.SelectedValueChanged += new System.EventHandler(this.kryCheckedListBox_SelectedValueChanged);
            // 
            // kryButtonOK
            // 
            this.kryButtonOK.Location = new System.Drawing.Point(60, 257);
            this.kryButtonOK.Name = "kryButtonOK";
            this.kryButtonOK.Size = new System.Drawing.Size(90, 25);
            this.kryButtonOK.TabIndex = 6;
            this.kryButtonOK.Values.Text = "确定";
            this.kryButtonOK.Click += new System.EventHandler(this.kryButtonOK_Click);
            // 
            // kryButtonCancel
            // 
            this.kryButtonCancel.Location = new System.Drawing.Point(239, 257);
            this.kryButtonCancel.Name = "kryButtonCancel";
            this.kryButtonCancel.Size = new System.Drawing.Size(90, 25);
            this.kryButtonCancel.TabIndex = 7;
            this.kryButtonCancel.Values.Text = "取消";
            this.kryButtonCancel.Click += new System.EventHandler(this.kryButtonCancel_Click);
            // 
            // DelGroupConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 309);
            this.Controls.Add(this.kryButtonCancel);
            this.Controls.Add(this.kryButtonOK);
            this.Controls.Add(this.kryCheckedListBox);
            this.Controls.Add(this.kryCheckBoxAll);
            this.Controls.Add(this.kryLbName);
            this.Name = "DelGroupConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "删除分组";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryLbName;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox kryCheckBoxAll;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryButtonOK;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryButtonCancel;
        public ComponentFactory.Krypton.Toolkit.KryptonCheckedListBox kryCheckedListBox;
    }
}