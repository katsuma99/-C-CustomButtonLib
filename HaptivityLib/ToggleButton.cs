using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ToggleButton
{
    [DefaultProperty("IsToggleOn")]
    public partial class ToggleButton : UserControl
    {
        #region 変数
        public bool mIsToggleOn = false;
        [Category("カスタム：Off/Onボタンの切り替え"), Description("On/Offボタンを切り替えるフラグ")]
        [DefaultValue(true)]
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

        [Category("カスタム：Onボタンイメージ"), Description("ON時のボタンを選択した時のイメージ画像")]
        public Image OnSelectImage
        {
            get { return mOnSimpleButton.SelectImage; }
            set
            {
                mOnSimpleButton.SelectImage = value;
                ResizeToggleButton();
            }
        }

        [Category("カスタム：Onボタンイメージ"), Description("ON時のボタンのイメージ画像")]
        public Image OnNormalImage
        {
            get { return mOnSimpleButton.NormalImage; }
            set
            {
                mOnSimpleButton.NormalImage = value;
                ResizeToggleButton();
            }
        }

        [Category("カスタム：Onボタンイメージ"), Description("ON時のボタンを押下した時のイメージ画像")]
        public Image OnPushedImage
        {
            get { return mOnSimpleButton.PushedImage; }
            set
            {
                mOnSimpleButton.PushedImage = value;
                ResizeToggleButton();
            }
        }

        [Category("カスタム：Onボタンテキスト"), Description("ON時のボタンに表示させる文字")]
        [DefaultValue("")]
        public string OnText
        {
            get { return mOnSimpleButton.Text; }
            set { mOnSimpleButton.Text = value; }
        }

        [Category("カスタム：Onボタンテキスト"), Description("ON時のボタンに表示させる文字の色")]
        [DefaultValue(typeof(Color), "Aquamarine")]
        public Color OnForeColor
        {
            get { return mOnSimpleButton.ForeColor; }
            set { mOnSimpleButton.ForeColor = value; }
        }

        [Category("カスタム：Onボタンテキスト"), Description("ON時のボタンに表示させる文字フォント")]
        [DefaultValue(typeof(Font), "Arial, 8, style=Bold")]
        public Font OnMyFont
        {
            get { return mOnSimpleButton.Font; }
            set { mOnSimpleButton.Font = value; }
        }

        [Category("カスタム：OnボタンHAPTIVITY"), Description("ON時のHAPTIVITYを使うためには、Interfaceをアタッチする")]
        [DefaultValue(null)]
        public HAPTIVITYLib.Interface OnHaptivity
        {
            get { return mOnSimpleButton.Haptivity; }
            set { mOnSimpleButton.Haptivity = value; }
        }

        [Category("カスタム：OnボタンHAPTIVITY"), Description("ON時の押下時振動のコンフィグ（ボタンを押したときの触感と閾値などの設定番号）")]
        [DefaultValue(0)]
        public int OnConfigNo
        {
            get { return mOnSimpleButton.ConfigNo; }
            set { mOnSimpleButton.ConfigNo = value; }
        }

        [Category("カスタム：OnボタンHAPTIVITY"), Description("ON時の進入時強制振動のコンフィグ")]
        [DefaultValue(0)]
        public int OnEnterConfigNo
        {
            get { return mOnSimpleButton.EnterConfigNo; }
            set { mOnSimpleButton.EnterConfigNo = value; }
        }

        [Category("カスタム：OnボタンHAPTIVITY"), Description("ON時の進入時強制振動の連続振動時間")]
        [DefaultValue(10)]
        public int OnEnterVibrationTime
        {
            get { return mOnSimpleButton.EnterVibrationTime; }
            set { mOnSimpleButton.EnterVibrationTime = value; }
        }


        [Category("カスタム：Offボタンイメージ"), Description("Off時のボタンを選択した時のイメージ画像")]
        public Image OffSelectImage
        {
            get { return mOffSimpleButton.SelectImage; }
            set
            {
                mOffSimpleButton.SelectImage = value;
                ResizeToggleButton();
            }
        }

        [Category("カスタム：Offボタンイメージ"), Description("OFF時のボタンのイメージ画像")]
        public Image OffNormalImage
        {
            get { return mOffSimpleButton.NormalImage; }
            set
            {
                mOffSimpleButton.NormalImage = value;
                ResizeToggleButton();
            }
        }

        [Category("カスタム：Offボタンイメージ"), Description("OFF時のボタンを押下した時のイメージ画像")]
        public Image OffPushedImage
        {
            get { return mOffSimpleButton.PushedImage; }
            set
            {
                mOffSimpleButton.PushedImage = value;
                ResizeToggleButton();
            }
        }

        [Category("カスタム：Offボタンテキスト"), Description("OFF時のボタンに表示させる文字")]
        [DefaultValue("")]
        public string OffText
        {
            get { return mOffSimpleButton.Text; }
            set { mOffSimpleButton.Text = value; }
        }

        [Category("カスタム：Offボタンテキスト"), Description("OFF時のボタンに表示させる文字の色")]
        [DefaultValue(typeof(Color), "White")]
        public Color OffForeColor
        {
            get { return mOffSimpleButton.ForeColor; }
            set { mOffSimpleButton.ForeColor = value; }
        }

        [Category("カスタム：Offボタンテキスト"), Description("OFF時のボタンに表示させる文字フォント")]
        [DefaultValue(typeof(Font), "Arial, 8, style=Bold")]
        public Font OffMyFont
        {
            get { return mOffSimpleButton.Font; }
            set { mOffSimpleButton.Font = value; }
        }

        [Category("カスタム：OffボタンHAPTIVITY"), Description("OFF時のHAPTIVITYを使うためには、Interfaceをアタッチする")]
        [DefaultValue(null)]
        public HAPTIVITYLib.Interface OffHaptivity
        {
            get { return mOffSimpleButton.Haptivity; }
            set { mOffSimpleButton.Haptivity = value; }
        }

        [Category("カスタム：OffボタンHAPTIVITY"), Description("OFF時の押下時振動のコンフィグ（ボタンを押したときの触感と閾値などの設定番号）")]
        [DefaultValue(0)]
        public int OffConfigNo
        {
            get { return mOffSimpleButton.ConfigNo; }
            set { mOffSimpleButton.ConfigNo = value; }
        }

        [Category("カスタム：OffボタンHAPTIVITY"), Description("OFF時の進入時強制振動のコンフィグ")]
        [DefaultValue(0)]
        public int OffEnterConfigNo
        {
            get { return mOffSimpleButton.EnterConfigNo; }
            set { mOffSimpleButton.EnterConfigNo = value; }
        }

        [Category("カスタム：OffボタンHAPTIVITY"), Description("OFF時の進入時強制振動の連続振動時間")]
        [DefaultValue(10)]
        public int OffEnterVibrationTime
        {
            get { return mOffSimpleButton.EnterVibrationTime; }
            set { mOffSimpleButton.EnterVibrationTime = value; }
        }
        #endregion

        //表示されないと呼ばれない（Visible = falseの場合は呼ばれない）コンストラクタで非表示にしたら使えない
        private void ToggleButton_Load(object sender, EventArgs e)
        {
            mOnSimpleButton_OnReleaseButton(this, EventArgs.Empty);
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

        private void ToggleButton_SizeChanged(object sender, EventArgs e)
        {
            ResizeToggleButton();
        }

        void  ResizeToggleButton()
        {
            mOnSimpleButton.Size = this.Size;
            mOffSimpleButton.Size = this.Size;
        }
    }
}
