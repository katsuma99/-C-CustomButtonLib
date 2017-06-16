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
                mOnSimpleButton = value;
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
                mOffSimpleButton = value;
            }
        }

        public ToggleButton()
        {
            InitializeComponent();
            mIsToggleOn = false;
            mOffSimpleButton.Show();
            mOnSimpleButton.Hide();
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
