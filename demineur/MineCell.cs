using System;
using System.Drawing;
using System.Windows.Forms;


namespace minesweeper
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
        private Color mButtonColor = Color.LightGray;

        public bool WrongFlag { get; set; } = false;

        public bool HasExplosed { get; set; } = false;

        public Color ButtonColor
        {
            get { return mButtonColor; }
            set { mButtonColor = value; this.Invalidate(); }
        }

        public bool HasMine { get; set; }

        public int X { get; set; }

        public int Y { get; set; }
        public int Number { get; set; }

        public MineCellView View
        {
            get { return mView; }
            set { mView = value; this.Invalidate(); }
        }

        public MineCell()
        {
            InitializeComponent();
            //prevent flickering
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            switch (mView)
            {
                case MineCellView.Button:
                    {
                        e.Graphics.Clear(mButtonColor);


                        ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                            Color.White, 2, ButtonBorderStyle.Solid, // left
                            Color.White, 2, ButtonBorderStyle.Solid, // top
                            Color.Gray, 2, ButtonBorderStyle.Solid, // right
                            Color.Gray, 2, ButtonBorderStyle.Solid);// bottom
                    }
                    break;
                case MineCellView.Mine:
                    {
                        //Set Scale
                        e.Graphics.ResetTransform();
                        e.Graphics.TranslateTransform(this.Width / 2, this.Height / 2);
                        e.Graphics.ScaleTransform(this.Width / 2, this.Height / 2);
                        if (!HasExplosed)
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

                        if(WrongFlag)
                        {
                            Pen mPen = new Pen(Color.Red, (Single).2F);
                            e.Graphics.DrawLine(mPen, new PointF(-.7F, -.6F), new PointF(.7F, .7F));
                            e.Graphics.DrawLine(mPen, new PointF(-.7F, .7F), new PointF(.7F, -.6F));
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

                        if (Number > 0 && Number <= 8)
                        {
                            //Draw Number
                            SolidBrush NBrush = new SolidBrush(NColors[Number - 1]);
                            Font myFont = new Font("Times", 1.5F, FontStyle.Bold, GraphicsUnit.World);
                            SizeF SS = e.Graphics.MeasureString(Number.ToString(), myFont);
                            e.Graphics.DrawString(Number.ToString(), myFont, NBrush, -SS.Width / 2, -SS.Height / 2);
                        }
                        //Draw Border
                        Rectangle BRect = new Rectangle(-1, -1, 2, 2);
                        Pen BPen = new Pen(Color.Gray, .15F);
                        e.Graphics.DrawRectangle(BPen, BRect);
                    }
                    break;
                case MineCellView.Flag:
                    {
                        e.Graphics.Clear(Color.LightGray);
                        ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                            Color.White, 2, ButtonBorderStyle.Solid, // left
                            Color.White, 2, ButtonBorderStyle.Solid, // top
                            Color.Gray, 2, ButtonBorderStyle.Solid, // right
                            Color.Gray, 2, ButtonBorderStyle.Solid);// bottom


                        //Set Scale
                        e.Graphics.ResetTransform();
                        e.Graphics.TranslateTransform(this.Width / 2, this.Height / 2);
                        e.Graphics.ScaleTransform(this.Width / 2, this.Height / 2);
                      
                        
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
                        Pen mPen = new Pen(Color.Brown, .1F);
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
                        e.Graphics.Clear(Color.LightGray);
                        ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                            Color.White, 2, ButtonBorderStyle.Solid, // left
                            Color.White, 2, ButtonBorderStyle.Solid, // top
                            Color.Gray, 2, ButtonBorderStyle.Solid, // right
                            Color.Gray, 2, ButtonBorderStyle.Solid);// bottom
                        
                        //Set Scale
                        e.Graphics.ResetTransform();
                        e.Graphics.TranslateTransform(this.Width / 2, this.Height / 2);
                        e.Graphics.ScaleTransform(this.Width / 2, this.Height / 2);
                        

                        //Draw ?
                        SolidBrush NBrush = new SolidBrush(Color.Black);
                        Font myFont = new Font("Times", 1.5F, FontStyle.Bold, GraphicsUnit.World);
                        SizeF SS = e.Graphics.MeasureString("?", myFont);
                        e.Graphics.DrawString("?", myFont, NBrush, -SS.Width / 2, -SS.Height / 2);
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
