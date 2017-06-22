using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Collections;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Resources;
namespace WindowsFormsControlLibrary2
{

    public partial class UserControl1 : UserControl
    {
        protected BaseButtonProperty mBaseButtonProperty = new BaseButtonProperty();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue(typeof(BaseButtonPropertyConverter), "None")]
        public BaseButtonProperty BaseButtonProperty
        {
            get { return mBaseButtonProperty; }
            set { mBaseButtonProperty = value; }
        }

        public UserControl1()
        {
            InitializeComponent();
        }

        PictureBox image = new PictureBox();
        protected override void OnMouseEnter(EventArgs e)
        {
            mBaseButtonProperty.OnEnterButton(image.Image);
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            mBaseButtonProperty.OnLeaveButton(image.Image);
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            mBaseButtonProperty.OnPushButton(image.Image);
            base.OnMouseDown(mevent);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            mBaseButtonProperty.OnReleaseButton(image.Image);
            base.OnMouseUp(mevent);
        }
    }

    public enum State
    {
        None,
        Select,
        Push
    }


    [TypeConverter(typeof(BaseButtonPropertyConverter))]
    public class BaseButtonProperty
    {
        public BaseButtonProperty()
        {
            try
            {
                mSelectImage = Image.FromFile("save1.png");
                mNormalImage = Image.FromFile("save2.png");
                mPushedImage = Image.FromFile("save3.png");
            }
            catch (Exception)
            {
            }
            
        }

        public State mState = State.None;
        protected Image mSelectImage;
        [Category("ボタンイメージ"), Description("ボタンを選択した時のイメージ画像")]
        [DefaultValue(null)]
        public Image SelectImage
        {
            get { return mSelectImage; }
            set { mSelectImage = value; }
        }

        protected Image mNormalImage;
        [Category("ボタンイメージ"), Description("通常のボタンのイメージ画像")]
        [DefaultValue(null)]
        public Image NormalImage
        {
            get
            {
                return mNormalImage;
            }
            set
            {
                mNormalImage = value;
                //base.Image = value;
                //base.Size = value.Size;
            }
        }

        protected Image mPushedImage;
        [Category("ボタンイメージ"), Description("ボタンを押下した時のイメージ画像")]
        [DefaultValue(null)]
        public Image PushedImage
        {
            get { return mPushedImage; }
            set { mPushedImage = value; }
        }

        [Category("カスタムボタンイベント"), Description("ボタンを押下した時に入る処理")]
        public event EventHandler OnPushButtonEvent = (sender, e) =>
        {
        };


        [Category("カスタムボタンイベント"), Description("ボタンをリリースした時に入る処理")]
        public event EventHandler OnReleaseButtonEvent = (sender, e) =>
        {
        };

        public void OnPushButton(Image btImage)
        {
            OnPushButtonEvent(this, EventArgs.Empty);
            mState = State.Push;
            btImage = PushedImage;
        }

        public void OnReleaseButton(Image btImage)
        {
            OnReleaseButtonEvent(this, EventArgs.Empty);
            mState = State.Select;
            btImage = SelectImage;
        }

        public void OnEnterButton(Image btImage)
        {
            mState = State.Select;
            btImage = SelectImage;
        }

        public void OnLeaveButton(Image btImage)
        {
            mState = State.None;
            btImage = NormalImage;
        }
    }

    public class BaseButtonPropertyConverter : ExpandableObjectConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;
            else
                return base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
                return true;
            else
                return base.CanConvertTo(context, destinationType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            string strValue = value as string;
            if (strValue == null)
                return base.ConvertFrom(context, culture, value);
            string[] values = strValue.Split(',');
            int count = values.Length;
            try
            {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(context.GetType());
                BaseButtonProperty baseButtonProp = new BaseButtonProperty();
                baseButtonProp.SelectImage = ((System.Drawing.Image)(resources.GetObject(values[0])));
                baseButtonProp.NormalImage = ((System.Drawing.Image)(resources.GetObject(values[1])));
                baseButtonProp.PushedImage = ((System.Drawing.Image)(resources.GetObject(values[2])));
                return baseButtonProp;
            }
            catch
            {
                throw new ArgumentException("プロパティの値が無効です");
            }
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            
            BaseButtonProperty baseButtonProp = value as BaseButtonProperty;
            if (baseButtonProp == null || destinationType != typeof(string))
                return base.ConvertTo(context, culture, value, destinationType);
            var assem = System.Reflection.Assembly.GetExecutingAssembly();
            var name = assem.GetName();
            var resources = assem.GetManifestResourceNames();

            string resName = assem.GetName().Name;// + @"\Resources"; 

            using (var stream = assem.GetManifestResourceStream(resName))
            {
                
            }

            //using (ResourceReader resource = new ResourceReader(resName))
            //{
            //    IDictionaryEnumerator id = resource.GetEnumerator();
            //    while (id.MoveNext())
            //        Console.WriteLine("\n[{0}] \t{1}", id.Key, id.Value);
            //}

            //var r = ResourceReader.GetEnumerator();
            ResXResourceReader.FromFileContents(resName);
            ResXResourceReader xres = new ResXResourceReader(@"C:\Users\katsumaPC\Desktop\SourceTree\NET Framework\CustomButtonLib\WindowsFormsControlLibrary2\Properties\Resources.resx");

            int hashcode = baseButtonProp.NormalImage.GetHashCode();



            //ResourceReader.GetResourceData();

            //現在のコードを実行しているAssemblyを取得
            //System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();

            ////指定されたマニフェストリソースを読み込む
            //Type[] resnames = myAssembly.GetManifestResourceNames();
            //System.ComponentModel.ComponentResourceManager resources;
            //foreach (Type res in resnames)
            //{

            //    Console.WriteLine("resource {0}", res);
            //    resources = new System.ComponentModel.ComponentResourceManager(res);
            //}

            //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager();

            //ImageConverter imageConverter = new ImageConverter();
            string save1 = "save1.png";
            string save2 = "save2.png";
            string save3 = "save3.png";
            //try
            //{
            //    save1 = "resource.SelectImage";
            //    save2 = "resource.NormalImage";
            //    save3 = "resource.PushedImage";
            //    //baseButtonProp.SelectImage.Save(save1);
            //    //baseButtonProp.NormalImage.Save(save2);
            //    //baseButtonProp.PushedImage.Save(save3);
            //}
            //catch (Exception)
            //{
            //}

            return string.Format("{0},{1},{2}",
                                 save1,
                                 save2,
                                 save3
                                 );
        }

        //public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        //{
        //    return true;
        //}

        //public override object CreateInstance(ITypeDescriptorContext context, System.Collections.IDictionary propertyValues)
        //{
        //    BaseButtonProperty baseButtonProp = new BaseButtonProperty();
        //    baseButtonProp.NormalImage = (Image)propertyValues["NormalImage"];
        //    baseButtonProp.SelectImage = (Image)propertyValues["SelectImage"];
        //    baseButtonProp.PushedImage = (Image)propertyValues["PushedImage"];
        //    return baseButtonProp;
        //}
    }
}
