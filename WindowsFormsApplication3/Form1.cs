using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StateButton;

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
            if (state3Button1.State == State3Button.SBtState.Button1)
            {
                state3Button1.Button1.MyText = (count).ToString();
                state3Button1.Button2.MyText = (count).ToString();
                state3Button1.Button3.MyText = (count).ToString();
            }
        }
    }
}
