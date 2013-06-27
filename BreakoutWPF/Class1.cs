using System.Windows;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System;
using System.Diagnostics;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace BreakoutWPF
{
    /*public interface IGameVisual
    {
        void AddToPanel(Panel p);
    }

    public class Level
    {
        public double BallSpeed { get; set; }
    }*/

    /*public class GameObjectVisual
    {
        public FrameworkElement Root { get; set; }

        public virtual double X
        {
            get { return (double)Root.GetValue(Canvas.LeftProperty); }
            set { Root.SetValue(Canvas.LeftProperty, value); }
        }

        public virtual double Y
        {
            get { return (double)Root.GetValue(Canvas.TopProperty); }
            set { Root.SetValue(Canvas.TopProperty, value); }
        }

        public virtual double Width
        {
            get { return Root.Width; }
            set { Root.Width = value; }
        }

        public virtual double Height
        {
            get { return Root.Height; }
            set { Root.Height = value; }
        }

        Rect rcTemp = new Rect();
        public Rect Rect
        {
            get
            {
                rcTemp.X = X;
                rcTemp.Y = Y;
                rcTemp.Width = Width;
                rcTemp.Height = Height;
                return rcTemp;
            }
        }

        public bool Intersects(GameObjectVisual o)
        {
            return Rect.IntersectsWith(o.Rect);
        }


        public virtual void AddToPanel(Panel p)
        {
            p.Children.Add(Root);
        }

        public virtual void RemoveFromPanel(Panel p)
        {
            p.Children.Remove(Root);
        }
    }

    public class GameImageObject : GameObjectVisual
    {
        public GameImageObject(ImageSource src)
        {
            Root = new Image()
            {
                Source = src,
            };
            X = Y = 0;
            Image r = Root as Image;
            r.Width = r.Source.Width;
            r.Height = r.Source.Height;
        }

        void Init(Panel p)
        {
            p.Children.Add(Root);
        }
    }

    public class Player : GameImageObject
    {
        public static BitmapImage bmpPaddle = new BitmapImage(new Uri("pack://application:,,,/BreakoutWPF;component/images/paddle_normal.png"));

        public string Name { get; set; }
        public long Score { get; set; }

        public Player() : base(bmpPaddle)
        {
            
        }
    }

    public class Ball : GameImageObject
    {
        public static BitmapImage bmpBall= new BitmapImage(new Uri("pack://application:,,,/BreakoutWPF;component/images/ball_normal.png"));

        public Ball() : base(bmpBall)
        {
            
        }

        public double XVel { get; set; }
        public double YVel { get; set; }
        public void Move()
        {
            X += XVel;
            Y += YVel;
        }

        //public void Bounce()
        //{
        //    XVel = -XVel;
        //    YVel = -YVel;
        //}
    }

    public class Block : GameImageObject
    {
        public static BitmapImage[] bmps = new BitmapImage[]
        {
            new BitmapImage(new Uri("pack://application:,,,/BreakoutWPF;component/images/block_yellow.png")),
            new BitmapImage(new Uri("pack://application:,,,/BreakoutWPF;component/images/block_green.png")),
            new BitmapImage(new Uri("pack://application:,,,/BreakoutWPF;component/images/block_red.png")),
            new BitmapImage(new Uri("pack://application:,,,/BreakoutWPF;component/images/block_blue.png")),
            new BitmapImage(new Uri("pack://application:,,,/BreakoutWPF;component/images/block_white.png")),
            new BitmapImage(new Uri("pack://application:,,,/BreakoutWPF;component/images/block_purple.png")),
            new BitmapImage(new Uri("pack://application:,,,/BreakoutWPF;component/images/block_grey.png")),
            new BitmapImage(new Uri("pack://application:,,,/BreakoutWPF;component/images/block_orange.png")),
        };

        public enum Colour
        {
            Yellow = 0,
            Green = 1,
            Red = 2,
            Blue = 3,
            White = 4,
            Purple = 5,
            Grey = 6,
            Orange = 7
        };

        public const int Width = 23;
        public const int Height = 23;

        public static BitmapImage ImageFromColour(Colour clr)
        {
            return bmps[(int)clr];
        }

        static Random mRand = new Random(DateTime.Now.Millisecond);
        public static BitmapImage RandomImage()
        {
            return bmps[mRand.Next(0, 7)];
        }

        public Block() : base(RandomImage())
        {

        }

        public Block(Colour clr) : base(ImageFromColour(clr))
        {

        }
    }*/



    //public class brick : gameobjectvisual
    //{
    //    //block[,] blocks = new block[9,9];
    //    block[] blocks;

    //    public int hp { get; set; }



    //    public block.colour colour { get; set; }

    //    public override double x
    //    {
    //        get
    //        {
    //            return blocks[0].x;
    //        }
    //        set
    //        {
    //            double x = value;
    //            foreach (block b in blocks)
    //            {
    //                b.x = x;
    //                x += block.width;
    //            }
    //        }
    //    }

    //    public override double y
    //    {
    //        get
    //        {
    //            return base.y;
    //        }
    //        set
    //        {
    //            double y = value;
    //            foreach (block b in blocks)
    //            {
    //                b.y = y;
    //                y += block.height;
    //            }
    //        }
    //    }

    //    public override double width
    //    {
    //        get
    //        {
    //            return block.width * blocks.length;
    //        }
    //        set
    //        {
    //            blocks = new block[value];
    //            for (int ctr = 0; ctr < value; ctr++)
    //                blocks[ctr] = new block(clr);
    //        }
    //    }
    //}
    

    public class Map
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string URL { get; set; }
        public Version Version { get; set; }
        public DateTime Created { get; set; }

        public string Description { get; set; }
        public int BallSpeed { get; set; }

        //public List<Brick> Bricks { get; set; }
    }



    public class GameObject
    {
        public virtual double X { get; set; }
        public virtual double Y { get; set; }
        public virtual double Width { get; set; }
        public virtual double Height { get; set; }

        public bool CollisionIgnore { get; set; }

        public virtual Rect CollisionBounds { get; set; }

        public virtual bool PointIntersects(Point pt)
        {
            if ((pt.X > CollisionBounds.X && pt.X < CollisionBounds.Width)
                && (pt.Y > CollisionBounds.Y && pt.Y < CollisionBounds.Height))
            {
                return true;
            }
            return false;
        }

        public virtual bool RectIntersects(Rect rc)
        {
            return CollisionBounds.IntersectsWith(rc);
        }

        public virtual bool Intersects(GameObject o)
        {
            return CollisionBounds.IntersectsWith(o.CollisionBounds);
        }

        public virtual void OnCollide(GameObject o)
        {
            Debug.WriteLine(String.Format("Collision: {0} -> {1}", this.ToString(), o.ToString()));
        }
    }

    public class GameObjectVisual : GameObject
    {
        public FrameworkElement Root { get; set; }

        protected void UpdateCollisionBounds()
        {
            /*CollisionBounds = new Rect(
                (double)Root.GetValue(Canvas.LeftProperty),
                (double)Root.GetValue(Canvas.TopProperty),
                Root.Width,
                Root.Height);*/
            mRcBounds = new Rect(X, Y, Width, Height);
        }

        Rect mRcBounds = new Rect();
        public override Rect CollisionBounds
        {
            get
            {
                UpdateCollisionBounds();
                return mRcBounds;
            }
            set
            {
                mRcBounds = value;
            }
        }
        
        public override double X
        {
            get { return (double)Root.GetValue(Canvas.LeftProperty); }
            set
            {
                Root.SetValue(Canvas.LeftProperty, value);
                UpdateCollisionBounds();
            }
        }

        public override double Y
        {
            get { return (double)Root.GetValue(Canvas.TopProperty); }
            set
            {
                Root.SetValue(Canvas.TopProperty, value);
                UpdateCollisionBounds();
            }
        }

        public override double Width
        {
            get { return Root.Width; }
            set
            {
                Root.Width = value;
                UpdateCollisionBounds();
            }
        }

        public override double Height
        {
            get { return Root.Height; }
            set
            {
                Root.Height = value;
                UpdateCollisionBounds();
            }
        }

        public virtual void AddToPanel(Panel p)
        {
            p.Children.Add(Root);
        }

        public virtual void RemoveFromPanel(Panel p)
        {
            p.Children.Remove(Root);
        }
    }

    public class GameImageObject : GameObjectVisual
    {
        public GameImageObject(ImageSource src)
        {
            Root = new Image()
            {
                Source = src,
            };
            X = Y = 0;
            Image r = Root as Image;
            r.Width = r.Source.Width;
            r.Height = r.Source.Height;
        }
    }

    public class Player : GameImageObject
    {
        public static BitmapImage bmpPaddle = new BitmapImage(new Uri("pack://application:,,,/BreakoutWPF;component/images/paddle_normal.png"));

        public string Name { get; set; }
        public long Score { get; set; }

        public Player()
            : base(bmpPaddle)
        {

        }

        public override void OnCollide(GameObject o)
        {
            if (o.GetType() != typeof(Ball))
                return;

            //
            //          0
            //          ---------
            //              |
            //          <--->
            //          distance between ball and center of paddle
            //          to determine the direction of drift to add to velocity
            //

            /*
             *                  0
             *
             *          --------------------
             *          |        |         |
             *          -45      0         +45
             * 
             * 
             * */

            //playerX = p.X;
            //playerY = p.Y;
            //playerCenterX = p.X - (p.Width / 2);
            Ball ball = o as Ball;

            ball.YVel = -ball.YVel;
            double diff = (ball.X + ball.Width / 2) - X;
            if (diff < Width / 2)
            {
                //Debug.WriteLine("BOUNCE LEFT");
                ball.XVel -= 1;
            }
            else
            {
                //Debug.WriteLine("BOUNCE RIGHT");
                ball.XVel += 1;
            }
        }
    }

    public class Ball : GameImageObject
    {
        public static BitmapImage bmpBall = new BitmapImage(new Uri("pack://application:,,,/BreakoutWPF;component/images/ball_normal.png"));

        public Ball()
            : base(bmpBall)
        {

        }

        public double XVel { get; set; }
        public double YVel { get; set; }
        public void Move()
        {
            X += XVel;
            Y += YVel;
        }

        public override void OnCollide(GameObject o)
        {
            if (o.GetType() == typeof(Brick))
            {
                XVel = -XVel;
                YVel = -YVel;
            }
        }
    }

    public class Block : GameImageObject
    {
        public static BitmapImage[] bmps = new BitmapImage[]
        {
            new BitmapImage(new Uri("pack://application:,,,/BreakoutWPF;component/images/block_yellow.png")),
            new BitmapImage(new Uri("pack://application:,,,/BreakoutWPF;component/images/block_green.png")),
            new BitmapImage(new Uri("pack://application:,,,/BreakoutWPF;component/images/block_red.png")),
            new BitmapImage(new Uri("pack://application:,,,/BreakoutWPF;component/images/block_blue.png")),
            new BitmapImage(new Uri("pack://application:,,,/BreakoutWPF;component/images/block_white.png")),
            new BitmapImage(new Uri("pack://application:,,,/BreakoutWPF;component/images/block_purple.png")),
            new BitmapImage(new Uri("pack://application:,,,/BreakoutWPF;component/images/block_grey.png")),
            new BitmapImage(new Uri("pack://application:,,,/BreakoutWPF;component/images/block_orange.png")),
        };

        public enum ColourValue
        {
            Yellow = 0,
            Green = 1,
            Red = 2,
            Blue = 3,
            White = 4,
            Purple = 5,
            Grey = 6,
            Orange = 7
        };

        public static ColourValue ColourFromImage(BitmapImage img)
        {
            int len = bmps.Length;
            for (int ctr = 0; ctr < len; ctr++)
            {
                if (bmps[ctr] == img)
                    return (ColourValue)ctr;
            }
            throw new Exception("Unknown colour value");
        }

        public static BitmapImage ImageFromColour(ColourValue clr)
        {
            return bmps[(int)clr];
        }

        public const int Width = 23;
        public const int Height = 23;

        static Random mRand = new Random(DateTime.Now.Millisecond);
        public static BitmapImage RandomImage()
        {
            return bmps[mRand.Next(0, 7)];
        }

        public Block()
            : base(RandomImage())
        {

        }

        public Block(ColourValue clr)
            : base(ImageFromColour(clr))
        {
            
        }

        ColourValue mClr;
        public ColourValue Colour
        {
            get
            {
                return ColourFromImage((BitmapImage)((Image)Root).Source);
            }
            set
            {
                ((Image)Root).Source = ImageFromColour(value);
            }
        }
    }

    public class Brick : GameObjectVisual
    {
        Block[] blocks = new Block[0];

        public int BlockWidth
        {
            get
            {
                if (blocks == null)
                    return 0;
                else
                    return blocks.Length;
            }
            set
            {
                blocks = new Block[value];
                for (int ctr = 0; ctr < value; ctr++)
                {
                    blocks[ctr] = new Block(mColour);
                    blocks[ctr].AddToPanel((StackPanel)Root);
                }
            }
        }

        Block.ColourValue mColour;
        public Block.ColourValue Colour
        {
            get
            {
                return mColour;
            }
            set
            {
                foreach (Block b in blocks)
                    b.Colour = value;
                mColour = value;
            }
        }

        public Brick()
        {
            Root = new StackPanel()
            {
                Orientation = Orientation.Horizontal
            };
        }

        public override void OnCollide(GameObject o)
        {

        }

        public override double Height
        {
            get
            {
                return Root.ActualHeight;
            }
            set
            {
                base.Height = value;
            }
        }

        public override double Width
        {
            get
            {
                return Root.ActualWidth;
            }
            set
            {
                base.Width = value;
            }
        }

        
    }

    public static class Game
    {
        public static List<Player> Players = new List<Player>();
        public static List<Ball> Balls = new List<Ball>();
        public static List<Brick> Bricks = new List<Brick>();

        public static List<GameObject> Objects = new List<GameObject>();

        public static void AddPlayer(Player p)
        {
            Players.Add(p);
            Objects.Add(p);
            p.AddToPanel(RootPanel);
        }

        public static void AddBall(Ball b)
        {
            Balls.Add(b);
            Objects.Add(b);
            b.AddToPanel(RootPanel);
        }

        public static void AddBrick(Brick b)
        {
            Bricks.Add(b);
            Objects.Add(b);
            b.AddToPanel(RootPanel);
        }


        /*public static void BrickHit(Brick b)
        {
            b.RemoveFromPanel(RootPanel);
            Bricks.Remove(b);
            Objects.Remove(b);

        }*/



        public static Panel RootPanel { get; set; }

        //static int a = 0;
        public static void Update()
        {
            foreach (Ball ball in Balls)
            {//TODO: move to wall class
                // ball hit side, invert x velocity
                if (ball.X < 0 || ball.X > (RootPanel.ActualWidth - ball.Width))
                    ball.XVel = -ball.XVel;

                // ball hit top or bottom edge, invert y velocity
                if (ball.Y < 0 || ball.Y > (RootPanel.ActualHeight - ball.Height))
                    ball.YVel = -ball.YVel;

                ball.Move();
            }

            List<Brick> hitBricks = new List<Brick>();

            foreach (GameObject o in Objects)
            {
                foreach (GameObject o2 in Objects)
                {
                    //if (o.GetType() == typeof(Brick) && o2.GetType() == typeof(Brick))
                    //    Debugger.Break();

                    if (o != o2 && !o.CollisionIgnore && o.Intersects(o2))
                    {
                        o.OnCollide(o2);
                        if (o.GetType() == typeof(Brick))
                            hitBricks.Add((Brick)o);
                        else if (o2.GetType() == typeof(Brick))
                            hitBricks.Add((Brick)o2);
                    }
                }
            }

            foreach (Brick brick in hitBricks)
            {
                Objects.Remove(brick);
                Bricks.Remove(brick);
                brick.RemoveFromPanel(RootPanel);
            }

            /*double ballX, ballY, ballCenterX;
            double playerX, playerY, playerCenterX;
            
            foreach (Ball b in Balls)
            {
                b.Move();
                ballX = b.X;
                ballY = b.Y;
                //ballCenterX = b.X - (b.Width / 2);

                if (ballX < 0 || ballX > (RootPanel.ActualWidth - b.Width))
                    b.XVel = -b.XVel;

                if (ballY < 0 || ballY > (RootPanel.ActualHeight - b.Height))
                    b.YVel = -b.YVel;

                foreach (Player p in Players)
                {
                    //
                    //          0
                    //          ---------
                    //              |
                    //          <--->
                    //          distance between ball and center of paddle
                    //          to determine the direction of drift to add to velocity
                    //

                    //playerX = p.X;
                    //playerY = p.Y;
                    //playerCenterX = p.X - (p.Width / 2);

                    if (p.Intersects(b))
                    {
                        b.YVel = -b.YVel;
                        double diff = (b.X + b.Width / 2) - p.X;
                        if (diff < p.Width / 2)
                        {
                            //Debug.WriteLine("BOUNCE LEFT");
                            b.XVel -= 1;
                        }
                        else
                        {
                            //Debug.WriteLine("BOUNCE RIGHT");
                            b.XVel += 1;
                        }
                    }

                    
                }

                //foreach (Brick brick in Bricks)
                //{
                //    if (b.Intersects(brick))
                //    {
                //        b.RemoveFromPanel(RootPanel);
                //    }
                //}

                //foreach (Ball b2 in Balls)
                //{
                //    if (b != b2 && b.Intersects(b2))
                //    {
                //        b.Bounce();
                //        b2.Bounce();
                //    }
                //}
            }*/
        }
    }
}
