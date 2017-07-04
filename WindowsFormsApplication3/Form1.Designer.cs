namespace WindowsFormsApplication3
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.state3Button1 = new StateButton.State3Button();
            this.statusBar1 = new StatusBar.StatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.state3Button1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // state3Button1
            // 
            this.state3Button1.BackColor = System.Drawing.Color.Transparent;
            this.state3Button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("state3Button1.BackgroundImage")));
            this.state3Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.state3Button1.Button1.Button = this.state3Button1;
            this.state3Button1.Button1.MyFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.state3Button1.Button1.MyStringAlignment = CustomProperty.CustomButtonProperty.Alignment.Center;
            this.state3Button1.Button1.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage")));
            this.state3Button1.Button1.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage")));
            this.state3Button1.Button1.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage")));
            this.state3Button1.Button2.Button = this.state3Button1;
            this.state3Button1.Button2.MyFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.state3Button1.Button2.MyForeColor = System.Drawing.Color.MediumVioletRed;
            this.state3Button1.Button2.MyStringAlignment = CustomProperty.CustomButtonProperty.Alignment.Center;
            this.state3Button1.Button2.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage1")));
            this.state3Button1.Button2.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage1")));
            this.state3Button1.Button2.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage1")));
            this.state3Button1.Button3.Button = this.state3Button1;
            this.state3Button1.Button3.MyFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.state3Button1.Button3.MyForeColor = System.Drawing.Color.Aqua;
            this.state3Button1.Button3.MyStringAlignment = CustomProperty.CustomButtonProperty.Alignment.Center;
            this.state3Button1.Button3.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage2")));
            this.state3Button1.Button3.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage2")));
            this.state3Button1.Button3.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage2")));
            this.state3Button1.Image = ((System.Drawing.Image)(resources.GetObject("state3Button1.Image")));
            this.state3Button1.InitState = CustomProperty.BtState.Normal;
            this.state3Button1.Location = new System.Drawing.Point(121, 50);
            this.state3Button1.Name = "state3Button1";
            this.state3Button1.Size = new System.Drawing.Size(120, 48);
            this.state3Button1.StateMax = 3;
            this.state3Button1.TabIndex = 1;
            this.state3Button1.TabStop = false;
            this.state3Button1.OnReleaseButtonEvent += new System.EventHandler(this.state3Button1_OnReleaseButtonEvent);
            this.state3Button1.Click += new System.EventHandler(this.state3Button1_Click);
            // 
            // statusBar1
            // 
            this.statusBar1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.statusBar1.Image = ((System.Drawing.Image)(resources.GetObject("statusBar1.Image")));
            this.statusBar1.Location = new System.Drawing.Point(60, 146);
            this.statusBar1.MaxSizeRatio = 100F;
            this.statusBar1.MinSizeRatio = 0F;
            this.statusBar1.MyFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.NormalImage = ((System.Drawing.Image)(resources.GetObject("statusBar1.NormalImage")));
            this.statusBar1.PushedImage = ((System.Drawing.Image)(resources.GetObject("statusBar1.PushedImage")));
            this.statusBar1.SelectImage = ((System.Drawing.Image)(resources.GetObject("statusBar1.SelectImage")));
            this.statusBar1.Size = new System.Drawing.Size(181, 75);
            this.statusBar1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.statusBar1.State = SimpleButtonLib.BaseButton.BtState.Normal;
            this.statusBar1.StringAlignment = SimpleButtonLib.TextBaseButton.Alignment.UpLeft;
            this.statusBar1.TabIndex = 0;
            this.statusBar1.TabStop = false;
            this.statusBar1.Text = "statusBar1 ";
            this.statusBar1.ValueRatio = 70F;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.state3Button1);
            this.Controls.Add(this.statusBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.state3Button1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private StatusBar.StatusBar statusBar1;
        private StateButton.State3Button state3Button1;
    }
}

