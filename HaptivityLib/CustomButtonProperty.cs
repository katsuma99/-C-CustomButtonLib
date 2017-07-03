using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CustomProperty
{
    using aRecive = HAPTIVITYLib.Interface.RECEIVE_HAPTIVITY_STATE;
    public enum BtState
    {
        Normal,
        Select,
        Pushed
    }

    [DefaultProperty("NormalImage")]
    [TypeConverter(typeof(CustomButtonPropertyConverter))]
    public class CustomButtonProperty : ICloneable
    {
        #region 変数
        PictureBox mButton = null;
        [Browsable(false)]
        public PictureBox Button
        {
            get { return mButton; }
            set { mButton = value;}
        }

        #region ボタン画像
        protected List<Image> mButtonImage;
        Image mOriNormalImage = null;
        [Description("通常のボタンのイメージ画像")]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]    //親のImageにプロパティ変更を通知して更新してもらう
        public Image NormalImage
        {
            get { return mButtonImage[(int)BtState.Normal]; }
            set
            {
                if (value == null) return; mButtonImage[(int)BtState.Normal] = value;
                mOriNormalImage = (Image)value.Clone(); ChangeButton(BtState.Normal);
                //リサイズ用にフォントとボタンのサイズ比率記録
                if (mFont != null && mText.Length != 0)
                    mTextScale = mFont.Size * mText.Length / NormalImage.Size.Width;
            }
        }

        Image mOriSelectlImage = null;
        [Description("ボタンを選択した時のイメージ画像")]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        public Image SelectImage
        {
            get { return mButtonImage[(int)BtState.Select]; }
            set
            {
                if (value == null) return; mButtonImage[(int)BtState.Select] = value;
                mOriSelectlImage = (Image)value.Clone(); ChangeButton(BtState.Select);
            }
        }

        Image mOriPushedImage = null;
        [Description("ボタンを押下した時のイメージ画像")]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        public Image PushedImage
        {
            get { return mButtonImage[(int)BtState.Pushed]; }
            set
            {
                if (value == null) return; mButtonImage[(int)BtState.Pushed] = value;
                mOriPushedImage = (Image)value.Clone(); ChangeButton(BtState.Pushed);
            }
        }
        #endregion

        #region ボタンテキスト
        protected string mText;
        [Description("ボタンに表示させる文字")]
        [DefaultValue("StateButton")]
        public string MyText
        {
            get
            {
                return mText;
            }
            set
            {
                mText = value;
                if (mButton == null)
                    return;
                mButton.Invalidate();
            }
        }

        protected Color mForeColor = Color.White;
        [DefaultValue(typeof(Color), "White")]
        [Description("ボタンに表示させる文字の色")]
        public Color MyForeColor
        {
            get
            {
                return mForeColor;
            }
            set
            {
                mForeColor = value;
                if (mButton != null) mButton.Invalidate();
            }
        }

        float mTextScale = -1;
        protected Font mFont;
        [Description("ボタンに表示させる文字フォント")]
        public Font MyFont
        {
            get
            {
                return mFont;
            }
            set
            {
                mFont = value;
                if (mButton == null) return;

                mButton.Invalidate();
            }
        }
        #endregion

        #region　HAPTIVITY
        protected HAPTIVITYLib.Interface mHaptivity = null;
        [DefaultValue(null)]
        [Description("HAPTIVITYを使うためには、Interfaceをアタッチする")]
        public HAPTIVITYLib.Interface Haptivity
        {
            get { return mHaptivity; }
            set { mHaptivity = value; }
        }

        protected int mConfigNo = 0;
        [DefaultValue(0)]
        [Description("押下時振動のコンフィグ（ボタンを押したときの触感と閾値などの設定番号）")]
        public int HapConfigNo
        {
            get { return mConfigNo; }
            set { mConfigNo = value; }
        }

        protected int mEnterConfigNo = 0;
        [Description("進入時強制振動のコンフィグ")]
        [DefaultValue(0)]
        public int HapEnterConfigNo
        {
            get { return mEnterConfigNo; }
            set { mEnterConfigNo = value; }
        }

        protected int mEnterVibrationTime = 10;
        [Description("進入時強制振動の連続振動時間")]
        [DefaultValue(10)]
        public int HapEnterVibrationTime
        {
            get { return mEnterVibrationTime; }
            set { mEnterVibrationTime = value; }
        }

        private System.Windows.Forms.Timer receiveDataTime;
        #endregion
        #endregion

        public CustomButtonProperty(PictureBox pb = null)
        {
            Button = pb;
            InitImage();
            InitText();
            InitHaptivity();
        }

        void InitImage()
        {
            if (mButtonImage != null)
                return;
            mButtonImage = new List<Image>();
            mButtonImage.Add(global::HAPTIVITYLib.Properties.Resources.BtNormal);
            mOriNormalImage = (Image)mButtonImage[0].Clone();
            mButtonImage.Add(global::HAPTIVITYLib.Properties.Resources.BtSelect);
            mOriSelectlImage = (Image)mButtonImage[1].Clone();
            mButtonImage.Add(global::HAPTIVITYLib.Properties.Resources.BtPushed);
            mOriPushedImage = (Image)mButtonImage[2].Clone();
            ChangeButton(BtState.Normal);
        }

        void InitText()
        {
            mText = "StateButton";
            mFont = new Font("Arial", 8, FontStyle.Bold);
        }

        void InitHaptivity()
        {
            if (mHaptivity == null)
                return;

            this.receiveDataTime.Interval = 1;
            this.receiveDataTime.Tick += new System.EventHandler(this.receiveDataTime_Tick);
        }

        ~CustomButtonProperty()
        {
            SelectImage?.Dispose();
            NormalImage?.Dispose();
            PushedImage?.Dispose();
            mFont?.Dispose();
        }

        public void ChangeButton(BtState state)
        {
            if (Button == null || mButtonImage == null || NormalImage == null || SelectImage == null || PushedImage == null)
                return;

            switch (state)
            {
                case BtState.Normal:
                    Button.Image = NormalImage;
                    Button.Size = NormalImage.Size;
                    break;
                case BtState.Select:
                    Button.Image = SelectImage;
                    Button.Size = SelectImage.Size;
                    break;
                case BtState.Pushed:
                    Button.Image = PushedImage;
                    Button.Size = PushedImage.Size;
                    break;
            }
            Button.Refresh();
        }

        public void ResizeImage(Size size)
        {
            if (mOriNormalImage == null)
                return;
            for (int state = 0; state < mButtonImage.Count; state++)
            {
                switch (state)
                {
                    case (int)BtState.Normal:
                        mButtonImage[state] = new Bitmap(mOriNormalImage, size);
                        break;
                    case (int)BtState.Select:
                        mButtonImage[state] = new Bitmap(mOriSelectlImage, size);
                        break;
                    case (int)BtState.Pushed:
                        mButtonImage[state] = new Bitmap(mOriPushedImage, size);
                        break;
                }

            if(mButton != null && mTextScale != -1) mFont = new Font(mFont.FontFamily, mButton.Size.Width * mTextScale / mText.Length, mFont.Style);
            }
        }

        public object Clone()
        {
            CustomButtonProperty work = new CustomButtonProperty(Button);
            work = (CustomButtonProperty)this.MemberwiseClone();
            work.NormalImage = (Image)this.NormalImage.Clone();
            work.SelectImage = (Image)this.SelectImage.Clone();
            work.PushedImage = (Image)this.PushedImage.Clone();
            return work;
        }

        #region イベント処理
        #region ボタンイベント処理
        public void OnPushButton()
        {
            if (Button == null) return;
            Button.Image = PushedImage;
        }

        public void OnReleaseButton()
        {
            if (Button == null) return;
            Button.Image = SelectImage;
        }

        public void OnEnterButton()
        {
            if (Button == null) return;
            Button.Image = SelectImage;
            if (mHaptivity != null)
            {
                mHaptivity.EnterVibration(mConfigNo, mEnterConfigNo, mEnterVibrationTime);
                receiveDataTime.Enabled = true;
            }
        }

        public void OnLeaveButton()
        {
            if (Button == null) return;
            Button.Image = NormalImage;
            if (mHaptivity != null)
            {
                mHaptivity.LeaveVibration();
                receiveDataTime.Enabled = false;
            }
        }

        //定期的にHAPTIVITYICからコマンドが受信されていないか確認する
        private void receiveDataTime_Tick(object sender, EventArgs e)
        {
            switch (mHaptivity.DataReceived())
            {
                case aRecive.PUSH:
                    OnPushButton();
                    break;
                case aRecive.RELEASE:
                    OnReleaseButton();
                    break;
            }
        }
        #endregion

        public void OnPaint(PaintEventArgs pe)
        {
            using (Brush brush = new SolidBrush(mForeColor))
            {
                StringFormat strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Center;
                strFormat.LineAlignment = StringAlignment.Center;
                pe.Graphics.DrawString(mText, mFont, brush, new RectangleF(new Point(0, 0), mButton.Size), strFormat);
            }
        }
        #endregion
    }

    public class CustomButtonPropertyConverter : ExpandableObjectConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;
            else
                return base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
                return true;
            else
                return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {

            CustomButtonProperty baseButtonProp = value as CustomButtonProperty;
            if (baseButtonProp == null || destinationType != typeof(string))
                return base.ConvertTo(context, culture, value, destinationType);

            if (baseButtonProp.Button == null)
                return string.Format("Out of Range");
            else
                return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
