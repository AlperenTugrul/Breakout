using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BreakoutWPF
{
	/// <summary>
	/// Interaction logic for btn.xaml
	/// </summary>
	public partial class btn
	{
		public btn()
		{
			this.InitializeComponent();
		}

        static BitmapImage imgDepressed = new BitmapImage(new Uri("images/btn_depressed.png", UriKind.Relative));
        static BitmapImage imgHover = new BitmapImage(new Uri("images/btn_hover.png", UriKind.Relative));
        static BitmapImage imgPressed = new BitmapImage(new Uri("images/btn_pressed.png", UriKind.Relative));

        public event EventHandler<EventArgs> Click;

        public string Text
        {
            get { return txbCaption.Text; }
            set { txbCaption.Text = value; }
        }

        private void imgMain_MouseEnter(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                mMouseDown = true;
            else
                mMouseDown = false;
            if (mMouseDown)
                imgMain.Source = imgPressed;
            else
                imgMain.Source = imgHover;
        }

        private void imgMain_MouseLeave(object sender, MouseEventArgs e)
        {
            imgMain.Source = imgDepressed;
        }

        bool mMouseDown = false;

        private void imgMain_MouseDown(object sender, MouseButtonEventArgs e)
        {
            imgMain.Source = imgPressed;
            mMouseDown = true;
            //imgMain.CaptureMouse();
        }

        private void imgMain_MouseUp(object sender, MouseButtonEventArgs e)
        {
            imgMain.Source = imgHover;
            mMouseDown = false;
            //imgMain.ReleaseMouseCapture();
            if (Click != null)
                Click(this, null);
        }
	}
}