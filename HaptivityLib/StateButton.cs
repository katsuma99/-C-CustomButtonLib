using System;
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
        #region 変数定義
        //設定データを記録するために変数作る（クラスの配列は記録できない？）
        CustomButtonProperty mCustomButton1 = new CustomButtonProperty();
        [Category("カスタム：ボタン"), Description("通常・選択・押下のボタンのイメージ画像")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CustomButtonProperty Button1
        {
            get {return mCustomButton1; }
            set { mCustomButton1 = value; State = 1; }
        }

        CustomButtonProperty mCustomButton2 = new CustomButtonProperty();
        [Category("カスタム：ボタン"), Description("通常・選択・押下のボタンのイメージ画像")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CustomButtonProperty Button2
        {
            get { return mCustomButton2; }
            set { mCustomButton2 = value; State = 2; }
        }

        CustomButtonProperty mCustomButton3 = new CustomButtonProperty();
        [Category("カスタム：ボタン"), Description("通常・選択・押下のボタンのイメージ画像")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CustomButtonProperty Button3
        {
            get { return mCustomButton3; }
            set { mCustomButton3 = value; State = 3; }
        }

        CustomButtonProperty mCustomButton4 = new CustomButtonProperty();
        [Category("カスタム：ボタン"), Description("通常・選択・押下のボタンのイメージ画像")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CustomButtonProperty Button4
        {
            get { return mCustomButton4; }
            set { mCustomButton4 = value; State = 4; }
        }

        CustomButtonProperty mCustomButton5 = new CustomButtonProperty();
        [Category("カスタム：ボタン"), Description("通常・選択・押下のボタンのイメージ画像")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CustomButtonProperty Button5
        {
            get { return mCustomButton5; }
            set { mCustomButton5 = value; State = 5; }
        }

        CustomButtonProperty mCustomButton6 = new CustomButtonProperty();
        [Category("カスタム：ボタン"), Description("通常・選択・押下のボタンのイメージ画像")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CustomButtonProperty Button6
        {
            get { return mCustomButton6; }
            set { mCustomButton6 = value; State = 6; }
        }

        CustomButtonProperty mCustomButton7 = new CustomButtonProperty();
        [Category("カスタム：ボタン"), Description("通常・選択・押下のボタンのイメージ画像")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CustomButtonProperty Button7
        {
            get { return mCustomButton7; }
            set { mCustomButton7 = value; State = 7; }
        }

        CustomButtonProperty mCustomButton8 = new CustomButtonProperty();
        [Category("カスタム：ボタン"), Description("通常・選択・押下のボタンのイメージ画像")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CustomButtonProperty Button8
        {
            get { return mCustomButton8; }
            set { mCustomButton8 = value; State = 8; }
        }

        public BtState mState = BtState.Normal;
        [DefaultValue(typeof(BtState), "None")]
        [Category("カスタム：ボタン"), Description("ボタンの初期状態（編集時にも変更すると確認できる）")]
        public BtState InitState
        {
            get { return mState; }
            set { mState = value; GetNowCustomButton().ChangeButton(mState); }
        }

        public int mCustomButtonState = 0;
        [Category("カスタム：ステート"), Description("ステートボタンの現在のパターン")]
        [DefaultValue(0)]
        public int State
        {
            get
            {
                return mCustomButtonState + 1;
            }
            set
            {
                mCustomButtonState = Math.Max(1, Math.Min(mStateMax, value)) - 1;
                GetNowCustomButton().ChangeButton(mState);
            }
        }

        int mStateMax = 1;
        [Category("カスタム：ステート"), Description("ステートボタンのパターン数(max:8)")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(0)]
        public int StateMax
        {
            get { return mStateMax; }
            set { mStateMax = Math.Min(8, value); ResizeStatePattern(mStateMax); }
        }
        #endregion

        public StateButton()
        {
            InitializeComponent();
            ResizeStatePattern(mStateMax);
            GetNowCustomButton().ChangeButton(mState);
        }

        //ステートボタンの状態パターンを変更する
        void ResizeStatePattern(int stateMax)
        {
            Button1.mButton = stateMax >= 1 ? this : null;
            Button2.mButton = stateMax >= 2 ? this : null;
            Button3.mButton = stateMax >= 3 ? this : null;
            Button4.mButton = stateMax >= 4 ? this : null;
            Button5.mButton = stateMax >= 5 ? this : null;
            Button6.mButton = stateMax >= 6 ? this : null;
            Button7.mButton = stateMax >= 7 ? this : null;
            Button8.mButton = stateMax >= 8 ? this : null;
        }

        //現在のカスタムボタンを取得（ステートボタンはカスタムボタンの集まり）
        CustomButtonProperty GetNowCustomButton()
        {
            CustomButtonProperty cbp = Button1;
            switch (State)
            {
                case 1: cbp = Button1; break;
                case 2: cbp = Button2; break;
                case 3: cbp = Button3; break;
                case 4: cbp = Button4; break;
                case 5: cbp = Button5; break;
                case 6: cbp = Button6; break;
                case 7: cbp = Button7; break;
                case 8: cbp = Button8; break;
            }
            return cbp;
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

        #region ボタンイベント処理
        [Category("カスタム：ボタン処理"), Description("ボタンを押下した時に入る処理")]
        public event EventHandler OnPushButtonEvent = (sender, e) => { };

        [Category("カスタム：ボタン処理"), Description("ボタンをリリースした時に入る処理")]
        public event EventHandler OnReleaseButtonEvent = (sender, e) => { };

        [Category("カスタム：ボタン処理"), Description("ボタンに侵入した時に入る処理")]
        public event EventHandler OnEnterButtonEvent = (sender, e) => { };

        [Category("カスタム：ボタン処理"), Description("ボタンから退出した時に入る処理")]
        public event EventHandler OnLeaveButtonEvent = (sender, e) => { };


        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            OnPushButton();
            base.OnMouseDown(mevent);
        }

        public void OnPushButton()
        {
            mState = BtState.Pushed;
            GetNowCustomButton().OnPushButton();
            OnPushButtonEvent(this, EventArgs.Empty);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            OnReleaseButton();
            base.OnMouseUp(mevent);
        }

        public void OnReleaseButton()
        {
            mState = BtState.Select;
            if(++mCustomButtonState >= mStateMax) mCustomButtonState = 0;
            GetNowCustomButton().OnReleaseButton();
            OnReleaseButtonEvent(this, EventArgs.Empty);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            mState = BtState.Select;
            GetNowCustomButton().OnEnterButton();
            OnEnterButtonEvent(this, EventArgs.Empty);
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            mState = BtState.Normal;
            GetNowCustomButton().OnLeaveButton();
            OnLeaveButtonEvent(this, EventArgs.Empty);
            base.OnMouseLeave(e);
        }
        #endregion

        //イメージ画像リサイズ
        private void StateButton_SizeChanged(object sender, EventArgs e)
        {
            CustomButtonProperty cbp = null;
            for (int state = 1; state <= 8; state++)
            {
                switch (state)
                {
                    case 1: cbp = Button1; break; 
                    case 2: cbp = Button2; break; 
                    case 3: cbp = Button3; break; 
                    case 4: cbp = Button4; break; 
                    case 5: cbp = Button5; break; 
                    case 6: cbp = Button6; break; 
                    case 7: cbp = Button7; break; 
                    case 8: cbp = Button8; break; 
                }
                cbp.ResizeImage(((PictureBox)sender).Size);
            }
            GetNowCustomButton().ChangeButton(mState);
        }
    }

    public enum BtState
    {
        Normal,
        Select,
        Pushed
    }

    [DefaultProperty("NormalImage")]
    [TypeConverter(typeof(CustomButtonPropertyConverter))]
    public class CustomButtonProperty:ICloneable
    {
        #region 変数
        public PictureBox mButton = null;

        protected List<Image> mButtonImage;
        Image mOriNormalImage = null;
        [Description("通常のボタンのイメージ画像")]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]    //親のImageにプロパティ変更を通知して更新してもらう
        public Image NormalImage
        {
            get { return mButtonImage[(int)BtState.Normal]; }
            set { if (value == null) return; mButtonImage[(int)BtState.Normal] = value;
                mOriNormalImage = (Image)value.Clone(); ChangeButton(BtState.Normal); }
        }

        Image mOriSelectlImage = null;
        [Description("ボタンを選択した時のイメージ画像")]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        public Image SelectImage
        {
            get { return mButtonImage[(int)BtState.Select]; }
            set { if (value == null) return; mButtonImage[(int)BtState.Select] = value;
                mOriSelectlImage = (Image)value.Clone(); ChangeButton(BtState.Select); }
        }

        Image mOriPushedImage = null;
        [Description("ボタンを押下した時のイメージ画像")]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        public Image PushedImage
        {
            get { return mButtonImage[(int)BtState.Pushed]; }
            set { if (value == null) return; mButtonImage[(int)BtState.Pushed] = value;
                mOriPushedImage = (Image)value.Clone(); ChangeButton(BtState.Pushed); }
        }
        #endregion

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
            mOriNormalImage = (Image)mButtonImage[0].Clone();
            mButtonImage.Add(global::HAPTIVITYLib.Properties.Resources.BtSelect);
            mOriSelectlImage = (Image)mButtonImage[1].Clone();
            mButtonImage.Add(global::HAPTIVITYLib.Properties.Resources.BtPushed);
            mOriPushedImage = (Image)mButtonImage[2].Clone();
            ChangeButton(BtState.Normal);
        }

        ~CustomButtonProperty()
        {
            SelectImage?.Dispose();
            NormalImage?.Dispose();
            PushedImage?.Dispose();
        }

        public void ChangeButton(BtState state)
        {
            if (mButton == null || mButtonImage == null || NormalImage == null || SelectImage == null || PushedImage == null)
                return;

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
                case BtState.Pushed:
                    mButton.Image = PushedImage;
                    mButton.Size = PushedImage.Size;
                    break;
            }
            mButton.Refresh();
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
            }
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

        public object Clone()
        {
            CustomButtonProperty work = new CustomButtonProperty(mButton);
            work = (CustomButtonProperty)this.MemberwiseClone();
            work.NormalImage = (Image)this.NormalImage.Clone();
            work.SelectImage = (Image)this.SelectImage.Clone();
            work.PushedImage = (Image)this.PushedImage.Clone();
            return work;
        }

        #region ボタンイベント処理
        public void OnPushButton()
        {
            if (mButton == null) return;
            mButton.Image = PushedImage;
        }

        public void OnReleaseButton()
        {
            if (mButton == null) return;
            mButton.Image = SelectImage;
        }

        public void OnEnterButton()
        {
            if (mButton == null) return;
            mButton.Image = SelectImage;
        }

        public void OnLeaveButton()
        {
            if (mButton == null) return;
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

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {

            CustomButtonProperty baseButtonProp = value as CustomButtonProperty;
            if (baseButtonProp == null || destinationType != typeof(string))
                return base.ConvertTo(context, culture, value, destinationType);

            if(baseButtonProp.mButton == null)
                return string.Format("Out of Range");
            else
                return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
