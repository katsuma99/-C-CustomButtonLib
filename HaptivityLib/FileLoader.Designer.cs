namespace StatusBar
{
    partial class FileLoader
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label_DL = new System.Windows.Forms.Label();
            this.label_Question = new System.Windows.Forms.Label();
            this.button_YES = new System.Windows.Forms.Button();
            this.button_NO = new System.Windows.Forms.Button();
            this.textBox_Config = new System.Windows.Forms.TextBox();
            this.reference = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(8, 83);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(272, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // label_DL
            // 
            this.label_DL.AutoSize = true;
            this.label_DL.Location = new System.Drawing.Point(96, 115);
            this.label_DL.Name = "label_DL";
            this.label_DL.Size = new System.Drawing.Size(87, 12);
            this.label_DL.TabIndex = 1;
            this.label_DL.Text = "Downloading・・・";
            this.label_DL.Visible = false;
            // 
            // label_Question
            // 
            this.label_Question.AutoSize = true;
            this.label_Question.Location = new System.Drawing.Point(10, 10);
            this.label_Question.Name = "label_Question";
            this.label_Question.Size = new System.Drawing.Size(161, 12);
            this.label_Question.TabIndex = 2;
            this.label_Question.Text = "Do you download Config file？";
            // 
            // button_YES
            // 
            this.button_YES.Location = new System.Drawing.Point(45, 52);
            this.button_YES.Name = "button_YES";
            this.button_YES.Size = new System.Drawing.Size(75, 23);
            this.button_YES.TabIndex = 3;
            this.button_YES.Text = "Yes";
            this.button_YES.UseVisualStyleBackColor = true;
            this.button_YES.Click += new System.EventHandler(this.button_YES_Click);
            // 
            // button_NO
            // 
            this.button_NO.Location = new System.Drawing.Point(180, 52);
            this.button_NO.Name = "button_NO";
            this.button_NO.Size = new System.Drawing.Size(75, 23);
            this.button_NO.TabIndex = 4;
            this.button_NO.Text = "No";
            this.button_NO.UseVisualStyleBackColor = true;
            this.button_NO.Click += new System.EventHandler(this.button_NO_Click);
            // 
            // textBox_Config
            // 
            this.textBox_Config.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_Config.Location = new System.Drawing.Point(26, 25);
            this.textBox_Config.Name = "textBox_Config";
            this.textBox_Config.Size = new System.Drawing.Size(199, 20);
            this.textBox_Config.TabIndex = 5;
            // 
            // reference
            // 
            this.reference.Location = new System.Drawing.Point(234, 23);
            this.reference.Name = "reference";
            this.reference.Size = new System.Drawing.Size(39, 23);
            this.reference.TabIndex = 6;
            this.reference.Text = "ref";
            this.reference.UseVisualStyleBackColor = true;
            this.reference.Click += new System.EventHandler(this.reference_Click);
            // 
            // FileLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 106);
            this.Controls.Add(this.reference);
            this.Controls.Add(this.textBox_Config);
            this.Controls.Add(this.button_NO);
            this.Controls.Add(this.button_YES);
            this.Controls.Add(this.label_Question);
            this.Controls.Add(this.label_DL);
            this.Controls.Add(this.progressBar1);
            this.Name = "FileLoader";
            this.Load += new System.EventHandler(this.FileLoader_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label_DL;
        private System.Windows.Forms.Label label_Question;
        private System.Windows.Forms.Button button_YES;
        private System.Windows.Forms.Button button_NO;
        private System.Windows.Forms.TextBox textBox_Config;
        private System.Windows.Forms.Button reference;
    }
}
