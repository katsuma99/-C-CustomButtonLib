using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SimpleButtonLib;

namespace ToggleButton
{
    public partial class ToggleButton : UserControl
    {
        public bool mIsToggleOn = false;
        [Category("ボタンイメージ"), Description("OFF時のsimpleButton設定")]
        public bool IsToggleOn
        {
            get
            {
                return mIsToggleOn;
            }
            set
            {
                if (value)
                    mOffSimpleButton_OnReleaseButton(this, EventArgs.Empty);
                else
                    mOnSimpleButton_OnReleaseButton(this, EventArgs.Empty);
            }
        }

        //[Category("ボタンイメージ"), Description("ON時のsimpleButton設定")]
        //public SimpleButton OnSimpleButton
        //{
        //    get
        //    {
        //        return mOnSimpleButton;
        //    }
        //    set
        //    {
        //        if(mOnSimpleButton != null) mOnSimpleButton.Dispose();
        //        if (value == null)
        //            return;
        //        mOnSimpleButton = value;
        //        mOnSimpleButton.OnReleaseButton += new EventHandler(mOnSimpleButton_OnReleaseButton);
        //    }
        //}

        [Category("ボタンイメージ"), Description("OFF時のsimpleButton設定")]
        public SimpleButton OffSimpleButton
        {
            get
            {
                return mOffSimpleButton;
            }
            set
            {
                mOffSimpleButton.Dispose();
                mOffSimpleButton = value;
                mOffSimpleButton.OnReleaseButton += new EventHandler(mOffSimpleButton_OnReleaseButton);
            }
        }



        [Category("On時のボタンイメージ"), Description("ON時のボタンを選択した時のイメージ画像")]
        public Image OnSelectImage
        {
            get { return mOnSimpleButton.SelectImage; }
            set
            {
                mOnSimpleButton.SelectImage = value;
                this.Size = mOnSimpleButton.SelectImage.Size;
            }
        }

        [Category("On時のボタンイメージ"), Description("ON時のボタンのイメージ画像")]
        public Image OnNormalImage
        {
            get { return mOnSimpleButton.NormalImage; }
            set
            {
                mOnSimpleButton.NormalImage = value;
                this.Size = mOnSimpleButton.NormalImage.Size;
            }
        }

        [Category("On時のボタンイメージ"), Description("ON時のボタンを押下した時のイメージ画像")]
        public Image OnPushedImage
        {
            get { return mOnSimpleButton.PushedImage; }
            set
            {
                mOnSimpleButton.PushedImage = value;
                this.Size = mOnSimpleButton.PushedImage.Size;
            }
        }

        [Category("On時のボタンイメージ"), Description("ボタンに表示させる文字")]
        public override string Text
        {
            get { return mOnSimpleButton.Text; }
            set { mOnSimpleButton.Text = value; }
        }

        [Category("On時のボタンイメージ"), Description("ボタンに表示させる文字の色")]
        [DefaultValue(typeof(Color), "Aquamarine")]
        public override Color ForeColor
        {
            get { return mOnSimpleButton.ForeColor; }
            set { mOnSimpleButton.ForeColor = value; }
        }

        [Category("On時のボタンイメージ"), Description("ボタンに表示させる文字フォント")]
        public Font MyFont
        {
            get { return mOnSimpleButton.Font; }
            set { mOnSimpleButton.Font = value; }
        }

        [Category("On時のHAPTIVITY"), Description("HAPTIVITYを使うためには、Interfaceをアタッチする")]
        public HAPTIVITYLib.Interface Haptivity
        {
            get { return mOnSimpleButton.Haptivity; }
            set { mOnSimpleButton.Haptivity = value; }
        }

        [Category("On時のHAPTIVITY"), Description("押下時振動のコンフィグ（ボタンを押したときの触感と閾値などの設定番号）")]
        public int ConfigNo
        {
            get { return mOnSimpleButton.ConfigNo; }
            set { mOnSimpleButton.ConfigNo = value; }
        }

        [Category("On時のHAPTIVITY"), Description("進入時強制振動のコンフィグ")]
        public int EnterConfigNo
        {
            get { return mOnSimpleButton.EnterConfigNo; }
            set { mOnSimpleButton.EnterConfigNo = value; }
        }

        [Category("On時のHAPTIVITY"), Description("進入時強制振動の連続振動時間")]
        public int EnterVibrationTime
        {
            get { return mOnSimpleButton.EnterVibrationTime; }
            set { mOnSimpleButton.EnterVibrationTime = value; }
        }

        //表示されないと呼ばれない（Visible = falseの場合は呼ばれない）コンストラクタで非表示にしたら使えない
        private void ToggleButton_Load(object sender, EventArgs e)
        {
            mOnSimpleButton_OnReleaseButton(this, EventArgs.Empty);
            Size size = new Size();
            size.Width = Math.Max(mOnSimpleButton.NormalImage.Size.Width, mOffSimpleButton.NormalImage.Width);
            size.Height = Math.Max(mOnSimpleButton.NormalImage.Size.Height, mOffSimpleButton.NormalImage.Height);
            this.Size = size;
        }

        public ToggleButton()
        {
            InitializeComponent();
        }

        private void mOffSimpleButton_OnReleaseButton(object sender, EventArgs e)
        {
            mIsToggleOn = true;
            mOnSimpleButton.Show();
            mOffSimpleButton.Hide();
        }

        private void mOnSimpleButton_OnReleaseButton(object sender, EventArgs e)
        {
            mIsToggleOn = false;
            mOnSimpleButton.Hide();
            mOffSimpleButton.Show();
        }
    }
}
