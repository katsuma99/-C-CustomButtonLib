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
            this.stateButton1 = new StateButton.StateButton();
            ((System.ComponentModel.ISupportInitialize)(this.stateButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // stateButton1
            // 
            this.stateButton1.BackColor = System.Drawing.Color.Transparent;
            this.stateButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("stateButton1.BackgroundImage")));
            this.stateButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.stateButton1.Button1.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage")));
            this.stateButton1.Button1.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage")));
            this.stateButton1.Button1.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage")));
            this.stateButton1.Button2.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage1")));
            this.stateButton1.Button2.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage1")));
            this.stateButton1.Button2.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage1")));
            this.stateButton1.Button3.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage2")));
            this.stateButton1.Button3.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage2")));
            this.stateButton1.Button3.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage2")));
            this.stateButton1.Button4.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage3")));
            this.stateButton1.Button4.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage3")));
            this.stateButton1.Button4.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage3")));
            this.stateButton1.Button5.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage4")));
            this.stateButton1.Button5.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage4")));
            this.stateButton1.Button5.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage4")));
            this.stateButton1.Button6.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage5")));
            this.stateButton1.Button6.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage5")));
            this.stateButton1.Button6.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage5")));
            this.stateButton1.Button7.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage6")));
            this.stateButton1.Button7.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage6")));
            this.stateButton1.Button7.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage6")));
            this.stateButton1.Button8.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage7")));
            this.stateButton1.Button8.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage7")));
            this.stateButton1.Button8.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage7")));
            this.stateButton1.Image = ((System.Drawing.Image)(resources.GetObject("stateButton1.Image")));
            this.stateButton1.InitState = StateButton.BtState.Normal;
            this.stateButton1.Location = new System.Drawing.Point(48, 69);
            this.stateButton1.Name = "stateButton1";
            this.stateButton1.Size = new System.Drawing.Size(120, 48);
            this.stateButton1.State = StateButton.StateButton.SBtState.Button3;
            this.stateButton1.StateMax = 4;
            this.stateButton1.TabIndex = 0;
            this.stateButton1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.stateButton1);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stateButton1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private StateButton.StateButton stateButton1;
    }
}

