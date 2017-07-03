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
            this.state3Button1 = new State3Button.State3Button();
            this.formSupportUtils1 = new FormSupportLib.FormSupportUtils();
            this.state5Button1 = new State5Button.State5Button();
            ((System.ComponentModel.ISupportInitialize)(this.state3Button1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.state5Button1)).BeginInit();
            this.SuspendLayout();
            // 
            // state3Button1
            // 
            this.state3Button1.BackColor = System.Drawing.Color.Transparent;
            this.state3Button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("state3Button1.BackgroundImage")));
            this.state3Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.state3Button1.Button1.Button = this.state3Button1;
            this.state3Button1.Button1.MyFont = new System.Drawing.Font("Bauhaus 93", 14F, System.Drawing.FontStyle.Bold);
            this.state3Button1.Button1.MyForeColor = System.Drawing.Color.Aquamarine;
            this.state3Button1.Button1.MyText = "State  Button";
            this.state3Button1.Button1.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage")));
            this.state3Button1.Button1.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage")));
            this.state3Button1.Button1.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage")));
            this.state3Button1.Button2.Button = this.state3Button1;
            this.state3Button1.Button2.MyFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.state3Button1.Button2.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage1")));
            this.state3Button1.Button2.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage1")));
            this.state3Button1.Button2.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage1")));
            this.state3Button1.Button3.Button = this.state3Button1;
            this.state3Button1.Button3.MyFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.state3Button1.Button3.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage2")));
            this.state3Button1.Button3.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage2")));
            this.state3Button1.Button3.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage2")));
            this.state3Button1.Image = ((System.Drawing.Image)(resources.GetObject("state3Button1.Image")));
            this.state3Button1.InitState = CustomProperty.BtState.Normal;
            this.state3Button1.Location = new System.Drawing.Point(45, 36);
            this.state3Button1.Name = "state3Button1";
            this.state3Button1.Size = new System.Drawing.Size(91, 65);
            this.state3Button1.State = State3Button.State3Button.SBtState.Button3;
            this.state3Button1.StateMax = 3;
            this.state3Button1.TabIndex = 0;
            this.state3Button1.TabStop = false;
            // 
            // formSupportUtils1
            // 
            this.formSupportUtils1.BackColor = System.Drawing.Color.Transparent;
            this.formSupportUtils1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("formSupportUtils1.BackgroundImage")));
            this.formSupportUtils1.Location = new System.Drawing.Point(160, 163);
            this.formSupportUtils1.Name = "formSupportUtils1";
            this.formSupportUtils1.Size = new System.Drawing.Size(32, 32);
            this.formSupportUtils1.TabIndex = 1;
            // 
            // state5Button1
            // 
            this.state5Button1.BackColor = System.Drawing.Color.Transparent;
            this.state5Button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("state5Button1.BackgroundImage")));
            this.state5Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.state5Button1.Button1.Button = this.state5Button1;
            this.state5Button1.Button1.MyFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.state5Button1.Button1.MyForeColor = System.Drawing.Color.Aquamarine;
            this.state5Button1.Button1.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage3")));
            this.state5Button1.Button1.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage3")));
            this.state5Button1.Button1.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage3")));
            this.state5Button1.Button2.Button = this.state5Button1;
            this.state5Button1.Button2.MyFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.state5Button1.Button2.MyForeColor = System.Drawing.Color.Red;
            this.state5Button1.Button2.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage4")));
            this.state5Button1.Button2.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage4")));
            this.state5Button1.Button2.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage4")));
            this.state5Button1.Button3.Button = this.state5Button1;
            this.state5Button1.Button3.MyFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.state5Button1.Button3.MyForeColor = System.Drawing.Color.GreenYellow;
            this.state5Button1.Button3.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage5")));
            this.state5Button1.Button3.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage5")));
            this.state5Button1.Button3.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage5")));
            this.state5Button1.Button4.Button = this.state5Button1;
            this.state5Button1.Button4.MyFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.state5Button1.Button4.MyForeColor = System.Drawing.Color.DodgerBlue;
            this.state5Button1.Button4.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage6")));
            this.state5Button1.Button4.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage6")));
            this.state5Button1.Button4.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage6")));
            this.state5Button1.Button5.Button = this.state5Button1;
            this.state5Button1.Button5.MyFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.state5Button1.Button5.MyForeColor = System.Drawing.Color.DeepPink;
            this.state5Button1.Button5.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage7")));
            this.state5Button1.Button5.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage7")));
            this.state5Button1.Button5.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage7")));
            this.state5Button1.Image = ((System.Drawing.Image)(resources.GetObject("state5Button1.Image")));
            this.state5Button1.InitState = CustomProperty.BtState.Normal;
            this.state5Button1.Location = new System.Drawing.Point(45, 201);
            this.state5Button1.Name = "state5Button1";
            this.state5Button1.Size = new System.Drawing.Size(41, 48);
            this.state5Button1.State = State5Button.State5Button.SBtState.Button5;
            this.state5Button1.StateMax = 5;
            this.state5Button1.TabIndex = 2;
            this.state5Button1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.state5Button1);
            this.Controls.Add(this.formSupportUtils1);
            this.Controls.Add(this.state3Button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.state3Button1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.state5Button1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private State3Button.State3Button state3Button1;
        private FormSupportLib.FormSupportUtils formSupportUtils1;
        private State5Button.State5Button state5Button1;
    }
}

