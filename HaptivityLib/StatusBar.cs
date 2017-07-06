using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimpleButtonLib;
using System.Drawing.Drawing2D;

namespace StatusBar
{
    using aRecive = HAPTIVITYLib.Interface.RECEIVE_HAPTIVITY_STATE;
    public partial class StatusBar : SimpleButton
    {
        #region 変数
        public enum Number0To100
        {
            _0, _1, _2, _3, _4, _5, _6, _7, _8, _9,
            _10, _11, _12, _13, _14, _15, _16, _17, _18, _19,
            _20, _21, _22, _23, _24, _25, _26, _27, _28, _29,
            _30, _31, _32, _33, _34, _35, _36, _37, _38, _39,
            _40, _41, _42, _43, _44, _45, _46, _47, _48, _49,
            _50, _51, _52, _53, _54, _55, _56, _57, _58, _59,
            _60, _61, _62, _63, _64, _65, _66, _67, _68, _69,
            _70, _71, _72, _73, _74, _75, _76, _77, _78, _79,
            _80, _81, _82, _83, _84, _85, _86, _87, _88, _89,
            _90, _91, _92, _93, _94, _95, _96, _97, _98, _99, _100,
        }

        protected float mValueRatio = 0;
        [Category("カスタム：バー"), Description("現在のバーの値(%)")]
        [Bindable(true), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public Number0To100 BarNowValueRatio
        {
            get
            {
                return (Number0To100)(int)(mValueRatio * 100);
            }
            set
            {
                mValueRatio = Math.Max(0, Math.Min(100, (int)value)) / 100f + 0.00001f;
                Invalidate();
            }
        }

        protected float mValueMax = 1f;
        [Category("カスタム：バー"), Description("バーのMax値(%)")]
        [Bindable(true), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public Number0To100 BarMaxRatio
        {
            get
            {
                return (Number0To100)(int)(mValueMax * 100);
            }
            set
            {
                mValueMax = Math.Min(100, Math.Max(mValueMin*100, (int)value)) / 100f + 0.00001f;
                Invalidate();
            }
        }

        protected float mValueMin = 0;
        [Category("カスタム：バー"), Description("バーのMin値(%)")]
        [Bindable(true), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public Number0To100 BarMinRatio
        {
            get
            {
                return (Number0To100)(int)(mValueMin * 100);
            }
            set
            {
                mValueMin = Math.Max(0, Math.Min(mValueMax*100, (int)value)) / 100f + 0.00001f;
                Invalidate();
            }
        }

        protected int mDivisionNum = 10;
        [Category("カスタム：バー"), Description("バーの分割数")]
        [Bindable(true), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public Number0To100 DivisionNum
        {
            get
            {
                return (Number0To100)mDivisionNum;
            }
            set
            {
                mDivisionNum = Math.Max(1, Math.Min(50, (int)value));
                Invalidate();
            }
        }

        protected int mTextBaseNum = 0;
        [Category("カスタム：ボタンテキスト"), Description("表示するテキスト：基底の数字")]
        [Bindable(true), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public int TextBaseNum
        {
            get
            {
                return mTextBaseNum;
            }
            set
            {
                mTextBaseNum = value;
                Invalidate();
            }
        }

        protected int mTextStepNum = 1;
        [Category("カスタム：ボタンテキスト"), Description("表示するテキスト：1メモリの上昇する値")]
        [Bindable(true), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public int TextStepNum
        {
            get
            {
                return mTextStepNum;
            }
            set
            {
                mTextStepNum = value;
                Invalidate();
            }
        }

        protected bool mIsAdjustMode = true;
        [Category("カスタム：バー"), Description("バーを画像に合わせる際のモード")]
        [Bindable(true), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public bool IsAdjustMode
        {
            get
            {
                return mIsAdjustMode;
            }
            set
            {
                mIsAdjustMode = value;
                Invalidate();
            }
        }

        protected bool mIsDirect = true;
        [Category("カスタム：バー"), Description("カーソルの位置がバーの値になるモード")]
        [Bindable(true), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public bool IsDirect
        {
            get
            {
                return mIsDirect;
            }
            set
            {
                mIsDirect = value;
                Invalidate();
            }
        }

        protected Color mBackColor = Color.Black;
        [Category("カスタム：バー"), Description("バーの背景色")]
        [Bindable(true), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public override Color BackColor
        {
            get
            {
                return mBackColor;
            }
            set
            {
                mBackColor = value;
                Invalidate();
            }
        }

        protected Color mFrontColor = Color.White;
        [Category("カスタム：バー"), Description("バーの描画色")]
        [Bindable(true), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public Color FrontColor
        {
            get
            {
                return mFrontColor;
            }
            set
            {
                mFrontColor = value;
                Invalidate();
            }
        }

        protected Color? mFrontGradationColor = null;
        [DefaultValue(null)]
        [Category("カスタム：バー"), Description("バーのグラデーション時の色")]
        [Bindable(true), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public Color? FrontGradationColor
        {
            get
            {
                return mFrontGradationColor;
            }
            set
            {
                mFrontGradationColor = value;
                Invalidate();
            }
        }
        #endregion


        public StatusBar()
        {
            InitializeComponent();
            mPreValue = mValueRatio;
        }

        public override void OnPushButton()
        {
            base.OnPushButton();
            mPrePos = PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y));
            AdjustBar();
        }

        public override void OnReleaseButton()
        {

            base.OnReleaseButton();
        }

        #region Move処理
        private void StatusBar_MouseMove(object sender, MouseEventArgs e)
        {
            AdjustBar();
        }

        int vibCount = 0;
        float mPreValue = 0;
        Point mPrePos = new Point();
        protected void AdjustBar()
        {
            if (State != BtState.Pushed)   //ボタンが押されている時編集できる
                return;

            Point pos = new Point(Cursor.Position.X, Cursor.Position.Y);//Mouse位置の記憶
            pos = PointToClient(pos);//ボタンの位置（原点）を基準に座標変換

            //X座標で一定範囲以上動いたか
            int moveValue = pos.X - mPrePos.X;
            if(mIsDirect)moveValue = pos.X;
            mPrePos = pos;
            //if (F1Udp.mUdp.CheckTouchLeave(mPrePos.X))
            //{
            //    k = 0;
            //    mPrePos.X = pos.X;
            //}
            //Length->Valueに変換
            float addValue = moveValue / GetOneWidth();
            float nowValue = GetNowValueLength() / GetOneWidth();
            nowValue += addValue;
            if (mIsDirect) nowValue = addValue;

            //バー値変化したら振動する
            if ((int)nowValue != (int)mPreValue)
            {
                MoveVibration();
            }
            mPreValue = nowValue;
            //Value->Ratioに変換
            BarNowValueRatio = (Number0To100)(int)(ValueToRatio(nowValue) * 100); //min,maxを補正

            // 再描画
            Invalidate();
        }

        protected void MoveVibration()
        {
            if (mHaptivity == null)
                return;
                
            //if (Current_Temp >= AIRCON_KC_Resource.TempImage.Count)
            //{
            //    Current_Temp = AIRCON_KC_Resource.TempImage.Count - 1;
            //    Current_Temp_base -= 0.4f;
            //    if (vibCount < 2)
            //        hap.ForcedVibration(NO_8);  //シリアル送信（強制）イリーガル振動
            //    vibCount++;
            //}
            //else if (Current_Temp < 0)
            //{
            //    Current_Temp = 0;
            //    Current_Temp_base += 0.4f;
            //    if (vibCount < 2)
            //        hap.ForcedVibration(NO_8);  //シリアル送信（強制）イリーガル振動
            //    vibCount++;
            //}
            //else if (Current_Temp == 0) hap.ForcedVibration(NO_8);
            //else if (Current_Temp == 1) hap.ForcedVibration(NO_9);
            //else if (Current_Temp == 2) hap.ForcedVibration(NO_10);
            //else if (Current_Temp == 7) hap.ForcedVibration(NO_11);
            //else if (Current_Temp == 8) hap.ForcedVibration(NO_12);
            //else if (Current_Temp == 17) hap.ForcedVibration(NO_25);
            //else if (Current_Temp == 18) hap.ForcedVibration(NO_26);
            //else if (Current_Temp == 23) hap.ForcedVibration(NO_27);
            //else if (Current_Temp == 24) hap.ForcedVibration(NO_28);
            //else
            //{
            //    int Temp_data = NO_9 + Current_Temp - 3;
            //    hap.ForcedVibration(Temp_data);  //シリアル送信（強制）key位置知らせる
            //    vibCount = 0;
            //}
            //Current_Temp_save = Current_Temp;
        }
        #endregion

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

            //int ev = 0;
            //if (!F1Udp.isMouseMode && !F1Udp.mUdp.GetTouchEvent(ref ev))
            //{
            //    if (ev == 2)
            //    {
            //        Up_Operation(bpos);
            //        return;
            //    }
            //}
        }

        //Bar全体の長さ
        float GetBarLength()
        {
            float ratio = mValueMax - mValueMin;  //バー画像全体とバーとのサイズ割合
            return ClientSize.Width * ratio;        //バーのサイズ
        }

        //現在の値の長さ
        float GetNowValueLength()
        {
            return GetBarLength() * mValueRatio;     //値のサイズ
        }

        float GetNowStepValueLength()
        {
            float value = (int)RatioToValue(mValueRatio);
            return value * GetOneWidth();     //値のサイズ
        }

        //1メモリの長さ
        float GetOneWidth()
        {
            return GetBarLength() / (float)mDivisionNum;
        }

        //Barの割合（％）->値（メモリ）へ変換
        float RatioToValue(float ratio)
        {
           return ratio * GetBarLength() / GetOneWidth();
        }

        //Barの値（メモリ）->割合（％）へ変換
        float ValueToRatio(float value)
        {
            return (value * GetOneWidth()) / GetBarLength();
        }

        //Barを描画するスタート地点
        int GetBarStartPosition() { return (int)Math.Ceiling(ClientSize.Width * mValueMin); }

        //描画処理を上書き
        protected override void OnPaint(PaintEventArgs e)
        {
            Color backColor = this.BackColor;
            Color frontColor = this.FrontColor;
            Color frontGradationColor = mFrontGradationColor.HasValue ? mFrontGradationColor.Value : frontColor;

            if (mIsAdjustMode)
            {
                base.OnPaint(e);
                backColor = Color.FromArgb(120, backColor);
                frontColor = Color.FromArgb(120, frontColor);
            }

            using (Brush backBrush = new SolidBrush(backColor))
            using (LinearGradientBrush foreBrush = new LinearGradientBrush(
                    e.Graphics.VisibleClipBounds,
                    frontColor,
                    frontGradationColor,
                    LinearGradientMode.Horizontal))
            {

                //背景を描画する
                e.Graphics.FillRectangle(backBrush, this.ClientRectangle);

                //バーの幅を計算する
                Rectangle chunksRect = new Rectangle(GetBarStartPosition(), 0, (int)Math.Ceiling(GetNowStepValueLength()), this.ClientSize.Height);
                //バーを描画する
                e.Graphics.FillRectangle(foreBrush, chunksRect);

                if (mIsAdjustMode)
                {
                    //Debug--------------------------------------------------------------//
                    //グリッド
                    Rectangle oneRect =new Rectangle(GetBarStartPosition(), 0, (int)Math.Ceiling(GetOneWidth()), this.ClientSize.Height); ; 
                    for (int rectNo = 0; rectNo < (int)this.DivisionNum; rectNo++)
                    {
                        e.Graphics.DrawRectangle(new Pen(Color.Red), oneRect);
                        oneRect.X += (int)Math.Ceiling(GetOneWidth());
                    }
                    //フレキシブルバー
                    chunksRect = new Rectangle(GetBarStartPosition(), 0, (int)Math.Ceiling(GetNowValueLength()), 4);
                    e.Graphics.FillRectangle(new SolidBrush(Color.Red), chunksRect);
                    //-------------------------------------------------------------------//
                }
            }

            float value = (int)RatioToValue(mValueRatio) * mTextStepNum + mTextBaseNum;

            if (!mIsAdjustMode)
                base.OnPaint(e);//画像テキストを上書き

        }
    }
}
