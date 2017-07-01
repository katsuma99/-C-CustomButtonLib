namespace WindowsFormsApplication4
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
            this.baseButton1 = new SimpleButtonLib.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.baseButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // baseButton1
            // 
            this.baseButton1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.baseButton1.Image = ((System.Drawing.Image)(resources.GetObject("baseButton1.Image")));
            this.baseButton1.Location = new System.Drawing.Point(86, 61);
            this.baseButton1.Name = "baseButton1";
            this.baseButton1.NormalImage = ((System.Drawing.Image)(resources.GetObject("baseButton1.NormalImage")));
            this.baseButton1.PushedImage = ((System.Drawing.Image)(resources.GetObject("baseButton1.PushedImage")));
            this.baseButton1.SelectImage = ((System.Drawing.Image)(resources.GetObject("baseButton1.SelectImage")));
            this.baseButton1.Size = new System.Drawing.Size(174, 65);
            this.baseButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.baseButton1.TabIndex = 0;
            this.baseButton1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.baseButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.baseButton1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SimpleButtonLib.BaseButton baseButton1;
    }
}

