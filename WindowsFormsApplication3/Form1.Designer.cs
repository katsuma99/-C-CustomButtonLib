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
            this.stateButton1.CustomButton1.InitState = StateButton.BtState.Normal;
            this.stateButton1.CustomButton1.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage")));
            this.stateButton1.CustomButton1.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage")));
            this.stateButton1.CustomButton1.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage")));
            this.stateButton1.CustomButton2.InitState = StateButton.BtState.Normal;
            this.stateButton1.CustomButton2.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage1")));
            this.stateButton1.CustomButton2.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage1")));
            this.stateButton1.CustomButton2.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage1")));
            this.stateButton1.CustomButton3.InitState = StateButton.BtState.Normal;
            this.stateButton1.CustomButton3.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage2")));
            this.stateButton1.CustomButton3.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage2")));
            this.stateButton1.CustomButton3.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage2")));
            this.stateButton1.CustomButton4.InitState = StateButton.BtState.Normal;
            this.stateButton1.CustomButton4.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage3")));
            this.stateButton1.CustomButton4.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage3")));
            this.stateButton1.CustomButton4.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage3")));
            this.stateButton1.CustomButton5.InitState = StateButton.BtState.Normal;
            this.stateButton1.CustomButton5.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage4")));
            this.stateButton1.CustomButton5.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage4")));
            this.stateButton1.CustomButton5.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage4")));
            this.stateButton1.CustomButton6.InitState = StateButton.BtState.Normal;
            this.stateButton1.CustomButton6.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage5")));
            this.stateButton1.CustomButton6.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage5")));
            this.stateButton1.CustomButton6.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage5")));
            this.stateButton1.CustomButton7.InitState = StateButton.BtState.Normal;
            this.stateButton1.CustomButton7.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage6")));
            this.stateButton1.CustomButton7.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage6")));
            this.stateButton1.CustomButton7.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage6")));
            this.stateButton1.CustomButton8.InitState = StateButton.BtState.Normal;
            this.stateButton1.CustomButton8.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage7")));
            this.stateButton1.CustomButton8.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage7")));
            this.stateButton1.CustomButton8.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage7")));
            this.stateButton1.CustomButtonState = 1;
            this.stateButton1.Image = ((System.Drawing.Image)(resources.GetObject("stateButton1.Image")));
            this.stateButton1.Location = new System.Drawing.Point(29, 159);
            this.stateButton1.Name = "stateButton1";
            this.stateButton1.Size = new System.Drawing.Size(88, 78);
            this.stateButton1.StateMax = 1;
            this.stateButton1.TabIndex = 0;
            this.stateButton1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.stateButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.stateButton1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private StateButton.StateButton stateButton1;
    }
}

