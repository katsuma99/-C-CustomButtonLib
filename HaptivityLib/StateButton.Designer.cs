namespace StateButton
{
    partial class StateButton
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
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
            this.SuspendLayout();
            // 
            // StateButton
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::HAPTIVITYLib.Properties.Resources.StateButton;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.DoubleBuffered = true;
            this.Name = "StateButton";
            this.Size = new System.Drawing.Size(100, 50);
            this.Resize += new System.EventHandler(this.StateButton_Resize);
            this.ResumeLayout(false);

        }

        #endregion

    }
}
