using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Text;
using System.IO.MemoryMappedFiles;

namespace demineur
{
    public partial class Form1 : Form
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);
        private PrivateFontCollection fonts = new PrivateFontCollection();
        private Font myFont;

        int CellSize = 24;
        int BoardRows = 9;
        int BoardCols = 9;
        int MineCount = 10;
        int Seconds = 0;
        int MarkedMines = 0;
        MineCell[,] MineField;
        Boolean Done = false;
        Boolean Cheat = false;

        public Form1()
        {
            InitializeComponent();
            LoadFont();
            Bitmap bmp = Properties.Resources.mine;
            this.Icon = Icon.FromHandle(bmp.GetHicon());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelClock.Font = myFont;
            labelMines.Font = myFont;
            BuildBoard();
        }

        private void BuildBoard() 
        {
            Done = false;
            Cheat = false;
            Seconds = 0;
            MarkedMines = 0;
            DoLabels();
            timer1.Enabled = false;
            labelMessage.Text = String.Empty;
            this.buttonNewGame.Image = global::demineur.Properties.Resources.smiley1;

            this.Hide();
            //Loop Through the rows and columns
            MineField = new MineCell[BoardRows, BoardCols ];
            pnlMine.Controls.Clear();
            for (int Row = 0; Row <= BoardRows - 1; Row++)
            {
                for (int Col = 0; Col <= BoardCols - 1; Col++)
                {
                    MineCell C = new MineCell();
                    pnlMine.Controls.Add(C);
                    C.Left = (CellSize * Col)+1;
                    C.Top = (CellSize * Row)+1;
                    C.Width = CellSize;
                    C.Height = CellSize;
                    C.HasMine = false;
                    C.Number = 0;
                    C.X = Col;
                    C.Y = Row;

                    MineField[Row, Col] = C;
                    C.MouseClick += mine_Click;
                    C.MouseDoubleClick += mine_MouseDoubleClick;
                    C.MouseUp += mine_MouseUp;
                    C.MouseDown += mine_MouseDown;
                }
            }

            //Generate Random Mine Locations
            
            Random RX = new Random();
            for (int i = 1; i<= MineCount; i++)
            {
                int X = 0;
                int Y = 0;

                do
                {
                    X = RX.Next(0, BoardCols);
                    Y = RX.Next(0, BoardRows);
                } while (MineField[Y,X].HasMine);
                MineField[Y, X].HasMine = true;

            }

            //Count the mines
            for (int Row = 0; Row <= BoardRows - 1; Row++)
                for (int Col = 0; Col <= BoardCols - 1; Col++)
                    if (!MineField[Row,Col].HasMine)
                        for (int R = Row - 1; R <= Row + 1; R++)
                            for (int C = Col - 1; C <= Col + 1; C++)
                                if (R >= 0 && R < BoardRows && C >= 0 && C < BoardCols && !(Row == R && Col == C))
                                    if (MineField[R, C].HasMine)
                                        MineField[Row, Col].Number++;

                    
               

            //Loop to make the form the right size for this number of columns
            this.Width = BoardCols * CellSize;
            while (this.pnlMine.Width <= (BoardCols * CellSize)+1)
            {
                this.Width += 1;
            }

            this.Height = BoardRows * CellSize;
            while (this.pnlMine.Height <= (BoardRows * CellSize)+1)
            {
                this.Height += 1;
            }
            
            this.Show();
        }

        private void StartGame(int Rows, int Cols, int Mines )
        {
            BoardRows = Rows;
            BoardCols = Cols;
            MineCount = Mines;
            BuildBoard();

        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            BuildBoard();
        }

        private void mine_Click(object sender, MouseEventArgs e)
        {
            if (Done) return;
            MineCell M = (MineCell)sender;

            timer1.Enabled = true;
            labelMessage.Text = "Game in Progress";

            

            if (e.Button == MouseButtons.Left && (M.View == MineCell.MineCellView.Pressed || M.View == MineCell.MineCellView.Button || M.View == MineCell.MineCellView.Question))
            {
                if (M.HasMine)
                {
                    M.HasExplosed = true;
                    foreach (MineCell MC in MineField)
                    {
                        if (MC.HasMine)
                            MC.View = MineCell.MineCellView.Mine;
                        if (!MC.HasMine && MC.View == MineCell.MineCellView.Flag)
                        {
                            //show wrong mine
                            MC.View = MineCell.MineCellView.Mine;
                            MC.WrongFlag = true;
                        }
                    }
                    timer1.Enabled = false;
                    labelMessage.Text = "Game Over";
                    this.buttonNewGame.Image = global::demineur.Properties.Resources.smiley3;
                    Done = true;
                }
                else if (M.Number > 0)
                {
                    M.View = MineCell.MineCellView.Number;
                    if (GameOver())
                    {
                        timer1.Enabled = false;
                        labelMessage.Text = "You Win !";
                        this.buttonNewGame.Image = global::demineur.Properties.Resources.smiley4;
                        Done = true;
                    }
                }else if (M.Number == 0)
                {
                    ShowBlank(M);
                    if (GameOver())
                    {
                        timer1.Enabled = false;
                        labelMessage.Text = "You Win !";
                        this.buttonNewGame.Image = global::demineur.Properties.Resources.smiley4;
                        Done = true;
                    }
                }
            }
            else if (e.Button == MouseButtons.Right && M.View != MineCell.MineCellView.Number)
            {
                
                switch (M.View)
                {
                    case MineCell.MineCellView.Button:
                        M.View = MineCell.MineCellView.Flag;
                        MarkedMines++;
                        DoLabels();
                        break;
                    case MineCell.MineCellView.Flag:
                        M.View = MineCell.MineCellView.Question;
                        MarkedMines--;
                        DoLabels();
                        break;
                    default:
                        M.View = MineCell.MineCellView.Button;
                        break;

                }
            }
        }

        private void ShowBlank(MineCell M)
        {
            M.View = MineCell.MineCellView.Number;
            for (int R = M.Y - 1; R <= M.Y + 1; R++)
                for (int C = M.X - 1; C <= M.X + 1; C++)
                    if (R >= 0 && R < BoardRows && C >= 0 && C < BoardCols)
                    {
                        MineCell MC = MineField[R, C];
                        if (MC.View == MineCell.MineCellView.Button)
                        {
                            if (MC.Number == 0)
                                ShowBlank(MC);
                            else
                                MC.View = MineCell.MineCellView.Number;
                        }
                    }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Seconds++;
            DoLabels();
        }

        private void DoLabels ()
        {
            labelClock.Text = Seconds.ToString("000");
            labelMines.Text = (MineCount - MarkedMines).ToString("000");
        }

        private Boolean GameOver ()
        {
            Boolean TV = true;
            foreach (MineCell MC in MineField)
            {
                if (!MC.HasMine && MC.View != MineCell.MineCellView.Number)
                    TV = false;
            }
            return TV;
        }

        private void beginnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartGame(9, 9, 10);
        }

        private void intermediateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartGame(16,16,40);
        }

        private void advanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartGame(16,30,99);
        }

        private void LoadFont()
        {
            // guide from site : https://bugsdb.com/_en/debug/1f151f87d73a17115c55bc6f957f7fca
            byte[] fontData = Properties.Resources.digital_7__mono_;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.digital_7__mono_.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.digital_7__mono_.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);
            myFont = new Font(fonts.Families[0], 24.0F);
        }

        private void mine_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Done) return;

            MineCell M = (MineCell)sender;
            if (e.Button == MouseButtons.Left && M.View==MineCell.MineCellView.Number)
            {
                int FC = 0;
                for (int R = M.Y - 1; R <= M.Y + 1; R++)
                    for (int C = M.X - 1; C <= M.X + 1; C++)
                    {
                        if (R >= 0 && R < BoardRows && C >= 0 && C < BoardCols)
                        {
                            MineCell MC = MineField[R, C];
                            if (MC.View == MineCell.MineCellView.Flag)
                                FC++;

                        }
                    }

                if (FC != M.Number) return;

                for (int R = M.Y - 1; R <= M.Y + 1; R++)
                    for (int C = M.X - 1; C <= M.X + 1; C++)
                    {
                        if (R >= 0 && R < BoardRows && C >= 0 && C < BoardCols)
                        {
                            MineCell MC = MineField[R, C];
                            if (MC.View == MineCell.MineCellView.Button || MC.View == MineCell.MineCellView.Question)
                            {
                                mine_Click(MC, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                            }
                        }
                    }
            }

        }

        private void mine_MouseUp(object sender, MouseEventArgs e)
        {
            if (Done) return;
            this.buttonNewGame.Image = global::demineur.Properties.Resources.smiley1;
            MineCell M = (MineCell)sender;
            
            if (M.View == MineCell.MineCellView.Pressed)
                M.View = MineCell.MineCellView.Button;
        }

        private void mine_MouseDown(object sender, MouseEventArgs e)
        {
            if (Done) return;
            MineCell M = (MineCell)sender;
            if (e.Button == MouseButtons.Left && M.View == MineCell.MineCellView.Button)
            {
                this.buttonNewGame.Image = global::demineur.Properties.Resources.smiley2;

                M.View = MineCell.MineCellView.Pressed;
            }

            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cheatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            foreach (MineCell M in MineField)
            {
                if (!Cheat)
                {
                    if (M.HasMine)
                        M.ButtonColor = Color.Red;
                    else if (M.Number > 0)
                        M.ButtonColor = Color.Green;
                }
                else
                {
                    M.ButtonColor = Color.LightGray;
                }
            }

            Cheat = !Cheat;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                timer1.Enabled = false;
            }
            else if (WindowState == FormWindowState.Normal && Seconds > 0 && !GameOver())
            {
                timer1.Enabled = true;
            }
        }
    }
}
