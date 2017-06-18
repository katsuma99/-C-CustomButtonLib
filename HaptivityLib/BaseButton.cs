using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace SimpleButtonLib
{
    [DefaultProperty("BaseButtonProperty")]
    [DefaultEvent("OnReleaseButtonEvent")]
    public partial class BaseButton : PictureBox
    {
        protected BaseButtonProperty mBaseButtonProperty = new BaseButtonProperty();
        [Category("ボタン"), Description("通常・選択・押下のボタンのイメージ画像")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public BaseButtonProperty BaseButtonProperty
        {
            get { return mBaseButtonProperty; }
            set { mBaseButtonProperty = value; }
        }

        public BaseButton()
        {
            mBaseButtonProperty = new BaseButtonProperty(this);
            InitializeComponent();
            mBaseButtonProperty.State = State.None;
        }

        #region ボタンイベント処理
        [Category("ボタン処理"), Description("ボタンを押下した時に入る処理")]
        public event EventHandler OnPushButtonEvent = (sender, e) => { (sender as BaseButton).BaseButtonProperty.OnPushButton(); };

        [Category("ボタン処理"), Description("ボタンをリリースした時に入る処理")]
        public event EventHandler OnReleaseButtonEvent = (sender, e) => { (sender as BaseButton).BaseButtonProperty.OnReleaseButton(); };

        [Category("ボタン処理"), Description("ボタンに侵入した時に入る処理")]
        public event EventHandler OnEnterButtonEvent = (sender, e) => { (sender as BaseButton).BaseButtonProperty.OnEnterButton(); };

        [Category("ボタン処理"), Description("ボタンから退出した時に入る処理")]
        public event EventHandler OnLeaveButtonEvent = (sender, e) => { (sender as BaseButton).BaseButtonProperty.OnLeaveButton(); };


        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            OnPushButtonEvent(this,EventArgs.Empty);
            base.OnMouseDown(mevent);
        }

        public void OnPushButton()
        {
            OnPushButtonEvent(this, EventArgs.Empty);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            OnReleaseButtonEvent(this,EventArgs.Empty);
            base.OnMouseUp(mevent);
        }

        public void OnReleaseButton()
        {
            OnReleaseButtonEvent(this, EventArgs.Empty);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            OnEnterButtonEvent(this,EventArgs.Empty);
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            OnLeaveButtonEvent(this,EventArgs.Empty);
            base.OnMouseLeave(e);
        }
        #endregion
    }

    public enum State
    {
        None,
        Select,
        Push
    }

    [DefaultProperty("NormalImage")]
    [TypeConverter(typeof(BaseButtonPropertyConverter))]
    public class BaseButtonProperty
    {
        PictureBox mButton = null;
        public BaseButtonProperty(PictureBox pb = null)
        {
            mButton = pb;
            mState = State.None;
            mSelectImage = global::HAPTIVITYLib.Properties.Resources.BtSelect;
            mNormalImage = global::HAPTIVITYLib.Properties.Resources.BtNormal;
            mPushedImage = global::HAPTIVITYLib.Properties.Resources.BtPushed;
        }

        State mState = State.None;
        [DefaultValue(typeof(State), "None")]
        public State State
        {
            get { return mState; }
            set { mState = value; ChangeButtonState(value); }
        }

        protected Image mSelectImage;
        [Description("ボタンを選択した時のイメージ画像")]
        [DefaultValue(null)]
        [NotifyParentProperty(true)] //親のImageにプロパティ変更を通知して更新してもらう
        public Image SelectImage
        {
            get { return mSelectImage; }
            set { mSelectImage = value; ChangeButtonState(State.Select); }
        }

        protected Image mNormalImage;
        [Description("通常のボタンのイメージ画像")]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        public Image NormalImage
        {
            get { return mNormalImage; }
            set { mNormalImage = value; ChangeButtonState(State.None); }
        }

        protected Image mPushedImage;
        [Description("ボタンを押下した時のイメージ画像")]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        public Image PushedImage
        {
            get { return mPushedImage; }
            set { mPushedImage = value; ChangeButtonState(State.Push); }
        }

        void ChangeButtonState(State state)
        {
            if (mButton == null)
                return;

            mState = state;
            switch (state)
            {
                case State.None:
                    mButton.Image = mNormalImage;
                    mButton.Size = mNormalImage.Size;
                    break;
                case State.Select:
                    mButton.Image = mSelectImage;
                    mButton.Size = mSelectImage.Size;
                    break;
                case State.Push:
                    mButton.Image = mPushedImage;
                    mButton.Size = mPushedImage.Size;
                    break;
            }
        }

        #region ボタンイベント処理
        public void OnPushButton()
        {
            mState = State.Push;
            mButton.Image = PushedImage;
        }

        public void OnReleaseButton()
        {
            mState = State.Select;
            mButton.Image = SelectImage;
        }

        public void OnEnterButton()
        {
            mState = State.Select;
            mButton.Image = SelectImage;
        }

        public void OnLeaveButton()
        {
            mState = State.None;
            mButton.Image = NormalImage;
        }
        #endregion
    }

    public class BaseButtonPropertyConverter : ExpandableObjectConverter
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

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            string strValue = value as string;
            if (strValue == null)
                return base.ConvertFrom(context, culture, value);
            string[] values = strValue.Split(',');
            int count = values.Length;
            try
            {
                BaseButtonProperty baseButtonProp = new BaseButtonProperty();
                ImageConverter imageConverter = new ImageConverter();
                if (count < 1 || values[0].Trim().Length == 0)
                    baseButtonProp.SelectImage = global::HAPTIVITYLib.Properties.Resources.BtSelect;
                else
                    baseButtonProp.SelectImage = (Image)imageConverter.ConvertFromString(values[0]);

                if (count < 2 || values[1].Trim().Length == 0)
                    baseButtonProp.NormalImage = global::HAPTIVITYLib.Properties.Resources.BtNormal;
                else
                    baseButtonProp.NormalImage = (Image)imageConverter.ConvertFromString(values[1]);

                if (count < 3 || values[2].Trim().Length == 0)
                    baseButtonProp.PushedImage = global::HAPTIVITYLib.Properties.Resources.BtPushed;
                else
                    baseButtonProp.PushedImage = (Image)imageConverter.ConvertFromString(values[2]);

                return baseButtonProp;
            }
            catch
            {
                throw new ArgumentException("プロパティの値が無効です");
            }
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {

            BaseButtonProperty baseButtonProp = value as BaseButtonProperty;
            if (baseButtonProp == null || destinationType != typeof(string))
                return base.ConvertTo(context, culture, value, destinationType);
            ImageConverter imageConverter = new ImageConverter();
            return string.Format("{0},{1},{2}",
                                 imageConverter.ConvertToString(baseButtonProp.SelectImage),
                                 imageConverter.ConvertToString(baseButtonProp.NormalImage),
                                 imageConverter.ConvertToString(baseButtonProp.PushedImage)
                                 );
        }
    }
}


