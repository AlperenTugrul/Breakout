using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Diagnostics;
using System.Windows.Threading;
using System.Windows.Media.Animation;

namespace BreakoutWPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Player mPlayer;
        Ball mBall;
        DispatcherTimer mCursorTracker = new DispatcherTimer()
        {
            Interval = TimeSpan.FromMilliseconds(10)
        };
            
        public Window1()
        {
            InitializeComponent();

            mCursorTracker.Tick += new EventHandler(mCursorTracker_Tick);
            mPaddleYPos = this.Height - 100;
            mPaddleLeftBoundary = 10;
            mPaddleRightBoundary = this.Width - 10;
            Init();
        }

        void Init()
        {
            Game.RootPanel = LayoutRoot;
            Game.AddPlayer(mPlayer = new Player()
            {
                Name = Environment.UserName
            });
            Game.AddBall(mBall = new Ball());
            
            mCursorTracker.IsEnabled = true;
        }

        void LogText(string str)
        {
            txtDebug.Text += str;
            txtDebug.SelectionStart = txtDebug.Text.Length;
        }

        Point mOldPos = new Point();
        double mPaddleYPos;
        double mPaddleLeftBoundary, mPaddleRightBoundary;
        void mCursorTracker_Tick(object sender, EventArgs e)
        {
            Point pos = Mouse.GetPosition(null);
            if (!pos.Equals(mOldPos))
            {
                pos.X -= mPlayer.Width / 2;
                if (pos.X < mPaddleLeftBoundary)
                    pos.X = mPaddleLeftBoundary;
                else if (pos.X > (mPaddleRightBoundary - mPlayer.Width))
                    pos.X = mPaddleRightBoundary - mPlayer.Width;

                pos.Y = mPaddleYPos;
                mPlayer.X = pos.X;
                mPlayer.Y = pos.Y;
            }

            Game.Update();
        }

        /*bool mFullScreen;
        public bool FullScreen
        {
            get { return mFullScreen; }
            set
            {
                if (value)
                {
                }
            }
        }*/

        double oldXVel, oldYVel;
        bool slowMo = false;
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            /*if((e.Key == Key.Enter || e.Key == Key.Return) && 
                (Keyboard.IsKeyDown(Key.LeftAlt) || Keyboard.IsKeyDown(Key.RightAlt)))
            {

            }*/

            switch (e.Key)
            {
                /*case Key.S:
                    if (slowMo)
                    {
                        if (mBall.XVel < 0)
                            mBall.XVel = -oldXVel;
                        else
                            mBall.XVel = oldXVel;

                        if (mBall.YVel < 0)
                            mBall.YVel = -oldYVel;
                        else
                            mBall.YVel = oldYVel;
                    }
                    else
                    {
                        oldXVel = mBall.XVel;
                        oldYVel = mBall.YVel;
                        if (oldXVel < 0)
                            mBall.XVel = -1;
                        else
                            mBall.XVel = 1;

                        if (oldYVel < 0)
                            mBall.YVel = -1;
                        else
                            mBall.YVel = 1;
                    }
                    slowMo = !slowMo;
                    Debug.WriteLine("SlowMo " + slowMo);
                    break;*/
                case Key.B:
                    
                    break;

                case Key.I:
                    //Init();
                    break;

                case Key.Up:
                    mBall.Y -= 10;
                    mBall.XVel = mBall.YVel = 0;
                    break;

                case Key.Down:
                    mBall.Y += 10;
                    mBall.XVel = mBall.YVel = 0;
                    break;

                case Key.Left:
                    mBall.X -= 10;
                    mBall.XVel = mBall.YVel = 0;
                    break;

                case Key.Right:
                    mBall.X += 10;
                    mBall.XVel = mBall.YVel = 0;
                    break;

                case Key.Add:
                    if (mBall.XVel > 0)
                        mBall.XVel += 1;
                    else mBall.XVel -= 1;

                    if (mBall.YVel > 0)
                        mBall.YVel += 1;
                    else mBall.YVel -= 1;
                    break;

                case Key.Subtract:
                    if (mBall.XVel > 0)
                        mBall.XVel -= 1;
                    else mBall.XVel += 1;

                    if (mBall.YVel > 0)
                        mBall.YVel -= 1;
                    else mBall.YVel += 1;
                    break;


                case Key.D:
                    foreach (GameObject o in Game.Objects)
                    {
                        Debug.WriteLine(String.Format("{0} ({1},{2})({3},{4})", o.ToString(),
                            o.X, o.Y, o.Width, o.Height));
                    }
                    break;

                case Key.Q:
                    Close();
                    break;
            }
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            ((Storyboard)Resources["StoryboardNewGame"]).Begin();
            
            Random r = new Random(DateTime.Now.Second);
            
            mBall.X = (this.Width - mBall.Width) / 2;

            mBall.Y = mPlayer.Y + mBall.Height;
            mBall.YVel = 9;

            
            Brick temp;
            Game.AddBrick(temp = new Brick()
            {
                Colour = Block.ColourValue.Blue,
                BlockWidth = 4,
                X = 100,
                Y = 50,
            });


            Game.AddBrick(temp = new Brick()
            {
                Colour = Block.ColourValue.Green,
                BlockWidth = 4,
                X = 200,
                Y = 50,
            });

            Game.AddBrick(temp = new Brick()
            {
                Colour = Block.ColourValue.Grey,
                BlockWidth = 4,
                X = 300,
                Y = 50,
            });
        }

        private void btnHighScores_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void imgURL_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo("http://samuelwilson.co.uk");
            psi.UseShellExecute = true;
            Process.Start(psi);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            
        }
    }
}
