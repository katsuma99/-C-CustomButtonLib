﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using SimpleButtonLib;
using System.Linq;

namespace StateButton
{
    [DefaultProperty("CustomButton")]
    public partial class StateButton : PictureBox
    {
        List<CustomButtonProperty> mCustomButtonList;
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        //public IEnumerable<CustomButtonProperty> CustomButtonList
        //{
        //    get { foreach (var item in mCustomButtonList) yield return item; }
        //    set { foreach (var item in value.Select((s,i) => new { i,s })) mCustomButtonList[item.i] = item.s; }
        //}

        public StateButton()
        {
            InitializeComponent();
            //StateButtonを初めにフォームに張った時
            if (mCustomButtonList == null)
            {
                mCustomButtonList = new List<CustomButtonProperty>();
                mCustomButtonList.Add(new CustomButtonProperty(this));
            }
        }

        [Category("カスタムステートボタン"), Description("通常・選択・押下のボタンのイメージ画像")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CustomButtonProperty CustomButton
        {
            get { return mCustomButtonList[mCustomButtonState]; }
            set { mCustomButtonList[mCustomButtonState] = value; }
        }

        public int mCustomButtonState = 0;
        [Category("カスタムステートボタンの状態"), Description("ステートボタンの状態（現在の状態のボタンが編集できる）")]
        [NotifyParentProperty(true)]    //親のImageにプロパティ変更を通知して更新してもらう
        [DefaultValue(0)]
        public int CustomButtonState
        {
            get
            {
                return mCustomButtonState + 1;
            }
            set
            {
                mCustomButtonState = Math.Max(1, Math.Min(mCustomButtonList.Count, value)) - 1;
                mCustomButtonList[mCustomButtonState].DrawButtonNowState();
            }
        }

        [Category("カスタムステートボタンの状態"), Description("ステートボタンのパターン数(max:8)")]
        [NotifyParentProperty(true)]    //親のImageにプロパティ変更を通知して更新してもらう
        [DefaultValue(0)]
        public int StateMax
        {
            get
            {
                return mCustomButtonList.Count;
            }
            set
            {
                
                int addList = value - mCustomButtonList.Count;
                if(addList > 0)
                {
                    for (int i = 0; i < addList; i++)
                        mCustomButtonList.Add(new CustomButtonProperty(this));
                }
                else
                {
                    for (int i = 0; i > addList; i--)
                        mCustomButtonList.RemoveAt(mCustomButtonList.Count - 1);
                }
            }
        }



        //[Category("HAPTIVITY"), Description("現在の状態でのHAPTIVITYを使うためには、Interfaceをアタッチする")]
        //[DefaultValue(null)]
        //public HAPTIVITYLib.Interface OnHaptivity
        //{
        //    get { return mSimpleButtonList[mCustomButtonState].Haptivity; }
        //    set { mSimpleButtonList[mCustomButtonState].Haptivity = value; }
        //}

        //[Category("HAPTIVITY"), Description("現在の状態での押下時振動のコンフィグ（ボタンを押したときの触感と閾値などの設定番号）")]
        //[DefaultValue(0)]
        //public int OnConfigNo
        //{
        //    get { return mSimpleButtonList[mCustomButtonState].ConfigNo; }
        //    set { mSimpleButtonList[mCustomButtonState].ConfigNo = value; }
        //}

        //[Category("HAPTIVITY"), Description("現在の状態での進入時強制振動のコンフィグ")]
        //[DefaultValue(0)]
        //public int OnEnterConfigNo
        //{
        //    get { return mSimpleButtonList[mCustomButtonState].EnterConfigNo; }
        //    set { mSimpleButtonList[mCustomButtonState].EnterConfigNo = value; }
        //}

        //[Category("HAPTIVITY"), Description("現在の状態での進入時強制振動の連続振動時間")]
        //[DefaultValue(10)]
        //public int OnEnterVibrationTime
        //{
        //    get { return mSimpleButtonList[mCustomButtonState].EnterVibrationTime; }
        //    set { mSimpleButtonList[mCustomButtonState].EnterVibrationTime = value; }
        //}





        //void InitSimpleButtonList(int countMax)
        //{
        //    mSimpleButtonList.Clear();
        //    this.Controls.Clear();

        //    for (int no = 1; no <= countMax; no++)
        //    {
        //        SimpleButton simpleButton = new SimpleButton();

        //        ((System.ComponentModel.ISupportInitialize)(simpleButton)).BeginInit();
        //        simpleButton.BackColor = System.Drawing.SystemColors.ControlDark;
        //        simpleButton.Haptivity = null;
        //        simpleButton.Image = global::HAPTIVITYLib.Properties.Resources.BtNormal;
        //        simpleButton.Location = new System.Drawing.Point(0, 0);
        //        simpleButton.MyFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
        //        simpleButton.Name = "mStateButton" + no.ToString();
        //        simpleButton.NormalImage = global::HAPTIVITYLib.Properties.Resources.BtNormal;
        //        simpleButton.PushedImage = global::HAPTIVITYLib.Properties.Resources.BtPushed;
        //        simpleButton.SelectImage = global::HAPTIVITYLib.Properties.Resources.BtSelect;
        //        simpleButton.Size = new System.Drawing.Size(100, 50);
        //        simpleButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        //        simpleButton.TabIndex = 0;
        //        simpleButton.TabStop = false;
        //        simpleButton.Text = "StateButton" + no.ToString();
        //        simpleButton.Visible = false;
        //        this.Controls.Add(simpleButton);
        //        mSimpleButtonList.Add(simpleButton);
        //    }
        //    mSimpleButtonList[0].Show();
        //    CustomButtonState = 1;
        //    Invalidate();
        //}

        //private void mSimpleButton_OnReleaseButton(object sender, EventArgs e)
        //{
        //    mSimpleButtonList[mCustomButtonState].Hide();
        //    if(++mCustomButtonState >= mSimpleButtonList.Count) mCustomButtonState = 0;
        //    mSimpleButtonList[mCustomButtonState].Show();
        //}

        private void StateButton_Resize(object sender, EventArgs e)
        {
            ResizeStateButton();
        }

        void ResizeStateButton()
        {
            //for (int i = 0; i < mCustomButtonList.Count; i++)
            //    mCustomButtonList[i].NormalImage.mode = Image.Size;
        }


        #region ボタンイベント処理
        [Category("ボタン処理"), Description("ボタンを押下した時に入る処理")]
        public event EventHandler OnPushButtonEvent = (sender, e) => { };

        [Category("ボタン処理"), Description("ボタンをリリースした時に入る処理")]
        public event EventHandler OnReleaseButtonEvent = (sender, e) => { };

        [Category("ボタン処理"), Description("ボタンに侵入した時に入る処理")]
        public event EventHandler OnEnterButtonEvent = (sender, e) => { };

        [Category("ボタン処理"), Description("ボタンから退出した時に入る処理")]
        public event EventHandler OnLeaveButtonEvent = (sender, e) => { };


        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            OnPushButton();
            base.OnMouseDown(mevent);
        }

        public void OnPushButton()
        {
            mCustomButtonList[mCustomButtonState].OnPushButton();
            OnPushButtonEvent(this, EventArgs.Empty);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            OnReleaseButton();
            base.OnMouseUp(mevent);
        }

        public void OnReleaseButton()
        {
            if(++mCustomButtonState >= mCustomButtonList.Count) mCustomButtonState = 0;
            mCustomButtonList[mCustomButtonState].OnReleaseButton();
            OnReleaseButtonEvent(this, EventArgs.Empty);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            mCustomButtonList[mCustomButtonState].OnEnterButton();
            OnEnterButtonEvent(this, EventArgs.Empty);
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            mCustomButtonList[mCustomButtonState].OnLeaveButton();
            OnLeaveButtonEvent(this, EventArgs.Empty);
            base.OnMouseLeave(e);
        }
        #endregion
    }

    public enum BtState
    {
        Normal,
        Select,
        Push
    }

    [DefaultProperty("NormalImage")]
    [TypeConverter(typeof(CustomButtonPropertyConverter))]
    public class CustomButtonProperty
    {
        public PictureBox mButton = null;
        public CustomButtonProperty(PictureBox pb = null)
        {
            mButton = pb;
            InitImage();
        }

        void InitImage()
        {
            if (mButtonImage != null)
                return;
            mButtonImage = new List<Image>();
            mButtonImage.Add(global::HAPTIVITYLib.Properties.Resources.BtNormal);
            mButtonImage.Add(global::HAPTIVITYLib.Properties.Resources.BtSelect);
            mButtonImage.Add(global::HAPTIVITYLib.Properties.Resources.BtPushed);
            ChangeButtonState(BtState.Normal);
        }

        ~CustomButtonProperty()
        {
            SelectImage?.Dispose();
            NormalImage?.Dispose();
            PushedImage?.Dispose();
        }

        public BtState mInitState = BtState.Normal;
        [DefaultValue(typeof(BtState), "None")]
        public BtState State
        {
            get { return mInitState; }
            set { mInitState = value; ChangeButtonState(value); }
        }

        protected List<Image> mButtonImage;
        [Description("通常のボタンのイメージ画像")]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]    //親のImageにプロパティ変更を通知して更新してもらう
        public Image NormalImage
        {
            get { return mButtonImage[(int)BtState.Normal]; }
            set { mButtonImage[(int)BtState.Normal] = value; }
        }

        [Description("ボタンを選択した時のイメージ画像")]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        public Image SelectImage
        {
            get { return mButtonImage[(int)BtState.Select]; }
            set { mButtonImage[(int)BtState.Select] = value; }
        }

        [Description("ボタンを押下した時のイメージ画像")]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        public Image PushedImage
        {
            get { return mButtonImage[(int)BtState.Push]; }
            set { mButtonImage[(int)BtState.Push] = value; }
        }

        public void DrawButtonNowState() { ChangeButtonState(mInitState); }
        void ChangeButtonState(BtState state)
        {
            if (mButton == null || mButtonImage == null)
                return;

            mInitState = state;
            switch (state)
            {
                case BtState.Normal:
                    mButton.Image = NormalImage;
                    mButton.Size = NormalImage.Size;
                    break;
                case BtState.Select:
                    mButton.Image = SelectImage;
                    mButton.Size = SelectImage.Size;
                    break;
                case BtState.Push:
                    mButton.Image = PushedImage;
                    mButton.Size = PushedImage.Size;
                    break;
            }
            mButton.Refresh();
        }


        //[Description("現在の状態でのボタンに表示させる文字")]
        //[DefaultValue("")]
        //public string OnText
        //{
        //    get { return mSimpleButtonList[mCustomButtonState].Text; }
        //    set { mSimpleButtonList[mCustomButtonState].Text = value; }
        //}

        //[Description("現在の状態でのボタンに表示させる文字の色")]
        //[DefaultValue(typeof(Color), "Aquamarine")]
        //public Color OnForeColor
        //{
        //    get { return mSimpleButtonList[mCustomButtonState].ForeColor; }
        //    set { mSimpleButtonList[mCustomButtonState].ForeColor = value; }
        //}

        //[Description("現在の状態でのボタンに表示させる文字フォント")]
        //[DefaultValue(typeof(Font), "Arial, 8, style=Bold")]
        //public Font OnMyFont
        //{
        //    get { return mSimpleButtonList[mCustomButtonState].Font; }
        //    set { mSimpleButtonList[mCustomButtonState].Font = value; }
        //}

        #region ボタンイベント処理
        public void OnPushButton()
        {
            if (mButton == null)
                return;
            mInitState = BtState.Push;
            mButton.Image = PushedImage;
        }

        public void OnReleaseButton()
        {
            if (mButton == null)
                return;
            mInitState = BtState.Select;
            mButton.Image = SelectImage;
        }

        public void OnEnterButton()
        {
            if (mButton == null)
                return;
            mInitState = BtState.Select;
            mButton.Image = SelectImage;
        }

        public void OnLeaveButton()
        {
            if (mButton == null)
                return;
            mInitState = BtState.Normal;
            mButton.Image = NormalImage;
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

        //public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        //{
        //    string strValue = value as string;
        //    if (strValue == null)
        //        return base.ConvertFrom(context, culture, value);
        //    string[] values = strValue.Split(',');
        //    int count = values.Length;
        //    try
        //    {
        //        CustomButtonProperty baseButtonProp = new CustomButtonProperty();
        //        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(context.Instance.GetType());

        //        return baseButtonProp;
        //    }
        //    catch
        //    {
        //        throw new ArgumentException("プロパティの値では画像がありません");
        //    }
        //}

        //public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        //{

        //    CustomButtonProperty baseButtonProp = value as CustomButtonProperty;
        //    if (baseButtonProp == null || destinationType != typeof(string))
        //        return base.ConvertTo(context, culture, value, destinationType);

        //    string select = "resource.SelectImage";
        //    string normal = "resource.NormalImage";
        //    string pushed = "resource.PushedImage";

        //    return string.Format("{0},{1},{2}",
        //                         select,
        //                         normal,
        //                         pushed
        //                         );
        //}
    }
}
