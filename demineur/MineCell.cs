using System;
using System.Drawing;
using System.Windows.Forms;


namespace demineur
{
    public partial class MineCell : UserControl
    {
        public enum MineCellView
        {
            Button,
            Mine,
            Number,
            Flag,
            Question,
            Pressed
        };

        private MineCellView mView;
        private int mNumber;
        private Boolean mHasMine;
        private int myX;
        private int myY;
        private Color mButtonColor = Color.LightGray;
        private Boolean mHasExplosed = false;
        private Boolean mWrongFlag = false;

        public Boolean WrongFlag
        {
            get { return mWrongFlag; }
            set { mWrongFlag = value; }
        }

        public Boolean HasExplosed
        {
            get { return mHasExplosed; }
            set { mHasExplosed = value; }
        }

        public Color ButtonColor
        {
            get { return mButtonColor; }
            set { mButtonColor = value; this.Invalidate(); }
        }

        public Boolean HasMine
        {
            get { return mHasMine; }
            set { mHasMine = value; }
        }

        public int X
        {
            get { return myX; }
            set { myX = value; }
        }

        public int Y
        {
            get { return myY; }
            set { myY = value; }
        }
        public int Number
        {
            get { return mNumber; }
            set { mNumber = value; this.Invalidate(); }
        } 

        public MineCellView View
        {
            get { return mView; }
            set { mView = value; this.Invalidate(); }
        }

        public MineCell()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            switch (mView)
            {
                case MineCellView.Button:
                    {
                        //Set Scale
                        e.Graphics.ResetTransform();
                        e.Graphics.TranslateTransform(this.Width / 2, this.Height / 2);
                        e.Graphics.ScaleTransform(this.Width / 2, this.Height / 2);
                        e.Graphics.Clear(mButtonColor);

                        PointF TopLeft = new PointF(-1, -1);
                        PointF TopRight = new PointF(1, -1);
                        PointF BotLeft = new PointF(-1, 1);
                        PointF BotRight = new PointF(1, 1);

                        //Draw Shadow
                        Pen mPen = new Pen(Color.Gray, .3F);
                        e.Graphics.DrawLine(mPen, BotRight, BotLeft);
                        e.Graphics.DrawLine(mPen, BotRight, TopRight);

                        //Draw Highligth
                        mPen = new Pen(Color.White, .3F);
                        e.Graphics.DrawLine(mPen, TopLeft, BotLeft);
                        e.Graphics.DrawLine(mPen, TopLeft, TopRight);
                        
                        //Draw corner shadow
                        SolidBrush FBrush = new SolidBrush(Color.Gray);
                        PointF[] FPts = { new PointF(-1, 1), new PointF(-0.85F,1), new PointF(-0.85F,0.85F) };
                        e.Graphics.FillPolygon(FBrush, FPts);
                        FPts = new PointF[] { new PointF(1, -1), new PointF(1, -0.85F), new PointF(0.85F, -0.85F) };
                        e.Graphics.FillPolygon(FBrush, FPts);
                    }
                    break;
                case MineCellView.Mine:
                    {
                        //Set Scale
                        e.Graphics.ResetTransform();
                        e.Graphics.TranslateTransform(this.Width / 2, this.Height / 2);
                        e.Graphics.ScaleTransform(this.Width / 2, this.Height / 2);
                        if (!mHasExplosed)
                            e.Graphics.Clear(Color.LightGray);
                        else
                            e.Graphics.Clear(Color.Red);

                        //Draw Circle
                        RectangleF CRect = new RectangleF(-.6F, -.6F, 1.2F, 1.2F);
                        SolidBrush CBrush = new SolidBrush(Color.Black);
                        e.Graphics.FillEllipse(CBrush, CRect);

                        //Draw Pegs
                        Single IRad = 0.5F;
                        Single ORad = 0.8F;
                        Pen PPen = new Pen(Color.Black, (Single).15F);
                        PPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

                        for (Single Ang = 0; Ang <= 1.75F * Math.PI; Ang += 0.25F * (Single)Math.PI)
                        {
                            PointF Inner = new PointF(IRad * (Single)Math.Cos(Ang), IRad * (Single)Math.Sin(Ang));
                            PointF Outer = new PointF(ORad * (Single)Math.Cos(Ang), ORad * (Single)Math.Sin(Ang));
                            e.Graphics.DrawLine(PPen, Inner, Outer);
                        }

                        //Draw Highlight
                        RectangleF HRect = new RectangleF(-.3F, -.3F, .2F, .2F);
                        SolidBrush WBrush = new SolidBrush(Color.White);
                        e.Graphics.FillRectangle(WBrush, HRect);

                        //Draw Border
                        Rectangle BRect = new Rectangle(-1, -1, 2, 2);
                        Pen BPen = new Pen(Color.Gray, .05F);
                        e.Graphics.DrawRectangle(BPen, BRect);

                        if(mWrongFlag)
                        {
                            Pen mPen = new Pen(Color.Red, .15F);
                            e.Graphics.DrawLine(mPen, new PointF(-.8F, -.8F), new PointF(.8F, .8F));
                            e.Graphics.DrawLine(mPen, new PointF(-.8F, .8F), new PointF(.8F, -.8F));
                        }
                    }
                    break;
                case MineCellView.Number:
                    {
                        Color[] NColors = { Color.Blue, Color.Green, Color.Red, Color.Navy, Color.DarkRed, Color.DarkTurquoise, Color.Black, Color.LightGray };

                        //Set Scale
                        e.Graphics.ResetTransform();
                        e.Graphics.TranslateTransform(this.Width / 2, this.Height / 2);
                        e.Graphics.ScaleTransform(this.Width / 2, this.Height / 2);
                        e.Graphics.Clear(Color.LightGray);

                        if (mNumber > 0 && mNumber <= 8)
                        {
                            //Draw Number
                            SolidBrush NBrush = new SolidBrush(NColors[mNumber - 1]);
                            Font myFont = new Font("Times", 1.5F, FontStyle.Bold, GraphicsUnit.World);
                            SizeF SS = e.Graphics.MeasureString(mNumber.ToString(), myFont);
                            e.Graphics.DrawString(mNumber.ToString(), myFont, NBrush, -SS.Width / 2, -SS.Height / 2);
                        }
                        //Draw Border
                        Rectangle BRect = new Rectangle(-1, -1, 2, 2);
                        Pen BPen = new Pen(Color.Gray, .15F);
                        e.Graphics.DrawRectangle(BPen, BRect);
                    }
                    break;
                case MineCellView.Flag:
                    {
                        //Set Scale
                        e.Graphics.ResetTransform();
                        e.Graphics.TranslateTransform(this.Width / 2, this.Height / 2);
                        e.Graphics.ScaleTransform(this.Width / 2, this.Height / 2);
                        e.Graphics.Clear(Color.LightGray);

                        PointF TopLeft = new PointF(-1, -1);
                        PointF TopRight = new PointF(1, -1);
                        PointF BotLeft = new PointF(-1, 1);
                        PointF BotRight = new PointF(1, 1);

                        //Draw Shadow
                        Pen mPen = new Pen(Color.Gray, .3F);
                        e.Graphics.DrawLine(mPen, BotRight, BotLeft);
                        e.Graphics.DrawLine(mPen, BotRight, TopRight);

                        //Draw Highligth
                        mPen = new Pen(Color.White, .3F);
                        e.Graphics.DrawLine(mPen, TopLeft, BotLeft);
                        e.Graphics.DrawLine(mPen, TopLeft, TopRight);

                        //Flag Points
                        PointF PoleTop = new PointF(0, -.7F);
                        PointF PoleBottom = new PointF(0, .5F);
                        PointF FlagTip = new PointF(-.7F, -.3F);
                        PointF FlagBottom = new PointF(0, .1F);
                        PointF BaseLT = new PointF(-.5F, .5F);
                        PointF BaseLB = new PointF(-.7F, .7F);
                        PointF BaseRT = new PointF(.5F, .5F);
                        PointF BaseBR = new PointF(.7F, .7F);

                        //Pole
                        mPen = new Pen(Color.Brown, .1F);
                        e.Graphics.DrawLine(mPen, PoleTop, PoleBottom);

                        //Flag
                        PointF[] FPts = { PoleTop, FlagTip, FlagBottom };
                        SolidBrush FBrush = new SolidBrush(Color.Red);
                        e.Graphics.FillPolygon(FBrush, FPts);

                        //Base
                        PointF[] BPts = { BaseLT, BaseLB, BaseBR, BaseRT };
                        FBrush = new SolidBrush(Color.Black);
                        e.Graphics.FillPolygon(FBrush, BPts);
                    }

                    break;
                case MineCellView.Question:
                    {
                        //Set Scale
                        e.Graphics.ResetTransform();
                        e.Graphics.TranslateTransform(this.Width / 2, this.Height / 2);
                        e.Graphics.ScaleTransform(this.Width / 2, this.Height / 2);
                        e.Graphics.Clear(Color.LightGray);

                        //Draw ?
                        SolidBrush NBrush = new SolidBrush(Color.Black);
                        Font myFont = new Font("Times", 1.5F, FontStyle.Bold, GraphicsUnit.World);
                        SizeF SS = e.Graphics.MeasureString("?", myFont);
                        e.Graphics.DrawString("?", myFont, NBrush, -SS.Width / 2, -SS.Height / 2);

                        PointF TopLeft = new PointF(-1, -1);
                        PointF TopRight = new PointF(1, -1);
                        PointF BotLeft = new PointF(-1, 1);
                        PointF BotRight = new PointF(1, 1);

                        Pen mPen = new Pen(Color.Gray, .3F);
                        e.Graphics.DrawLine(mPen, BotRight, BotLeft);
                        e.Graphics.DrawLine(mPen, BotRight, TopRight);

                        mPen = new Pen(Color.White, .3F);
                        e.Graphics.DrawLine(mPen, TopLeft, BotLeft);
                        e.Graphics.DrawLine(mPen, TopLeft, TopRight);
                    }

                    break;
                case MineCellView.Pressed:
                    {
                        //Set Scale
                        e.Graphics.ResetTransform();
                        e.Graphics.TranslateTransform(this.Width / 2, this.Height / 2);
                        e.Graphics.ScaleTransform(this.Width / 2, this.Height / 2);
                        e.Graphics.Clear(Color.LightGray);

                        //Draw Border
                        Rectangle BRect = new Rectangle(-1, -1, 2, 2);
                        Pen BPen = new Pen(Color.Gray, .05F);
                        e.Graphics.DrawRectangle(BPen, BRect);
                    }
                    break;
            }
        }

        public void Reset()
        {
            View = MineCellView.Button;
            HasMine = false;
            Number = 0;
            HasExplosed = false;
            WrongFlag = false;
        }
    }
}
