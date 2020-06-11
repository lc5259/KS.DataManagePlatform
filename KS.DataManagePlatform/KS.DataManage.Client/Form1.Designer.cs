namespace KS.DataManage.Client
{
    partial class Form1
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
            this.uC_FutureContractInfo1 = new KS.DataManage.Client.UC_FutureContractInfo();
            this.SuspendLayout();
            // 
            // uC_FutureContractInfo1
            // 
            this.uC_FutureContractInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_FutureContractInfo1.Location = new System.Drawing.Point(0, 0);
            this.uC_FutureContractInfo1.Name = "uC_FutureContractInfo1";
            this.uC_FutureContractInfo1.Size = new System.Drawing.Size(974, 602);
            this.uC_FutureContractInfo1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 602);
            this.Controls.Add(this.uC_FutureContractInfo1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private UC_FutureContractInfo uC_FutureContractInfo1;
    }
}