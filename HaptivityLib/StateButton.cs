using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

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
            set { mCustomButton1 = value; State = SBtState.Button1; }
        }

        CustomButtonProperty mCustomButton2 = new CustomButtonProperty();
        [Category("カスタム：ボタン"), Description("通常・選択・押下のボタンのイメージ画像")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CustomButtonProperty Button2
        {
            get { return mCustomButton2; }
            set { mCustomButton2 = value; State = SBtState.Button2; }
        }

        CustomButtonProperty mCustomButton3 = new CustomButtonProperty();
        [Category("カスタム：ボタン"), Description("通常・選択・押下のボタンのイメージ画像")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CustomButtonProperty Button3
        {
            get { return mCustomButton3; }
            set { mCustomButton3 = value; State = SBtState.Button3; }
        }

        CustomButtonProperty mCustomButton4 = new CustomButtonProperty();
        [Category("カスタム：ボタン"), Description("通常・選択・押下のボタンのイメージ画像")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CustomButtonProperty Button4
        {
            get { return mCustomButton4; }
            set { mCustomButton4 = value; State = SBtState.Button4; }
        }

        CustomButtonProperty mCustomButton5 = new CustomButtonProperty();
        [Category("カスタム：ボタン"), Description("通常・選択・押下のボタンのイメージ画像")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CustomButtonProperty Button5
        {
            get { return mCustomButton5; }
            set { mCustomButton5 = value; State = SBtState.Button5; }
        }

        CustomButtonProperty mCustomButton6 = new CustomButtonProperty();
        [Category("カスタム：ボタン"), Description("通常・選択・押下のボタンのイメージ画像")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CustomButtonProperty Button6
        {
            get { return mCustomButton6; }
            set { mCustomButton6 = value; State = SBtState.Button6; }
        }

        CustomButtonProperty mCustomButton7 = new CustomButtonProperty();
        [Category("カスタム：ボタン"), Description("通常・選択・押下のボタンのイメージ画像")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CustomButtonProperty Button7
        {
            get { return mCustomButton7; }
            set { mCustomButton7 = value; State = SBtState.Button7; }
        }

        CustomButtonProperty mCustomButton8 = new CustomButtonProperty();
        [Category("カスタム：ボタン"), Description("通常・選択・押下のボタンのイメージ画像")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CustomButtonProperty Button8
        {
            get { return mCustomButton8; }
            set { mCustomButton8 = value; State = SBtState.Button8; }
        }

        public BtState mState = BtState.Normal;
        [DefaultValue(typeof(BtState), "None")]
        [Category("カスタム：ボタン"), Description("ボタンの初期状態（編集時にも変更すると確認できる）")]
        public BtState InitState
        {
            get { return mState; }
            set { mState = value; GetNowCustomButton().ChangeButton(mState); }
        }

        public enum SBtState
        {
            Button1,
            Button2,
            Button3,
            Button4,
            Button5,
            Button6,
            Button7,
            Button8
        }

        public int mCustomButtonState = 0;
        [Category("カスタム：ステート"), Description("ステートボタンの現在のパターン")]
        [DefaultValue(0)]
        public SBtState State
        {
            get
            {
                return (SBtState)mCustomButtonState;
            }
            set
            {
                mCustomButtonState = (int)value;
                if (mStateMax != (int)SBtState.Button8 && mCustomButtonState == (int)SBtState.Button8)
                    mCustomButtonState = mStateMax - 1;
                else if(mCustomButtonState >= mStateMax)
                    mCustomButtonState = 0;
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
            set
            {
                mStateMax = Math.Min(8, value); ResizeStatePattern(mStateMax);
                State = State;//Maxを更新したため、範囲内にシュリンク
            }
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
            Button1.Button = stateMax >= 1 ? this : null;
            Button2.Button = stateMax >= 2 ? this : null;
            Button3.Button = stateMax >= 3 ? this : null;
            Button4.Button = stateMax >= 4 ? this : null;
            Button5.Button = stateMax >= 5 ? this : null;
            Button6.Button = stateMax >= 6 ? this : null;
            Button7.Button = stateMax >= 7 ? this : null;
            Button8.Button = stateMax >= 8 ? this : null;
        }

        //現在のカスタムボタンを取得（ステートボタンはカスタムボタンの集まり）
        CustomButtonProperty GetNowCustomButton()
        {
            CustomButtonProperty cbp = Button1;
            switch (State)
            {
                case SBtState.Button1: cbp = Button1; break;
                case SBtState.Button2: cbp = Button2; break;
                case SBtState.Button3: cbp = Button3; break;
                case SBtState.Button4: cbp = Button4; break;
                case SBtState.Button5: cbp = Button5; break;
                case SBtState.Button6: cbp = Button6; break;
                case SBtState.Button7: cbp = Button7; break;
                case SBtState.Button8: cbp = Button8; break;
            }
            return cbp;
        }

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


        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            GetNowCustomButton().OnPaint(pe);
        }

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
}
