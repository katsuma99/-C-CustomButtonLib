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
            this.statusBar1 = new StatusBar.StatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.statusBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.BarMaxRatio = StatusBar.StatusBar.Number0To100._77;
            this.statusBar1.BarMinRatio = StatusBar.StatusBar.Number0To100._11;
            this.statusBar1.BarNowValueRatio = StatusBar.StatusBar.Number0To100._100;
            this.statusBar1.DivisionNum = StatusBar.StatusBar.Number0To100._7;
            this.statusBar1.ForeColor = System.Drawing.Color.Black;
            this.statusBar1.FrontColor = System.Drawing.Color.DarkRed;
            this.statusBar1.FrontGradationColor = System.Drawing.Color.Aqua;
            this.statusBar1.Image = ((System.Drawing.Image)(resources.GetObject("statusBar1.Image")));
            this.statusBar1.IsAdjustMode = true;
            this.statusBar1.IsDirect = true;
            this.statusBar1.Location = new System.Drawing.Point(76, 179);
            this.statusBar1.MyFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.NormalImage = ((System.Drawing.Image)(resources.GetObject("statusBar1.NormalImage")));
            this.statusBar1.PushedImage = ((System.Drawing.Image)(resources.GetObject("statusBar1.PushedImage")));
            this.statusBar1.SelectImage = ((System.Drawing.Image)(resources.GetObject("statusBar1.SelectImage")));
            this.statusBar1.Size = new System.Drawing.Size(128, 64);
            this.statusBar1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.statusBar1.State = SimpleButtonLib.BaseButton.BtState.Normal;
            this.statusBar1.StringAlignment = SimpleButtonLib.TextBaseButton.Alignment.UpLeft;
            this.statusBar1.TabIndex = 0;
            this.statusBar1.TabStop = false;
            this.statusBar1.Text = "statusBar1";
            this.statusBar1.TextBaseNum = 0;
            this.statusBar1.TextStepNum = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.statusBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statusBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private StatusBar.StatusBar statusBar1;
    }
}

