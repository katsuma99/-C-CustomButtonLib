using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;    //ポート詳細取得用 (プロジェクト/参照の追加 .NETタブ) 

namespace StatusBar
{
    public partial class ComPortEntry : Form
    {

        #region 各種変数

        public string COM_NUM = "";

        #endregion

        public ComPortEntry()
        {
            InitializeComponent();
        }

        private void ComPortEntry_Load(object sender, EventArgs e)
        {
            //初期設定
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            //this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ControlBox = false;

            this.Enabled = true;

            

            //this.FormBorderStyle = FormBorderStyle.None;


            // Comの情報を所得
            List<string> comName = new List<string>();
            List<string> comNum = new List<string>();
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

                //追加Haptic要デバッグ
                if (0 <= name.IndexOf("(COM"))
                {
                    int begin = name.IndexOf("(") + 1;
                    int end = name.IndexOf(")");

                    comNum.Add(name.Substring(begin, end - begin));
                    comName.Add(name.Substring(0, begin - 1));
                }
            }

            // すべてのシリアル・ポート名を取得する
            int port_num = comNum.Count;
            int column = 3;                         //列
            if (port_num >= 9)
                column++;
            if (port_num >= 12)
                column++;
            if (port_num >= 15)
                column++;
            int row = port_num / column + 1;       //行
            int columnSize = this.Width / column;
            int rowSize = this.Height / row;
            columnSize -= 1;    // 調整
            rowSize -= 10;

            int nowColumn = 0;
            int nowRow = 0;

            int index = 0;
            // 取得したシリアル・ポート名をボタンにする
            for (int i = 0; i < comNum.Count; i++)
            {
                //Buttonクラスのインスタンスを作成する
                Button Button1 = new Button();

                //Buttonコントロールのプロパティを設定する
                Button1.Name = comNum[index];
                Button1.Text = comNum[index] + "\n\n" + comName[index];
                index++;

                //サイズと位置を設定する
                Button1.Location = new Point(nowColumn * columnSize
                                            , nowRow * rowSize);
                Button1.Size = new System.Drawing.Size(columnSize, rowSize);
                Button1.Font = new Font(Button1.Font.Name, columnSize / 10, FontStyle.Bold);
                Button1.Click += new System.EventHandler(this.button1_Click);

                //フォームに追加する
                Button1.Enabled = true;
                Controls.Add(Button1);
                nowColumn++;
                if (nowColumn == column)
                {
                    nowColumn %= column;
                    nowRow++;
                }
            }

            //Cancelサイズと位置を設定する
            button2.Location = new Point((int)((column - 1 + 0.1) * columnSize)
                                        , (int)((row - 1 + 0.1) * rowSize));
            button2.Size = new System.Drawing.Size((int)(columnSize * 0.8), (int)(rowSize * 0.8));
            button2.Font = new Font(button2.Font.Name, columnSize / 10, FontStyle.Bold);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            COM_NUM = button.Name;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
