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

        [Category("ボタンイメージ"), Description("ON時のsimpleButton設定")]
        public SimpleButton OnSimpleButton
        {
            get
            {
                return mOnSimpleButton;
            }
            set
            {
                if(mOnSimpleButton != null) mOnSimpleButton.Dispose();
                if (value == null)
                    return;
                mOnSimpleButton = value;
                mOnSimpleButton.OnReleaseButton += new EventHandler(mOnSimpleButton_OnReleaseButton);
            }
        }

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



        //[Category("On時のボタンイメージ"), Description("ON時のボタンを選択した時のイメージ画像")]
        //public Image OnSelectImage
        //{
        //    get { return mOnSimpleButton.SelectImage; }
        //    set { mOnSimpleButton.SelectImage = value; }
        //}

        //[Category("ボタンイメージ"), Description("ON時のボタンのイメージ画像")]
        //public Image OnNormalImage
        //{
        //    get { return mOnSimpleButton.NormalImage; }
        //    set { mOnSimpleButton.NormalImage = value; }
        //}

        //[Category("ボタンイメージ"), Description("ON時のボタンを押下した時のイメージ画像")]
        //public Image OnPushedImage
        //{
        //    get { return mOnSimpleButton.PushedImage; }
        //    set { mOnSimpleButton.PushedImage = value; }
        //}

        //表示されないと呼ばれない（Visible = falseの場合は呼ばれない）コンストラクタで非表示にしたら使えない
        private void ToggleButton_Load(object sender, EventArgs e)
        {
            if (DesignMode) //フォームデザイン時は設定しない[bug]
                return;

            this.Visible = false;
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
    }
}
