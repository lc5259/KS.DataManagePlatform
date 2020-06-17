namespace KS.DataManagePlatform
{
    partial class AddGroupConfig
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.kryLbName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryTextBoxName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryCheckBoxContinuousGroup = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.kryButtonOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryButtonCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // kryLbName
            // 
            this.kryLbName.Location = new System.Drawing.Point(69, 21);
            this.kryLbName.Name = "kryLbName";
            this.kryLbName.Size = new System.Drawing.Size(101, 20);
            this.kryLbName.TabIndex = 6;
            this.kryLbName.Values.Text = "请输入分组名称";
            // 
            // kryTextBoxName
            // 
            this.kryTextBoxName.Location = new System.Drawing.Point(176, 18);
            this.kryTextBoxName.Name = "kryTextBoxName";
            this.kryTextBoxName.Size = new System.Drawing.Size(178, 23);
            this.kryTextBoxName.TabIndex = 7;
            // 
            // kryCheckBoxContinuousGroup
            // 
            this.kryCheckBoxContinuousGroup.Location = new System.Drawing.Point(69, 59);
            this.kryCheckBoxContinuousGroup.Name = "kryCheckBoxContinuousGroup";
            this.kryCheckBoxContinuousGroup.Size = new System.Drawing.Size(127, 20);
            this.kryCheckBoxContinuousGroup.TabIndex = 8;
            this.kryCheckBoxContinuousGroup.Values.Text = "连续配置分组数据";
            // 
            // kryButtonOK
            // 
            this.kryButtonOK.Location = new System.Drawing.Point(83, 99);
            this.kryButtonOK.Name = "kryButtonOK";
            this.kryButtonOK.Size = new System.Drawing.Size(90, 25);
            this.kryButtonOK.TabIndex = 9;
            this.kryButtonOK.Values.Text = "确定";
            this.kryButtonOK.Click += new System.EventHandler(this.kryButtonOK_Click);
            // 
            // kryButtonCancel
            // 
            this.kryButtonCancel.Location = new System.Drawing.Point(234, 99);
            this.kryButtonCancel.Name = "kryButtonCancel";
            this.kryButtonCancel.Size = new System.Drawing.Size(90, 25);
            this.kryButtonCancel.TabIndex = 10;
            this.kryButtonCancel.Values.Text = "取消";
            this.kryButtonCancel.Click += new System.EventHandler(this.kryButtonCancel_Click);
            // 
            // AddGroupConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 146);
            this.Controls.Add(this.kryButtonCancel);
            this.Controls.Add(this.kryButtonOK);
            this.Controls.Add(this.kryCheckBoxContinuousGroup);
            this.Controls.Add(this.kryTextBoxName);
            this.Controls.Add(this.kryLbName);
            this.Name = "AddGroupConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "增加分组数据配置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryLbName;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryTextBoxName;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox kryCheckBoxContinuousGroup;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryButtonOK;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryButtonCancel;
    }
}