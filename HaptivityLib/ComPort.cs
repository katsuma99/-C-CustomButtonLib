//#define SENDOUTPUT
//#define READOUTPUT

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;            //ファイル出力用
using System.Management;    //ポート詳細取得用 (プロジェクト/参照の追加 .NETタブ) 
using System.Timers;        //非同期タイマー

namespace StatusBar
{
    partial class Interface
    {
        #region 各種変数
        public string comNum = null;        //COMポート

        public static bool isCheckResponse = true;        //initコマンドでエラー確認する
        public static int rcvInitCommand = 0;             //INIT_COMMAND受信確認用
        public static int modeChangeState = 0;            //モード移行コマンド待ち 

        byte sendItem = (byte)SEND_COMMAND.STOP_VIB_OFF;         //送信済みコマンド

        public static bool isReadBlock;                    //受信割り込み禁止フラグ
        public static bool isReceived;                     //受信フラグ
        public static bool isWaitReply;                    //受信待ちフラグ

        bool isStartState = false;           //haptic start or stop状態
        bool isMaxbaffaOver = false;         //バッファが最大バッファを超えた時のフラグ

        
        //シリアル通信用バッファ
        byte[] READ_TEMP_BUF = new byte[1024];      //READバッファ（一時的）
        public static byte[] READ_BUF = new byte[1024];    //READバッファ
        public static byte[] SEND_BUF = new byte[1024];    //SENDバッファ
        int readNum;                                //受信バッファに残っている数
        int sendNum;                                //送信バッファに残っている数
        const int maxBuffaNum = 12;                 //SEND_BUFの最大バッファ数


        bool isSendEx;                              // EXPRESS send
        int sendExItem;                             // EXPRESS send
        public byte[] SEND_BUFEX = new byte[1024];  //SENDバッファ
        public static System.Timers.Timer timerTimeout;
        #endregion

        #region 初期化関連
        /// <summary>Haptic初期設定（COMポート、コンフィグ表作成） </summary>
        bool InitHapticSetting()
        {
            //シリアルポート先のエラーによるタイムアウトのための非同期Timer
            timerTimeout = new System.Timers.Timer();
            timerTimeout.Elapsed += new ElapsedEventHandler(OnElapsed_TimeoutTimer);
            timerTimeout.Interval = 3000;

            System.Windows.Forms.Cursor.Show();

            // COMポート設定→失敗でマウスモード
            bool isSuccess = InitPortSetting();

            System.Windows.Forms.Cursor.Hide();

            if (isSuccess == false)
            {
                // ユーザーがCOMを全て選択しなかった/開けるCOMがなかった場合はマウスモード動作
                MsgBox.ShowActiveFormCenter("Don't connect the HAPTIVITY.", "", MessageBoxButtons.OK, MessageBoxIcon.Information,
                                            focusForm);
                return false;
            }

            mDataManager.LoadConfigFile(mDataManager.Config_filename);
            return true;
        }

        public void CloseCom()
        {
            if (!isEnable) return;

            StopAllTimer();
            serialPort1.Close();    // シリアルポートのクローズ
            serialPort1.Dispose();

            //シリアルポートのクローズ待ち
            System.Threading.Thread.Sleep(100);
        }

        /// <summary>Comの自動認識->Comオープン->InitCommand送信->HAPTIVITYMode or MouseMode起動<para>return:true(成功)false(失敗)</para></summary>
        bool InitPortSetting()
        {
            // 初期化コマンドが返ってくるまでは何も受け付けなくする
            this.Enabled = false;

            //ComPortをテキストで指定
            TextConnectComport();

            //ComPortを自動で認識する
            AutoConnectComport();

            //ComPortを手動で指定
            if (!ManualConnectComport())
            {
                this.Enabled = true;
                rcvInitCommand = 4;
                return false;
            }

            //Comポート接続成功->HAPTIVITYモードに移行

            return true;
        }

        bool TextConnectComport()
        {
            if (comNum == null || comNum == "")
                return false;//comNumが指定されていなかったら飛ばす

            return TestHAPTIVITY();
        }

        bool TestHAPTIVITY()
        {
            if (comNum == null || comNum == "")
                return false;//comNumが指定されていない

            if (!OpenCom())
            {
                //Comオープンできなかったら再設定
                comNum = null;
                return false;
            }

            if (!SendHapticInitCommand())
            {
                //HAPTIVITYではないとき再設定
                comNum = null;
                return false;
            }
            return true;
        }

        bool SendHapticInitCommand()
        {
            if (!serialPort1.IsOpen)
                return false;

            // INIT_COMMAND送信
            Byte[] datR2 = new byte[1024];      // バッファクリア

            SEND_BUF[0] = (byte)SEND_COMMAND.INIT; // 0x00;
            rcvInitCommand = 0;
            isCheckResponse = true;
            serialPort1.Write(SEND_BUF, 0, 1);  // シリアルポートにデータ送信(初期化）

            timerTimeout.Start();
            while (rcvInitCommand == 0)
                System.Threading.Thread.Sleep(1);
            timerTimeout.Stop();

            if (rcvInitCommand != 1)
            {
                //適切にINITできなかったとき
                MsgBox.ShowActiveFormCenter( comNum.ToString() + " don't connect HAPTIVITY IC.",
                                                "Error",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error,
                                                focusForm);
                return false;
            }
            return true;
        }

        bool OpenCom()
        {
            // COMオープン→失敗でマウスモード動作
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();    // シリアルポートのクローズ
                serialPort1.Dispose();
            }

            //シリアルポートのクローズ待ち
            System.Threading.Thread.Sleep(100);

            if (com_open() == false)
            {
                this.Enabled = true;
                rcvInitCommand = 4;
                
                return false;
            }
            return true;
        }

        bool ManualConnectComport()
        {
            if (comNum != null && comNum != "")
                return true;//comNumが決まっていたら飛ばす

            MsgBox.ShowActiveFormCenter("Serial port can not be found.\nStart the manual mode.",
                                "",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                focusForm);

            // シリアルポート名を選択するダイアログを生成する
            ComPortEntry comentry = new ComPortEntry();
            comentry.Size = new Size((int)(focusForm.Size.Width * 0.8)
                                        , (int)(focusForm.Size.Height * 0.8));

            comentry.StartPosition = FormStartPosition.Manual;

            //Form中央に設定
            comentry.Location = new Point(
    focusForm.Location.X + (focusForm.Width - comentry.Width) / 2,
    focusForm.Location.Y + (focusForm.Height - comentry.Height) / 2);

            comentry.ShowDialog();
            comNum = comentry.COM_NUM;

            return TestHAPTIVITY();
        }

        bool AutoConnectComport()
        {
            if (comNum != null && comNum != "")
                return true;//comNumが決まっていたら飛ばす

            // COMポート自動認識
            ManagementClass mcPnPEntity = new ManagementClass("Win32_PnPEntity");
            ManagementObjectCollection mcW32SerPort = mcPnPEntity.GetInstances();

            foreach (ManagementObject aSerialPort in mcW32SerPort)
            {
                // Nameプロパティを取得
                var namePropertyValue = aSerialPort.GetPropertyValue("Name");
                if (namePropertyValue == null)
                {
                    continue;
                }

                // Nameプロパティ文字列の一部が"(COM1)～(COM999)"と一致するときリストに追加"
                string name = namePropertyValue.ToString();

                if (0 <= name.IndexOf("Serial")&& 0 <= name.IndexOf("COM"))
                {

                    int begin = name.IndexOf("(") + 1;
                    int end = name.IndexOf(")");

                    comNum = name.Substring(begin, end - begin);
                    if (TestHAPTIVITY())
                    {
                        MsgBox.ShowActiveFormCenter(comNum.ToString() + " is found.", "Auto Connect", MessageBoxButtons.OK, MessageBoxIcon.Information,
                                                focusForm);
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary> COMオープンの処理<para>return : 成功 or 失敗</para></summary>
        bool com_open()
        {
            if (serialPort1.IsOpen)
                return true;

            // シリアルポートのオープン事前処理
            serialPort1.PortName = comNum;                        // COMポート名
            serialPort1.BaudRate = 115200;                         // 通信速度
            serialPort1.Parity   = System.IO.Ports.Parity.None;    // パリティ
            serialPort1.DataBits = 8;                              // ビット数
            serialPort1.StopBits = System.IO.Ports.StopBits.One;   // ストップビット

            // COMオープン
            try
            {
                serialPort1.Open();
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
            catch (IOException)
            {
                return false;
            }

            return true;
        }

        public void ClearSendBuffer()
        {
            if (!isEnable) return;

            isMaxbaffaOver = false;

            if (!sendTimer.Enabled)
            {
                sendNum = 0;
                return;
            }
            else
            {
                sendTimer.Stop();
                sendNum = 0;
                sendTimer.Start();
            }
        }
        #endregion

        #region タイマー関連処理
        /// <summary> 初期化コマンド応答受信待ちタイマ（1.5sec）非同期</summary>
        void OnElapsed_TimeoutTimer(object sender, ElapsedEventArgs e)
        {
            rcvInitCommand = 3;  // タイムアウト
        }
        #endregion

        #region シリアル送信
        void PushHeadSendBuf(byte Send) //シリアル送信関数＊BUF_i=送信区分,i=位置,BUF_DD=内容＊＊＊
        {
            sendTimer.Stop();
            isSendEx = true;
            SEND_BUFEX[0] = Send;
            sendTimer.Start();
        }

        void PushSendBuf(byte Send) //シリアル送信関数＊BUF_i=送信区分,i=位置,BUF_DD=内容＊＊＊
        {
            sendTimer.Enabled = false;
            if (sendNum < maxBuffaNum)   //バッファ数が最大バッファ数未満
            {
                SEND_BUF[sendNum] = Send;  //送信バッファにためて
                sendNum++;                 //カウントUP
#if SENDOUTPUT
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(Send_Num + " "); //debug<OUT>    
                    Console.ResetColor(); // 色のリセット
#endif
                //startに対するstopは最大バッファ数を超えても送信するよう、フラグを立てる
                if ((int)Send >= (int)SEND_COMMAND.START && (int)Send < (int)SEND_COMMAND.START + 0x42)
                {
                    isStartState = true;
                }
                else if ((int)Send == (int)SEND_COMMAND.STOP_VIB_ON)
                {
                    isStartState = false;
                }

            }
            else    //バッファ数が最大バッファ数以上
            {
                isMaxbaffaOver = true;   //バッファ数が最大バッファ数以上になったことを示すフラグを立てる

                if ((int)Send == (int)SEND_COMMAND.STOP_VIB_ON)    //start処理に対応するstop処理、stop意外のSend処理はスルー
                {
                    if (isStartState)  //start状態であれば
                    {
                        SEND_BUF[sendNum] = Send;  //送信バッファにためて
                        sendNum++;                 //カウントUP
#if SENDOUTPUT
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("MAX_STOP "); //debug<OUT> 
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(Send_Num + " "); //debug<OUT>    
                            Console.ResetColor(); // 色のリセット
#endif
                        isStartState = false;
                    }
                }
            }
            sendTimer.Start();
        }
        #endregion

        #region シリアル受信
        void SerialPortDataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (readNum > maxBuffaNum)   //バッファ数が最大バッファ数以上
                return;

            isWaitReply = true;

            int RcvLength = 0;
            // データ読み込み
            try
            {
                RcvLength = serialPort1.Read(READ_TEMP_BUF, 0, READ_TEMP_BUF.GetLength(0));   //通信複数データ取得　元=serialPort1.Read(dat, 0, 1);
            }
            catch (IOException)
            {
                MessageBox.Show("Received Error",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }

            isReceived = false;   //受信フラグをOFF
            isReadBlock = true;  //受信割り込み禁止フラグをON（処理が終わるまでは割り込み禁止）
            if (!isCheckResponse)
                sendTimer.Stop();

            for (int i = 0; i < RcvLength; i++)
            {
                READ_BUF[readNum] = READ_TEMP_BUF[i];  //一時バッファからREADバッファにコピー
                readNum++;                             //残りバッファ数をインクリメント

#if READOUTPUT
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(readNum); //debug<OUT> 

                Console.ForegroundColor = ConsoleColor.Gray;
                if ((byte)SEND_COMMAND.STOP_VIB_ON == READ_TEMP_BUF[i])
                    Console.Write("(STOP)"); //debug<OUT>                      
                else if (32 == READ_TEMP_BUF[i])
                {
                    Console.Write("(F)"); //debug<OUT>  
                }
                else if (4 == READ_TEMP_BUF[i])
                    Console.Write("(START)"); //debug<OUT>     
                else if (41 == READ_TEMP_BUF[i])
                    Console.Write("(DOWN)"); //debug<OUT>     
                else if (49 == READ_TEMP_BUF[i])
                    Console.Write("(UP)"); //debug<OUT>     
                else
                    Console.Write("(Other" + READ_TEMP_BUF[i]+")" ); //debug<OUT>   

                Console.ResetColor(); // 色のリセット
#endif
            }

            if (!isCheckResponse)
                sendTimer.Start();
            isWaitReply = false;  //本来は送信コマンドに対する応答エラーチェックが必要だが、今回は省略
            isReadBlock = false;  //受信割り込み禁止フラグをOFF
            isReceived = true;   //受信フラグをON



            if (!isCheckResponse)
            return;

            isCheckResponse = false;
            while (readNum != 0)
            {
                if (rcvInitCommand == 0)  // 初期化コマンド待ち状態
                {
                    if (READ_BUF[readNum] == 0x00) // 成功
                    {
                        rcvInitCommand = 1;
                        readNum--;             //受信バッファに残っている数を1個減らす
                    }
                    else // 失敗
                    {
                        rcvInitCommand = 2;
                    }
                }
                else if (modeChangeState == 1)
                {
                    if (READ_BUF[readNum-1] == 0x18) // 成功
                    {
                        modeChangeState = 2;
                        readNum--;             //受信バッファに残っている数を1個減らす
                    }
                    else // 失敗
                    {
                        modeChangeState = 0xff;
                        return;
                    }
                }
                else if (modeChangeState == 2)
                {
                    if (READ_BUF[readNum-1] == 0xfc)
                    {
                        modeChangeState = 3;
                        readNum--;             //受信バッファに残っている数を1個減らす
                    }
                    else // 失敗
                    {
                        modeChangeState = 0xff;
                        return;
                    }
                }
                else if (modeChangeState == 4)
                {
                    if (READ_BUF[readNum - 1] == 0x18) // 成功
                    {
                        modeChangeState = 5;
                        readNum--;             //受信バッファに残っている数を1個減らす
                    }
                    else // 失敗
                    {
                        modeChangeState = 0xff;
                        return;
                    }
                }
            }
        }
        #endregion

    }
}
