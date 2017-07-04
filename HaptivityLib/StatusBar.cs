using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimpleButtonLib;

namespace StatusBar
{
    using aRecive = HAPTIVITYLib.Interface.RECEIVE_HAPTIVITY_STATE;
    public partial class StatusBar : SimpleButton
    {
        #region 変数
        protected float mValueRatio = 0;
        [Category("カスタム：バー"), Description("現在のバーの値(%)")]
        [Bindable(true), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public int BarNowValueRatio
        {
            get
            {
                return (int)(mValueRatio * 100);
            }
            set
            {
                mValueRatio = Math.Max(0, Math.Min(100, value)) / 100f;
                Invalidate();
            }
        }

        protected float mValueMax = 1f;
        [Category("カスタム：バー"), Description("バーのMax値(%)")]
        [Bindable(true), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public int BarMaxRatio
        {
            get
            {
                return (int)(mValueMax * 100);
            }
            set
            {
                mValueMax = Math.Min(100, Math.Max(mValueMin*100, value)) / 100f;
                Invalidate();
            }
        }

        protected float mValueMin = 0;
        [Category("カスタム：バー"), Description("バーのMin値(%)")]
        [Bindable(true), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public int BarMinRatio
        {
            get
            {
                return (int)(mValueMin * 100);
            }
            set
            {
                mValueMin = Math.Max(0, Math.Min(mValueMax*100, value)) / 100f;
                Invalidate();
            }
        }

        protected int mDivisionNum = 10;
        [Category("カスタム：バー"), Description("バーの分割数")]
        [Bindable(true), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public int DivisionNum
        {
            get
            {
                return mDivisionNum;
            }
            set
            {
                mDivisionNum = Math.Max(1, Math.Min(50, value));
                Invalidate();
            }
        }

        protected int mTextBaseNum = 0;
        [Category("カスタム：バー"), Description("表示するテキスト：基底の数字")]
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
        [Category("カスタム：バー"), Description("表示するテキスト：1メモリの上昇する値")]
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

        protected string mUnitText = "";
        [Category("カスタム：バー"), Description("表示するテキスト：単位")]
        [Bindable(true), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public string UnitText
        {
            get
            {
                return mUnitText;
            }
            set
            {
                mUnitText = value;
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
        bool isDirect = true;
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
            if(isDirect)moveValue = pos.X;
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
            if (isDirect) nowValue = addValue;

            //バー値変化したら振動する
            if ((int)nowValue != (int)mPreValue)
            {
                MoveVibration();
            }
            mPreValue = nowValue;
            //Value->Ratioに変換
            BarNowValueRatio = (int)(ValueToRatio(nowValue) * 100); //min,maxを補正

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
            using (Brush backBrush = new SolidBrush(this.BackColor))
            using (Brush foreBrush = new SolidBrush(this.ForeColor))
            {
                //背景を描画する
                e.Graphics.FillRectangle(backBrush, this.ClientRectangle);

                //バーの幅を計算する
                Rectangle chunksRect = new Rectangle(GetBarStartPosition(), 0, (int)Math.Ceiling(GetNowStepValueLength()), this.ClientSize.Height);
                //バーを描画する
                e.Graphics.FillRectangle(foreBrush, chunksRect);

                chunksRect = new Rectangle(GetBarStartPosition(), Height/2, (int)Math.Ceiling(GetNowValueLength()), this.ClientSize.Height/2);
                //バーを描画する
                e.Graphics.FillRectangle(foreBrush, chunksRect);
            }

            float value = (int)RatioToValue(mValueRatio) * mTextStepNum + mTextBaseNum;
            mText = value.ToString("F1") + mUnitText;

            //base.OnPaint(e);//画像テキストを上書き

        }
    }
}
