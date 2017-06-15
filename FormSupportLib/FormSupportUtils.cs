using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;//ちらつき防止

namespace FormSupportLib
{
    public partial class FormSupportUtils : UserControl
    {
        Rectangle preWindow = new Rectangle(0, 0, 0, 0);    //最大化前のwindowプロパティ
        Rectangle initWindow = new Rectangle(0, 0, 0, 0);    //最大化前のwindowプロパティ
        Point mousePoint;       //フォーム動かす用のマウス座標
        int displayType = 0;
        Form focusForm = null;
        FormWindowState preWindowState = FormWindowState.Normal;

        #region 初期設定
        public FormSupportUtils()
        {
            InitializeComponent();
        }

        private void FormSupportUtils_ParentChanged(object sender, EventArgs e)
        {
            RemoveEventHandler();
            focusForm = (Form)this.Parent;//フォーム生成時にthis.Activate()しないと、エラーメッセージ生成時にとまる
            AddEventHandler();
            InitWindowSetting();
        }

        private void InitWindowSetting()
        {
            //ボタンResizeのための初期化
            if (preWindow == new Rectangle(0, 0, 0, 0))
            {
                preWindow = focusForm.Bounds;
                initWindow = focusForm.Bounds;
                focusForm.MinimumSize = initWindow.Size;
            }
        }

        private void AddEventHandler()
        {
            focusForm.ResizeEnd += new System.EventHandler(this.F1_Resized);
            focusForm.SizeChanged += new System.EventHandler(this.F1_SizeChanged);
            focusForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            focusForm.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            focusForm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ChangeWindowSize);
        }

        private void RemoveEventHandler()
        {
            if (focusForm == null) return;

            focusForm.ResizeEnd -= new System.EventHandler(this.F1_Resized);
            focusForm.SizeChanged -= new System.EventHandler(this.F1_SizeChanged);
            focusForm.MouseDown -= new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            focusForm.MouseMove -= new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            focusForm.KeyUp -= new System.Windows.Forms.KeyEventHandler(this.ChangeWindowSize);
        }

        //表示されないと呼ばれない（Visible = falseの場合は呼ばれない）コンストラクタで非表示にしたら使えない
        private void FormSupportUtils_Load(object sender, EventArgs e)
        {
            if (DesignMode) //フォームデザイン時は設定しない[bug]
                return;

            this.Visible = false;
        }

        private void FormSupportUtils_VisibleChanged(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            this.Visible = false;
        }
        #endregion

        #region Resize関連
        private void F1_Resized(object sender, EventArgs e)
        {
            ResizeButton();
        }

        void F1_SizeChanged(object sender, EventArgs e)
        {
            if (focusForm.WindowState == preWindowState)
                return;

            ResizeButton();
            preWindowState = focusForm.WindowState;
        }

        /// <summary> ボタンサイズをFormサイズに合わせてリサイズ </summary>
        public void ResizeButton()
        {
            if (focusForm.WindowState == FormWindowState.Minimized)//最小化のとき無視する
                return;

            float resize_perX = 1.0f;
            float resize_perY = 1.0f;
            int resize_locationX;
            int resize_locationY;

            //拡大率算出
            resize_perX = (float)focusForm.Width / preWindow.Width;
            resize_perY = (float)focusForm.Height / preWindow.Height;
            if (resize_perX == 1 && resize_perY == 1)
                return;

            //BeginUpdate(forcusForm);

            // コントロール全てを列挙
            List<Control> controls = focusForm.GetAllControls<Control>();
            foreach (var ctl in controls)
            {
                //位置再配置
                resize_locationX = (int)Math.Round(ctl.Left * resize_perX);
                resize_locationY = (int)Math.Round(ctl.Top * resize_perY);
                ctl.Location = new Point(resize_locationX, resize_locationY);

                //リサイズ
                resize_locationX = (int)Math.Round(ctl.Width * resize_perX);
                resize_locationY = (int)Math.Round(ctl.Height * resize_perY);
                ctl.Size = new Size(resize_locationX, resize_locationY);

                if (ctl is TextBox || ctl is ComboBox || ctl is Label || ctl is CheckBox)
                    ctl.Font = new Font(ctl.Font.Name, ctl.Font.Size * resize_perY);
            }

            //EndUpdate(forcusForm);
            preWindow = focusForm.Bounds;
        }

        public void FitFormToWindow(bool isRatioEvenly = false)
        {
            //現在フォームが存在しているディスプレイを取得
            System.Windows.Forms.Screen s =
                System.Windows.Forms.Screen.FromControl(focusForm);
            int w = s.Bounds.Width;
            int h = s.Bounds.Height;
            if (isRatioEvenly)
            {
                if (focusForm.Width > focusForm.Height)
                    h = (int)(w / (float)focusForm.Width * focusForm.Height);
                else
                    w = (int)(h / (float)focusForm.Height * focusForm.Width);
            }
            ResizeWindow(w, h);
            focusForm.Location = new Point(0, 0);
        }

        public void ChangeWindowSize(object sender, KeyEventArgs e)
        {

            //if (e.KeyData == Keys.Up || e.KeyData == Keys.Down || e.KeyData == Keys.F)
            //{
            ////ダブルバッファリングを有効にする
            //forcusForm.SetStyle(
            //   ControlStyles.DoubleBuffer |
            //   ControlStyles.UserPaint |
            //   ControlStyles.AllPaintingInWmPaint,
            //   true);

            if (e.KeyData == Keys.F)
            {
                if (focusForm.Size.Width == Screen.PrimaryScreen.Bounds.Size.Width
                    || focusForm.Size.Height == Screen.PrimaryScreen.Bounds.Size.Height)
                    ResizeWindow(initWindow.Size);
                else
                    FitFormToWindow(true);
                return;
            }

            int newDisplayType = displayType;
            const int cDisplayTypeMax = 3;
            if (e.KeyData == Keys.Up)
                newDisplayType++;
            if (e.KeyData == Keys.Down)
                newDisplayType--;
            
            if (newDisplayType == displayType)
            {
                return;
            }

            if (displayType < 0)
                newDisplayType = cDisplayTypeMax;
            else if (displayType > cDisplayTypeMax)
                newDisplayType = 0;

            displayType = newDisplayType;
            focusForm.WindowState = FormWindowState.Normal;

            switch (displayType)
            {
                case 0:
                    ResizeWindow(640, 480);
                    break;
                case 1:
                    ResizeWindow(800, 600);
                    break;
                case 2:
                    ResizeWindow(1024, 768);
                    break;
                case 3:
                    ResizeWindow(1280, 768);
                    break;
                default:
                    ResizeWindow(initWindow.Size);
                    break;
            }
            //}
        }

        public void ResizeWindow(int w, int h)
        {
            //ボタンResizeのための初期化
            if (preWindow == new Rectangle(0, 0, 0, 0))
            {
                preWindow = focusForm.Bounds;
                initWindow = focusForm.Bounds;
            }
            focusForm.Size = new Size(w, h);
            ResizeButton();
        }
        public void ResizeWindow(Size s)
        {
            ResizeWindow(s.Width, s.Height);
        }
        #endregion

        #region フォーム移動関連
        private void MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);//位置を記憶する
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                if (focusForm.WindowState != FormWindowState.Normal)//サイズ全画面時は動かさない
                    return;

                focusForm.Location = new Point(
                    focusForm.Location.X + e.X - mousePoint.X,
                    focusForm.Location.Y + e.Y - mousePoint.Y);
            }
        }
        #endregion
    }
}
