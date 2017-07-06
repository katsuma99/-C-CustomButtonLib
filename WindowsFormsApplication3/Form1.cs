using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StateButtonLib;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void stateButton1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void state3Button1_OnPushButtonEvent(object sender, EventArgs e)
        {

        }

        private void state3Button1_Click(object sender, EventArgs e)
        {

        }

        int count = 0;
        private void state3Button1_OnReleaseButtonEvent(object sender, EventArgs e)
        {
            ++count;
            //if (state3Button1.State == StateButton.SBtState.Button1)
            //{
            //    state3Button1.Button1.MyText = (count).ToString();
            //    state3Button1.Button2.MyText = (count).ToString();
            //    state3Button1.Button3.MyText = (count).ToString();
            //}
        }

        private void state8Button1_OnReleaseButtonEvent(object sender, EventArgs e)
        {
            //StateButtonProperty nextStateButton = state8Button1.GetNowCustomButton(1);
            //switch (state8Button1.State)
            //{
            //    case StateButton.SBtState.Button1:
            //        nextStateButton.MyText = "State2";
            //        break;
            //    case StateButton.SBtState.Button2:
            //        nextStateButton.MyText = "State3";
            //        break;
            //    case StateButton.SBtState.Button3:
            //        nextStateButton.MyText = "State1";
            //        break;
            //    case StateButton.SBtState.Button4:
            //        break;
            //    case StateButton.SBtState.Button5:
            //        break;
            //    case StateButton.SBtState.Button6:
            //        break;
            //    case StateButton.SBtState.Button7:
            //        break;
            //    case StateButton.SBtState.Button8:
            //        break;
            //    case StateButton.SBtState.ButtonHightDummy:
            //        break;
            //    case StateButton.SBtState.ButtonLowDummy:
            //        break;
            //    default:
            //        break;
            //}
        }
    }
}
