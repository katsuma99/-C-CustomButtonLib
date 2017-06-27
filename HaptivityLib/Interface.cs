//#define RD167  //RD140の場合コメントアウト
//#define READOUTPUT //HAPTIVITYから送られてくるコマンド監視
//#define SENDOUTPUT　//HAPTIVITYへ送るコマンド監視


/////////////////////////////////////////////////////////////////////////////////////////////
/*<仕様>                                                                                   */
/*・Hapticをインスタンス化することでComPort設定を行いHapticを使う準備が完了する            */
/*　→mHaptic = new Haptic(this);　thisはフォーム                                          */
/*・HapticクラスはHapticとPC間でのシリアル通信をサポートする                               */
/*　→コマンド送信を行い、振動させる                                                       */
/*　→圧力を検知し、タッチイベントを発生させる                                             */
/*                                                                                         */
/*・Hapticの関数を以下に示す                                                               */
/*　> DataReceived(ref int pat)                                                            */
/*　　→Hapticからタッチイベントを受信しているとtrueを返す（pat 1: 押下 　2: リリース）    */
/*                                                                                         */
/*　> EnterVibration(int vpat, int IC, int autoVibPat = TEMPAUTOVIBPAT)                    */
/*　　→進入した際に一定時間（プロパティで変更可）強制振動を出す(vpatは振動パターン)       */
/*　　→その後Haptic動作モードに入る                                                       */
/*　> LeaveVibration()                                                                     */
/*　　→退出した際に強制振動を途中でとめる                                                 */
/*                                                                                         */
/*　> ForcedVibration(int vpat)                                                            */
/*　　→強制振動を1回出す(vpatは振動パターン)                                              */
/*　> StartVibration(string number, string IC)                                             */
/*　　→Haptic振動の待機状態にする                                                         */
/*　> Button_Stop_operation()                                                              */
/*　　→Hapticの待機状態をとめる                                                           */
/*　> Auto_Stop_operation(MethodAfterStopMode method)                                      */
/*　　→Hapticの待機状態をとめて、その後処理を行う                                         */
/*                                                                                         */
/*　> com_close()                                                                          */
/*　　→Comportの接続を切る                                                                */
/*　> LoadConfig()                                                                         */
/*　　→コンフィグファイルをLoadして、Hapticの設定を変更する                               */
/////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace HAPTIVITYLib
{
    public partial class Interface : UserControl
    {
        #region 各種変数
        FileLoader mDataManager;
        public static Form focusForm;                             //対象フォーム
        Action DoAfterStopMode; //stopModeにした後の処理
        public bool isEnable = false;               //マウス動作のON/OFFフラグ

        //強制振動初期設定
        const int INITENTERVIBPATTERN = 0;         //パターン(configNum)
        const int VIBTIME = 15;        //間隔[msec]

        //進入振動後のスタート振動設定
        int vibPatAfterEnter = 0;                   //振動パターン
#if RD167
        int icAfterEnter = 0;                       //使用するIC
#endif

        //スワイプ触感で使用
        Point preMousePoint;                        //前回振動した位置
        int intervalDis;                            //一定距離で振動する

        int preSendConfigNo;                          //送ったconfig番号(一手前)
        System.Timers.Timer sendTimer;             //コマンド送信の間隔[msec](送受信で3msec程度かかる)
        static int hapticIcCount = 0;               //hapticのICの数
        string[] vibDataSetting = new string[3];   //0:コンフィグデータ　1:オフセットデータ　2:COMデータ

        System.Timers.Timer autoVib;
        int autoVibPat = INITENTERVIBPATTERN;
        System.Timers.Timer autoVibStoptimer;

#if RD167
        enum SEND_COMMAND
        {
            INIT = 0x00,                //初期化
            STOP_VIB_ON = 0x08,         //Haptic待機モード停止
            STOP_VIB_OFF = 0x08,        //Haptic待機モード停止
            FORCE_PRE = 0x10,           //強制振動準備モード
            FORCE_CANCEL = 0x14,        //強制振動準備モードキャンセル
            FORCE = 0x60,               //強制振動
            START = 0x80,               //スタートでHaptic待機モード
            MODE_VIB = 0x34,            //振動データD/Lモード
            MODE_OFF = 0x38,            //面内補正データD/Lモード 
            MODE_END = 0x3C,            //モード終了コマンド
        };
        byte preparationCancelCmd = (byte)SEND_COMMAND.FORCE_CANCEL;
        byte[] preparationCmd = new byte[] { (byte)SEND_COMMAND.FORCE_PRE };
        int preIc = 0;
        bool isForcePreparation = false;            //強制振動準備コマンド送る

#else
        public enum SEND_COMMAND
        {
            INIT = 0x00,
            STOP_VIB_ON = 0x40,    //*
            STOP_VIB_OFF = 0x41,    //*
            LOCATION = 0x80,    //*
            FORCE = 0x60,    //同じ
            START = 0x20,    // *
            MODE_VIB = 0xA1,    //振動データD/Lモード
            MODE_OFF = 0xE1,    //面内補正データD/Lモード 
            MODE_END = 0xFF,    //モード終了コマンド
        };
#endif
        enum RECEIVE_COMMAND
        {
            PUSH_MIN = 0x28,
            PUSH_MAX = 0x2F,
            RELEASE_MIN = 0x30,
            RELEASE_MAX = 0x38,
            FORCE = 0x20,
        };

        public enum RECEIVE_HAPTIVITY_STATE
        {
            NONE,
            PUSH,
            RELEASE,
            FORCE,
            OTHER,
        };
        #endregion

        #region 初期化(コンストラクタ、ディストラクタ)関連
        public Interface()
        {
            InitializeComponent();
        }

        private void Interface_ParentChanged(object sender, EventArgs e)
        {
            RemoveEventHandler();
            focusForm = (Form)this.Parent;
            AddEventHandler();
        }

        private void AddEventHandler()
        {
            focusForm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LoadConfig);
        }

        private void RemoveEventHandler()
        {
            if (focusForm == null) return;

            focusForm.KeyUp -= new System.Windows.Forms.KeyEventHandler(this.LoadConfig);
        }

        //表示されないと呼ばれない（Visible = falseの場合は呼ばれない）コンストラクタで非表示にしたら使えない
        private void Interface_Load(object sender, EventArgs e)
        {
            if (DesignMode) //フォームデザイン時は設定しない[bug]
                return;
            
            this.Visible = false;
            InitSetting();
        }

        private void InitSetting()
        {
            mDataManager = new FileLoader(null);

            isEnable = true;

            ReadSettingXml();

            if (!InitHapticSetting())
            {
                isEnable = false;
                return;
            }

            WriteSettingXml();

            InitFlag();

            InitTimer();
        }

        private void InitTimer()
        {
            autoVib = new System.Timers.Timer();
            autoVib.Interval = 10;
            autoVib.Elapsed += new System.Timers.ElapsedEventHandler(this.autoVib_Tick);
            autoVibStoptimer = new System.Timers.Timer();
            autoVibStoptimer.Interval = 30;
            autoVibStoptimer.Elapsed += new System.Timers.ElapsedEventHandler(this.autoVibStoptimer_Tick);
            // コマンド送信タイマーの生成->開始
            sendTimer = new System.Timers.Timer();
            this.sendTimer.Interval = 6;
            sendTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnElapsed_TimersTimer);
            sendTimer.Start();
        }

        void WriteSettingXml()
        {
            vibDataSetting[0] = mDataManager.Config_filename;
            vibDataSetting[1] = mDataManager.Offset_filename;
            if (comNum.IndexOf("COM") != -1)
                vibDataSetting[2] = comNum;
            XmlFileManager.WriteXml("HAPTIVITYSettings" + hapticIcCount + ".xml", vibDataSetting); //初期設定のセーブ
            hapticIcCount++;
        }

        void ReadSettingXml()
        {
            bool isSuccess;
            isSuccess = XmlFileManager.ReadXml("HAPTIVITYSettings" + hapticIcCount + ".xml", ref vibDataSetting);
            if (isSuccess)
            {
                mDataManager.Config_filename = vibDataSetting[0];
                mDataManager.Offset_filename = vibDataSetting[1];
                if (vibDataSetting[2] != null && vibDataSetting[2].IndexOf("COM") != -1)
                    comNum = vibDataSetting[2];
            }
        }

        ~Interface()
        {
            CloseCom();
            sendTimer.Dispose();
            autoVib.Dispose();
            autoVibStoptimer.Dispose();
            dResp.Dispose();
        }

        void InitFlag()
        {
            //===================================
            //受信用設定
            isWaitReply = false;
            sendItem = 0;
            readNum = 0;
            sendNum = 0;
            isReadBlock = false;
            isReceived = false;
            //===========================
        }

        void StopAllTimer()
        {
            sendTimer.Stop();
            autoVib.Stop();
            autoVibStoptimer.Stop();
            dResp.Stop();
        }
        #endregion

        #region 送信タイマー関連処理
        /// <summary>シリアル送信確認用タイマ（6msec） </summary>
        void OnElapsed_TimersTimer(object sender, EventArgs e)
        {
            if (sendNum == 0)
                return;

            sendTimer.Stop();
            if (isWaitReply == true)         //受信待ち状態チェック
            {                                
                sendTimer.Start();
                return;                      //受信コマンド待つ
            }
            isWaitReply = true;   //受信待ちフラグをON   

            //直通で送るコマンド
            if (isSendEx)
            {
                serialPort1.Write(SEND_BUFEX, 0, 1); 
                sendExItem = SEND_BUFEX[0];   //送信コマンドを残して
                isSendEx = false;
                sendTimer.Start();
                return;
            }

            bool isWrite = true;
#if RD167
            //直前に送ったコマンドがスタートコマンドなら強制振動はできない
            if (!isForcePreparation && (byte)SEND_COMMAND.START <= sendItem)
                if ((byte)SEND_COMMAND.FORCE <= SEND_BUF[0] && SEND_BUF[0] < (byte)SEND_COMMAND.START)
                {
                    isWrite = false;
                }
#endif

            sendItem = SEND_BUF[0];   //送信コマンドを残して                           


            if (isWrite)
                serialPort1.Write(SEND_BUF, 0, 1); //送信
            else
            {
                SEND_BUF[0] = (byte)SEND_COMMAND.STOP_VIB_ON;
                serialPort1.Write(SEND_BUF, 0, 1); //送信
                sendItem = (byte)SEND_COMMAND.STOP_VIB_ON;
            }

#if SENDOUTPUT                  
            Console.ForegroundColor = ConsoleColor.White;
            if (!isWrite)
            {
                Console.Write( "change(STOP)"); //debug<OUT>                      
            }
            else if ((byte)SEND_COMMAND.STOP_VIB_ON == SEND_BUF[0])
                Console.Write("STOP"); //debug<OUT>                      
            else if ((byte)SEND_COMMAND.FORCE <= SEND_BUF[0] && SEND_BUF[0] < (byte)(SEND_COMMAND.FORCE+32))
            {
                Console.Write("F"); //debug<OUT>  
            }
            else if ((byte)SEND_COMMAND.START <= SEND_BUF[0] && SEND_BUF[0] < (byte)(SEND_COMMAND.START+32))
                Console.Write(/*"\n" + */"START"); //debug<OUT>     
            else
                Console.Write(/*"\n"+ */"Other"); //debug<OUT>     
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write((sendNum-1).ToString() + " \n"); //debug<OUT>    
            Console.ResetColor(); // 色のリセット
#endif
            if (sendNum > 0)
                sendNum--; //送信バッファに残っている数を1個減らして


            //送信バッファの残りを移動
            for (int i = 0; i < sendNum; i++) 
            {
                SEND_BUF[i] = SEND_BUF[i + 1];
            }

            if (sendNum == 0)               
            {
                if (isMaxbaffaOver)  //バッファ数が最大バッファ数以上になっていたら
                {
                    isMaxbaffaOver = false;  //バッファフラグをクリア
                }
            }
            sendTimer.Start();
        }
        #endregion

        #region 受信関連処理
        /// <summary>シリアル受信確認用 <para>pat : 受信コマンド</para><para>return : 受信あるか</para></summary>
        public RECEIVE_HAPTIVITY_STATE DataReceived() 
        {
            RECEIVE_HAPTIVITY_STATE state = RECEIVE_HAPTIVITY_STATE.NONE;
            if (!isEnable) return state;

            //受信有
            if (isReceived)   
            {
                if (readNum == 0)
                {
                    //Wait_Reply = false;
                    isReceived = false;
                    return state;
                }

                //受信バッファに残っている数分READ
                while (readNum != 0)   
                {
                    if ((byte)RECEIVE_COMMAND.PUSH_MIN < READ_BUF[0] && READ_BUF[0] <= (byte)RECEIVE_COMMAND.PUSH_MAX)    //押下通知
                    {
                        state = RECEIVE_HAPTIVITY_STATE.PUSH;
                    }
                    else if ((byte)RECEIVE_COMMAND.RELEASE_MIN < READ_BUF[0] && READ_BUF[0] < (byte)RECEIVE_COMMAND.PUSH_MAX)    //リリース通知
                    {
                        state = RECEIVE_HAPTIVITY_STATE.RELEASE;
                    }
                    else if (READ_BUF[0] == (byte)RECEIVE_COMMAND.FORCE)// 強制振動通知
                    {
                        state = RECEIVE_HAPTIVITY_STATE.FORCE;
                    }
                    else //それ以外なら受信待ちフラグにより処理を変更
                    {
                        state = RECEIVE_HAPTIVITY_STATE.OTHER;

                    }

                    while (isReadBlock)
                    {
                        //受信割り込み禁止中
                    }

                    readNum--; //受信バッファに残っている数を1個減らして
#if READOUTPUT
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Green;
                    if (F1.mHaptic.readNum == 0)
                        Console.Write(F1.mHaptic.readNum + "\n"); //debug<OUT>    
                    else
                        Console.Write(F1.mHaptic.readNum + " "); //debug<OUT>    
                    Console.ResetColor(); // 色のリセット
#endif
                    for (int i = 0; i < readNum; i++) //受信バッファの残りを移動
                    {
                        READ_BUF[i] = READ_BUF[i + 1];
                    }
                }
                isWaitReply = false;  //本来は送信コマンドに対する応答エラーチェックが必要だが、今回は省略
            }
            return state;
        }
        #endregion

        #region 進入振動タイマー関係
        void dResp_Tick(object sender, EventArgs e)
        {
            dResp.Stop();

#if RD167
            //直前に送ったコマンドがスタートコマンドなら強制振動はできない
            if (!isForcePreparation && (byte)SEND_COMMAND.START <= sendItem)
                return;

            if (isForcePreparation)
                PushSendBuf(preparationCmd[0]);
#endif

            PushSendBuf((byte)((int)SEND_COMMAND.FORCE | (int)dResp.Tag));
        }

        void autoVib_Tick(object sender, EventArgs e)
        {
            if(!autoVibStoptimer.Enabled)
            autoVibStoptimer.Start();

#if RD167
            //直前に送ったコマンドがスタートコマンドなら強制振動はできない
            if (!isForcePreparation && (byte)SEND_COMMAND.START <= sendItem)
                return;

            if (isForcePreparation)
                PushSendBuf(preparationCmd[0]);
#endif
            PushSendBuf((byte)((int)SEND_COMMAND.FORCE | autoVibPat));
        }

        void autoVibStoptimer_Tick(object sender, EventArgs e)
        {
            autoVibStoptimer.Stop();
            autoVib.Stop();
#if RD167
            StartVibration(vibPatAfterEnter, icAfterEnter);
#else 
            StartVibration(vibPatAfterEnter);
#endif
        }

        void Closing_Timer_Tick(object sender, EventArgs e)
        {
            StopModeChangeTimer.Stop();
            DoAfterStopMode();//デリゲード
        }
        #endregion

        #region ボタン進入振動関連
#if RD167
        public void EnterVibration(int vpat, int IC, int autoVibPat = INITENTERVIBPATTERN, int vibTime = VIBTIME)
#else
        public void EnterVibration(int vpat, int autoVibPat = INITENTERVIBPATTERN, int vibTime = VIBTIME)
#endif
        {
            if (!isEnable) return;

            //進入振動していれば抜ける
            if (autoVib.Enabled)
                return;
            
            vibPatAfterEnter = vpat;
#if RD167
            icAfterEnter = IC;
#endif

            this.autoVibPat = autoVibPat;
            autoVib.Start();
            autoVibStoptimer.Interval = vibTime;

#if RD167
            isForcePreparation = false;
#endif
        }

        public void LeaveVibration()
        {
            if (!isEnable) return;

            autoVib.Stop();
            autoVibStoptimer.Stop();
            StopVibration();
        }
        #endregion

        #region Haptic動作処理
        public void ForcedVibration(bool isStartMode)
        {
            ForcedVibration(INITENTERVIBPATTERN, isStartMode);
        }
        public void ForcedVibration(int autoVibPat = INITENTERVIBPATTERN,bool isStartMode = false)
        {
            if (!isEnable) return;

#if RD167
            isForcePreparation = isStartMode;
#endif
            dResp.Tag = autoVibPat;
            //dResp.Start();
            PushSendBuf((byte)((int)SEND_COMMAND.FORCE | (int)dResp.Tag));
        }

        public void StartTracingVibration(int autoVibPat = INITENTERVIBPATTERN, bool isStartMode = false, int distance = 10)
        {
            if (!isEnable) return;

            preMousePoint = System.Windows.Forms.Cursor.Position;

#if RD167
            isForcePreparation = isStartMode;
#endif
            intervalDis = distance;
            TracingVibrationTimer.Tag = autoVibPat;
            TracingVibrationTimer.Start();
        }

        public void EndTracingVibration()
        {
            if (!isEnable) return;

            TracingVibrationTimer.Stop();
            StopVibration();
        }

        void TracingVibrationTimer_Tick(object sender, EventArgs e)
        {
            int disx = Math.Abs(System.Windows.Forms.Cursor.Position.X - preMousePoint.X);
            int disy = Math.Abs(System.Windows.Forms.Cursor.Position.Y - preMousePoint.Y);
            int dis2 = disx + disy;
            if (dis2 / 2 < intervalDis)
                return;

            preMousePoint = System.Windows.Forms.Cursor.Position;
#if RD167
            if (isForcePreparation)
                PushSendBuf(preparationCmd[0]);
#endif
            PushSendBuf((byte)((int)SEND_COMMAND.FORCE | (int)TracingVibrationTimer.Tag));
        }

#if RD167
        public void StartVibration(int configNo, int IC, bool EX = false)
        {
            if (!isEnable) return;

            preSendConfigNo = configNo;
            //他のICが待機中になっている場合、ストップ状態に戻す
            if (IC != preIc)
            {
                PreCancelOperation();
                StopVibration();
            }
            preIc = IC;
            byte Send_data = (byte)(configNo << 2);
            Send_data += (byte)IC;

            if (EX) PushHeadSendBuf((byte)((int)SEND_COMMAND.START | Send_data));  // シリアルポートにデータ送信(START）Express
            else PushSendBuf((byte)((int)SEND_COMMAND.START | Send_data));    // シリアルポートにデータ送信(START）
        }
#else
        public void StartVibration(int configNo, bool EX = false)
        {
            if (!isEnable) return;
#if SENDOUTPUT
                Console.Write("Start" + configNo + "\n"); //debug<OUT>                      
#endif
            preSendConfigNo = configNo;
            AutoOffsetSetting();
            
            byte Send_data = (byte)(configNo);
            if (EX) PushHeadSendBuf((byte)((int)SEND_COMMAND.START | Send_data));  // シリアルポートにデータ送信(START）Express
            else PushSendBuf((byte)((int)SEND_COMMAND.START | Send_data));    // シリアルポートにデータ送信(START）
        }
#endif

#if RD167
        public void PreCancelOperation()
        {
            if (!isEnable) return;
            PushSendBuf(preparationCancelCmd);
        }
#endif

        public void StopVibration(bool EX_flag = false)
        {
            if (!isEnable) return;

            sendTimer.Interval = 6;

            if (EX_flag)
            {
                byte[] stopCommand = new byte[] { (byte)SEND_COMMAND.STOP_VIB_ON };
                serialPort1.Write(stopCommand, 0, 1); //送信
                //SRL_SendEX((byte)SEND_COMMAND.STOP_VIB_ON);    // シリアルポートにデータ送信(STOPT）
            }
            else
            {
                PushSendBuf((byte)SEND_COMMAND.STOP_VIB_ON);    // シリアルポートにデータ送信(STOPT）
            }
        }

        public void StopVibrationAfterDgt(Action method)
        {
            if (!isEnable)
            {
                method();
                return;
            }

            //モードを停止状態にして0.5秒間流す
            StopVibration(true);

            //StopModeに移行した後の処理
            DoAfterStopMode = method;
            StopModeChangeTimer.Start();
        }
        #endregion

        #region オフセット設定
        /// <summary>カーソル座標からオフセットを割り出し、コンフィグセットする 分割は5x3 <para>configNum</para></summary>
#if RD167
#else
        void AutoOffsetSetting()
        {
            int x = System.Windows.Forms.Cursor.Position.X - focusForm.Location.X;
            Point divisionNum = new Point(5, 3);
            float scaling = divisionNum.X / (float)focusForm.Size.Width;
            int dx = (int)(x * scaling);

            int y = System.Windows.Forms.Cursor.Position.Y - focusForm.Location.Y;
            scaling = divisionNum.Y / (float)focusForm.Size.Height;
            int dy = (int)(y * scaling);

            SetLocation(dx, dy);
        }

        public void SetLocation(int x, int y)
        {
            if (!isEnable) return;

            if (x != -1)
            {
                byte Send_data = (byte)SEND_COMMAND.LOCATION;
                Send_data += 0x00;      // X座標指定
                Send_data += (byte)x;         // 座標値設定
                PushSendBuf(Send_data);    // コマンド
                System.Threading.Thread.Sleep(10);   //10ms待つ

            }
            if (y != -1)
            {
                byte Send_data = (byte)SEND_COMMAND.LOCATION;
                Send_data += 0x10;      // Y座標指定
                Send_data += (byte)y;         // 座標値設定
                PushSendBuf(Send_data);    // コマンド
                System.Threading.Thread.Sleep(10);   //10ms待つ     
            }
        }

#endif
        void LoadConfig(object sender, KeyEventArgs e)
        {
            if (!isEnable) return;

            if (e.KeyData == Keys.H)
            {
                //シリアルポートからHapICにダウンロード
                if (!FileLoader.ShowForm(focusForm, serialPort1))
                    isEnable = false;//失敗したら
            }
        }
        #endregion
    }
}
