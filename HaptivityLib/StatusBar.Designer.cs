namespace StatusBar
{
    partial class StatusBar
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatusBar));
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // StatusBar
            // 
            this.Image = ((System.Drawing.Image)(resources.GetObject("$this.Image")));
            this.NormalImage = ((System.Drawing.Image)(resources.GetObject("$this.NormalImage")));
            this.PushedImage = global::HAPTIVITYLib.Properties.Resources.AIRDIR_Frame;
            this.SelectImage = global::HAPTIVITYLib.Properties.Resources.AIRDIR_Frame_2;
            this.Size = new System.Drawing.Size(128, 64);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.StatusBar_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
