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
            this.toggleButton1 = new ToggleButton.ToggleButton();
            this.formSupportUtils1 = new FormSupportLib.FormSupportUtils();
            this.SuspendLayout();
            // 
            // toggleButton1
            // 
            this.toggleButton1.BackColor = System.Drawing.Color.Transparent;
            this.toggleButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toggleButton1.BackgroundImage")));
            this.toggleButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toggleButton1.IsToggleOn = false;
            this.toggleButton1.Location = new System.Drawing.Point(23, 60);
            this.toggleButton1.Name = "toggleButton1";
            this.toggleButton1.OffNormalImage = ((System.Drawing.Image)(resources.GetObject("toggleButton1.OffNormalImage")));
            this.toggleButton1.OffPushedImage = ((System.Drawing.Image)(resources.GetObject("toggleButton1.OffPushedImage")));
            this.toggleButton1.OffSelectImage = ((System.Drawing.Image)(resources.GetObject("toggleButton1.OffSelectImage")));
            this.toggleButton1.OffState = SimpleButtonLib.BaseButton.BtState.Normal;
            this.toggleButton1.OffText = "toggleButtonOff";
            this.toggleButton1.OnNormalImage = ((System.Drawing.Image)(resources.GetObject("toggleButton1.OnNormalImage")));
            this.toggleButton1.OnPushedImage = ((System.Drawing.Image)(resources.GetObject("toggleButton1.OnPushedImage")));
            this.toggleButton1.OnSelectImage = ((System.Drawing.Image)(resources.GetObject("toggleButton1.OnSelectImage")));
            this.toggleButton1.OnState = SimpleButtonLib.BaseButton.BtState.Normal;
            this.toggleButton1.OnText = "toggleButtonOn";
            this.toggleButton1.Size = new System.Drawing.Size(100, 50);
            this.toggleButton1.TabIndex = 1;
            // 
            // formSupportUtils1
            // 
            this.formSupportUtils1.BackColor = System.Drawing.Color.Transparent;
            this.formSupportUtils1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("formSupportUtils1.BackgroundImage")));
            this.formSupportUtils1.Location = new System.Drawing.Point(130, 190);
            this.formSupportUtils1.Name = "formSupportUtils1";
            this.formSupportUtils1.Size = new System.Drawing.Size(32, 32);
            this.formSupportUtils1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.formSupportUtils1);
            this.Controls.Add(this.toggleButton1);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private ToggleButton.ToggleButton toggleButton1;
        private FormSupportLib.FormSupportUtils formSupportUtils1;
    }
}

