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
            this.formSupportUtils1 = new FormSupportLib.FormSupportUtils();
            this.SuspendLayout();
            // 
            // formSupportUtils1
            // 
            this.formSupportUtils1.BackColor = System.Drawing.Color.Transparent;
            this.formSupportUtils1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("formSupportUtils1.BackgroundImage")));
            this.formSupportUtils1.Location = new System.Drawing.Point(192, 219);
            this.formSupportUtils1.Name = "formSupportUtils1";
            this.formSupportUtils1.Size = new System.Drawing.Size(32, 32);
            this.formSupportUtils1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(551, 399);
            this.Controls.Add(this.formSupportUtils1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(551, 399);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private FormSupportLib.FormSupportUtils formSupportUtils1;
    }
}

