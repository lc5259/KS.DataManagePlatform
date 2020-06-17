using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
namespace KS.DataManagePlatform
{
	public class AppStartLogoForm : Form
	{
		private IContainer components;
        private PictureBox pictureBox1;
		private Label caption;

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
            this.caption = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // caption
            // 
            this.caption.AutoSize = true;
            this.caption.BackColor = System.Drawing.Color.Transparent;
            this.caption.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.caption.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.caption.ForeColor = System.Drawing.SystemColors.ControlText;
            this.caption.Location = new System.Drawing.Point(0, 405);
            this.caption.Margin = new System.Windows.Forms.Padding(0);
            this.caption.Name = "caption";
            this.caption.Padding = new System.Windows.Forms.Padding(2, 0, 0, 2);
            this.caption.Size = new System.Drawing.Size(2, 14);
            this.caption.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(541, 405);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // AppStartLogoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(541, 419);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.caption);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AppStartLogoForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLogo";
            this.Load += new System.EventHandler(this.AppStartLogoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		public AppStartLogoForm()
		{
			this.InitializeComponent();
			this.caption.Text = "正在初始化系统服务...";
			//this.SetBackGroupImage();
		}

		public void SetBackGroupImage()
		{
			string text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\Images\\Start_Splash.bmp");
			if (File.Exists(text))
			{
				this.BackgroundImage = Image.FromFile(text);
				this.Size = this.BackgroundImage.Size;
			}
		}

		public bool Run()
		{
			bool result;
			try
			{
                Assembly assembly = Assembly.Load("KS.DataManage.Client");

                Type type = assembly.GetType("KS.DataManage.Client.ApplicationInitializer");
				MethodInfo method = type.GetMethod("Run", BindingFlags.Static | BindingFlags.Public);
				method.Invoke(method, null);
				method = type.GetMethod("CreateMainForm", BindingFlags.Static | BindingFlags.Public);
				method.Invoke(method, null);
				method = type.GetMethod("InitializeMainForm", BindingFlags.Static | BindingFlags.Public);
				method.Invoke(method, null);
				result = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				AppDomain.CurrentDomain.SetData("IsError", true);
				result = false;
			}
			return result;
		}
		private void AppStartLogoForm_Load(object sender, EventArgs e)
		{
		}
	}
}
