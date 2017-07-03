using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace HAPTIVITYLib
{
    public partial class FileLoader : Form
    {
        #region 各種変数
        //Configファイル格納用バッファ
        byte[] CONFIG_BUF;
        List<byte[]> CONFIG_BUF_TABLE = new List<byte[]>();
#if RD167
        //現在使用してない
        byte[] OFFSET_BUF;      //Offsetファイル格納用バッファ
        List<List<byte[]>> OFFSET_BUF_TABLE = new List<List<byte[]>>();       //Offsetファイル格納用バッファ(表管理)
#endif

        //Config Offset data file name
        public string Config_filename = null;
        public string Offset_filename = null;

        const int ROWNUM = 16;
        const int COLUMNNUM = 16;
        const int DATANUM = 16;
        #endregion

        #region ボタン処理
        public FileLoader(System.IO.Ports.SerialPort serialPort1)
        {
            InitializeComponent();
            this.serialPort1 = serialPort1;
        }

        private void FileLoader_Load(object sender, EventArgs e)
        {
            InitFormState();
        }

        /// <summary>Formの位置、プロパティ、プログレスバー状態を初期化 </summary>
        void InitFormState()
        {
            if (Owner == null)
                return;
            //Form中央にダイアログが表示されるように設定
            this.Location = new Point(
    Owner.Location.X + (Owner.Width - this.Width) / 2,
    Owner.Location.Y + (Owner.Height - this.Height) / 2);

            //コントロールプロパティの初期化
            this.label_DL.Visible = false;
            this.button_YES.Enabled = true;
            this.button_NO.Enabled = true;
            textBox_Config.Text = Config_filename;
            //プログレスバーの初期化
            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = 100;
            this.progressBar1.Value = 0;
        }

        public bool isSuccess = false;       //Form1に返す戻り値
        System.IO.Ports.SerialPort serialPort1;
        //ダイアログ開く（引数を与えて、戻り値を貰う）
        static public bool ShowForm(Form owner, System.IO.Ports.SerialPort serialPort1)
        {
            FileLoader f = new FileLoader(serialPort1);
            f.ShowDialog(owner);
            bool isSuccess = f.isSuccess;
            f.Dispose();

            return isSuccess;
        }

        void SetConfigFilename()
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();

            //はじめのファイル名を指定する
            //はじめに「ファイル名」で表示される文字列を指定する
            ofd.FileName = Config_filename;

            //[ファイルの種類]に表示される選択肢を指定する
            //指定しないとすべてのファイルが表示される
            ofd.Filter = "コンフィグファイル(*.cfg)|*.cfg|すべてのファイル(*.*)|*.*";
            //[ファイルの種類]ではじめに選択されるものを指定する
            ofd.FilterIndex = 1;

            //タイトルを設定する
            ofd.Title = "開くファイルを選択してください";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Config_filename = ofd.SafeFileName;
            }

            textBox_Config.Text = Config_filename;
        }

        void SetConfigPowerFilename()
        {
#if RD167
            if (Config_filename.Substring(12, 2) == "_L")
                textBox_Config.Text = "Light";
            else if (Config_filename.Substring(12, 2) == "_H")
                textBox_Config.Text = "Heavy";
            else if (Config_filename.Substring(12, 2) == "_S")
                textBox_Config.Text = "Specified";
            else if (Config_filename.Substring(12, 2) == "_B")
                textBox_Config.Text = "Base";
            else
                textBox_Config.Text = "Middle";
#else
            if (Config_filename.Substring(18, 2) == "_L")
                textBox_Config.Text = "Light";
            else if (Config_filename.Substring(18, 2) == "_H")
                textBox_Config.Text = "Heavy";
            else if (Config_filename.Substring(18, 2) == "_S")
                textBox_Config.Text = "Specified";
            else if (Config_filename.Substring(18, 2) == "_B")
                textBox_Config.Text = "Base";
            else
                textBox_Config.Text = "Middle";
#endif
        }

        void reference_Click(object sender, EventArgs e)
        {
            SetConfigFilename();
        }

        void button_YES_Click(object sender, EventArgs e)
        {
            //Configファイルのダウンロード開始
            Invoke(new Action(LabelDLVisible));
            this.button_YES.Enabled = false;
            this.button_NO.Enabled = false;

            isSuccess = LoadConfigFile(Config_filename);
            this.Close();
        }

        void button_NO_Click(object sender, EventArgs e)
        {
            this.button_YES.Enabled = false;
            this.button_NO.Enabled = false;
            isSuccess = true; //ダウンロードせずにキャンセルなのでHapは現状使える

            this.Close();
        }

        void LabelDLVisible()
        {
            this.label_DL.Visible = true;
        }
        #endregion

        #region ロード関連
        public bool LoadConfigFile(string fileName)
        {
            bool isSucceed = MakeConfigTable(fileName);//RD167でのオフセット変更のため(コンフィグのx,yを変更・DLすることでオフセット変更する)
            if (isSucceed)
            {
                return SendConfig();
            }
            return true; //ファイル読み込めないからキャンセルと同じ処理
        }

        bool MakeConfigTable(string fileName)
        {
            if (fileName == null || fileName == "")
            {
                return false;
            }

            //ファイルオープン処理
            string filename = @fileName;

            // open the file
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
                {
                    CONFIG_BUF = new byte[fs.Length];
                    // read the file
                    fs.Read(CONFIG_BUF, 0, CONFIG_BUF.Length);
                }
            }
            catch (IOException)
            {
                MsgBox.ShowActiveFormCenter("Can't open Config file!\n Don't load config and start HAPTIVITY.",
                                                "",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Information,
                                                Interface.focusForm);
                return false;
            }


            // CONFIG_BUT_TABLEにデータを格納
            const int configPattern = 32;
            CONFIG_BUF_TABLE.Clear();
            for (int y = 0; y < configPattern; y++)    // 各行を順に格納
            {

                const int dataSize = 32;
                var configCellData = new byte[dataSize];
                Array.Copy(CONFIG_BUF, y * dataSize, configCellData, 0, dataSize);

                // OFFSET_BUT_ROWに21Byte分のデータを格納
                CONFIG_BUF_TABLE.Add(configCellData);
            }
            return true;
        }

        public bool SendConfig(int x = -1, int y = -1, int configNum = -1)
        {
            if (CONFIG_BUF_TABLE.Count == 0)
            {
                //table作ってから送る
                if (Config_filename != null)
                    MakeConfigTable(Config_filename);
                else
                    return false;
            }

            Interface.isWaitReply = true;

            //追加Haptic要デバッグ
            //SEND_BUF[0] = (byte)SEND_COMMAND.STOP_VIB_ON; // 0x00;
            //serialPort1.Write(SEND_BUF, 0, 1);  // シリアルポートにデータ送信(初期化）
            //System.Threading.Thread.Sleep(200);


            Interface.SEND_BUF[0] = (byte)Interface.SEND_COMMAND.MODE_VIB;
            if (!CheckModeChange(1, Interface.SEND_BUF, "Fail to change loadconfigmode!"))
            {
                //モードチェンジ失敗
                return false;
            }

            const int configPattern = 32;
            for (int i = 0; i < configPattern; i++)
            {
                if (configNum != -1 && configNum != i) //configNumが-1であればすべて書き換える
                    continue;

                this.progressBar1.Value = 100 * (i + 1) / configPattern;


                Interface.SEND_BUF[0] = (byte)i;
                if (!CheckModeChange(2, Interface.SEND_BUF, "Fail to Set Config data!"))
                {
                    //モードチェンジ失敗
                    return false;
                }

                byte[] data = new byte[32];
                CONFIG_BUF_TABLE[i].CopyTo(data, 0);

#if RD167
                //x,y != -1のときは、コンフィグのX、Yを変更してインストール
                if (x != -1)
                {
                    const int COLUMNOFX = 19;
                    data[COLUMNOFX] = (byte)x;
                }
                if (y != -1)
                {
                    const int COLUMNOFY = 20;
                    data[COLUMNOFY] = (byte)y;
                }
#endif

                if (!CheckModeChange(2, data, "Fail to Set Config data!"))
                {
                    //モードチェンジ失敗
                    return false;
                }
            }

            // 200ms待つ
            System.Threading.Thread.Sleep(200);

            // シリアルポートにモード終了コマンドを送信
            Interface.SEND_BUF[0] = (byte)Interface.SEND_COMMAND.MODE_END;
            if (!CheckModeChange(4, Interface.SEND_BUF, "Fail to Download Config file!"))
            {
                //モードチェンジ失敗
                return false;
            }

            Interface.isWaitReply = false;
            return true;
        }

        bool CheckModeChange(int state, byte[] sendBuf, string errorComment)
        {
            //モード移行コマンド送信
            Interface.modeChangeState = state;
            Interface.isCheckResponse = true;

            if (state == 3)
            {
#if RD167
                // シリアルポートに21Byte分のデータ送信
                serialPort1.Write(sendBuf, 0, 21);
#else
                serialPort1.Write(sendBuf, 0, 22);
#endif
            }
            else
            {
                serialPort1.Write(sendBuf, 0, 1);
            }

            Interface.timerTimeout.Start();
            while (Interface.modeChangeState == state)
                System.Threading.Thread.Sleep(1);
            Interface.timerTimeout.Stop();

            if (Interface.modeChangeState == 0xff)
            {
                //error
                MsgBox.ShowActiveFormCenter(errorComment,
                                                "",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Information,
                                                Interface.focusForm);
                Close();
                return false;
            }
            return true;
        }

        //[使用不可]オフセットファイルは基本的にHapticDebuggerで調整し、出荷するためオフセットファイルの変更はソフトでしない。
#if RD167   //動的にオフセットを変更することができないため、現在はコンフィグのxyを変更して押下強度を変更している。
            //*RD167ではHapticのINITする前でないと、書き込めないようになっている!!
        void MakeOffsetTable()
        {
            //ファイルオープン処理
            string filename = @Offset_filename;

            // open the file
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
                {
                    OFFSET_BUF = new byte[fs.Length];
                    // read the file
                    fs.Read(OFFSET_BUF, 0, OFFSET_BUF.Length);
                }
            }
            catch (IOException)
            {
                MsgBox.Show(focusForm, "Can't open Offset file!",
                                                "Error",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);
                Close();
                
                isEnable = false;
                return;
            }


            // OFFSET_BUT_TABLEにデータを格納
            for (int y = 0; y < ROWNUM; y++)    // 各行を順に格納
            {
                this.progressBar1.Value = 100 * (y + 1) / ROWNUM;

                List<byte[]> OFFSET_BUF_ROW = new List<byte[]>();

                for (int x = 0; x < DATANUM; x++)    // 列を回して1行分のデータを格納
                {
                    var offsetCellData = new byte[16];
                    Array.Copy(OFFSET_BUF, y * ROWNUM * DATANUM + x * DATANUM, offsetCellData, 0, 16);

                    // OFFSET_BUT_ROWに16Byte分のデータを格納
                    OFFSET_BUF_ROW.Add(offsetCellData);
                }
                OFFSET_BUF_TABLE.Add(OFFSET_BUF_ROW);

            }

        }

        void SendOffset()
        {
            if (OFFSET_BUF_TABLE.Count == 0)
            {
                //table作ってから送る
                MakeOffsetTable();
            }

            //モード移行コマンド送信
            SEND_BUF[0] = (byte)SEND_COMMAND.MODE_OFF;
            if (!CheckModeChange(1, SEND_BUF, "Fail to change loadoffsetmode!"))
            {
                //モードチェンジ失敗
                return;
            }

            byte[] data_512byte = new byte[512];

            // シリアルポートに4096Byte分のデータ送信(すべてのデータ)
            for (int y = 0; y < ROWNUM; y++)
            {
                // 512Byteごとに順に格納
                int turnNum = 0;
                //8分割して送る
                if (y % (int)(ROWNUM / 8) != 0)
                    turnNum++;

                // データ表から行（y）を抜き出す
                var OFFSET_BUF_ROW = OFFSET_BUF_TABLE[y];
                for (int x = 0; x < COLUMNNUM; x++)
                {
                    // 行から列を指定してdataを抜き出す 
                    byte[] data = OFFSET_BUF_ROW[x];
                    for (int d = 0; d < DATANUM; d++)
                    {
                        data_512byte[d + DATANUM * x + turnNum * DATANUM * COLUMNNUM] = data[d];
                    }
                }

                if (y % (int)(ROWNUM / 8) != (int)(ROWNUM / 8) - 1)
                    continue;



                Interface.modeChangeState = 2;

                // シリアルポートに4096Byte分のデータ送信(すべてのデータ)
                serialPort1.Write(data_512byte, 0, 512);

                while (Interface.modeChangeState == 2)
                    System.Threading.Thread.Sleep(1);
            }



            // 200ms待つ
            System.Threading.Thread.Sleep(200);

            Interface.modeChangeState = 4;

            // シリアルポートにモード終了コマンドを送信
            SEND_BUF[0] = (byte)SEND_COMMAND.MODE_END;
            if (!CheckModeChange(4, SEND_BUF, "Fail to Download Config file!"))
            {
                //モードチェンジ失敗
                return;
            }
        }

        public void SendOffset(int x, int y)
        {
            if (!isEnable) return;
            //*HapticのINITする前でないと、書き込めないようになっている!!


            if (OFFSET_BUF_TABLE.Count == 0)
            {
                //table作ってから送る
                MakeOffsetTable();
            }

            //モード移行コマンド送信
            SEND_BUF[0] = (byte)SEND_COMMAND.MODE_OFF;
            if (!CheckModeChange(1, SEND_BUF, "Fail to change loadoffsetmode!"))
            {
                //モードチェンジ失敗
                return;
            }

            // データ表から行（y）を抜き出す
            var OFFSET_BUF_ROW = OFFSET_BUF_TABLE[y];
            // 行から列を指定してdataを抜き出す 
            byte[] data = OFFSET_BUF_ROW[x];


            // シリアルポートに16Byte分のデータ送信(x:0,y:0の分だけ)
            Interface.isCheckResponse = true;
            serialPort1.Write(data, 0, 16);
            Interface.modeChangeState = 2;

            while (Interface.modeChangeState == 2)
                System.Threading.Thread.Sleep(1);


            //// シリアルポートに4096Byte分のデータ送信(すべてのデータ)
            //byte[] data_512byte = new byte[512];
            //for (int i = 0; i < 512; i++)
            //    data_512byte[i] = data[i % 16];

            //// 512byte * 8 = 4098byte
            //for (int send_num = 0; send_num < 8; send_num++)
            //{
            //    mode_change_state = 2;

            //    // シリアルポートに4096Byte分のデータ送信(すべてのデータ)
            //    serialPort.Write(data_512byte, 0, 512);

            //    while (mode_change_state == 2)
            //        System.Threading.Thread.Sleep(1);
            //}


            if (Interface.modeChangeState == 0xff)
            {
                MsgBox.Show(focusForm, "Fail to Set Offset data!",
                                                "Error",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);
                Close();
                
                isEnable = false;
                return;
            }

            // 200ms待つ
            System.Threading.Thread.Sleep(200);

            Interface.modeChangeState = 4;

            // シリアルポートにモード終了コマンドを送信
            SEND_BUF[0] = (byte)SEND_COMMAND.MODE_END;
            Interface.isCheckResponse = true;
            serialPort1.Write(SEND_BUF, 0, 1);

            while (Interface.modeChangeState == 4)
                System.Threading.Thread.Sleep(1);

            if (Interface.modeChangeState == 0xff)
                MsgBox.Show(focusForm, "Fail to Download Config file!",
                                                "Error",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);
            
        }
#endif
        #endregion


    }
}
