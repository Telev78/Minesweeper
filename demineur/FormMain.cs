﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Text;

namespace minesweeper
{
    public partial class FormMain : Form
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);
        private PrivateFontCollection fonts = new PrivateFontCollection();
        private Font myFont;

        const int CellSize = 16;
        int Seconds = 0;
        int MarkedMines = 0;
        MineCell[,] MineField;
        Boolean Done = false;
        Boolean Cheat = false;
        Difficulty CurrentLevel = Difficulty.Beginner;
        FormCustom frmCustom = new FormCustom();

        public FormMain()
        {
            InitializeComponent();
            myFont = LoadFont(Properties.Resources.digital_7__mono_);
            Bitmap bmp = Properties.Resources.mine;
            this.Icon = Icon.FromHandle(bmp.GetHicon());
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            labelClock.Font = myFont;
            labelMines.Font = myFont;
            BuildBoard(true);

            ResizeForm();
        }

        private void BuildBoard(Boolean rebuild=false) 
        {
            Done = false;
            Cheat = false;
            Seconds = 0;
            MarkedMines = 0;
            DoLabels();
            timer1.Enabled = false;
            labelMessage.Text = String.Empty;
            this.buttonNewGame.BackgroundImage = global::minesweeper.Properties.Resources.smiley1;

            if (rebuild)
            {
                this.SuspendLayout();
                this.Hide();
                //Loop Through the rows and columns
                MineField = new MineCell[CurrentLevel.Rows, CurrentLevel.Colonnes];
                pnlMine.Visible = false;
                pnlMine.Controls.Clear();
                for (int Row = 0; Row < CurrentLevel.Rows; Row++)
                {
                    for (int Col = 0; Col < CurrentLevel.Colonnes; Col++)
                    {
                        MineCell C = new MineCell();
                        
                        C.Left = (CellSize * Col) + 3;
                        C.Top = (CellSize * Row) + 3;
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

                        pnlMine.Controls.Add(C);
                    }
                }
                pnlMine.Visible = true;
                this.Show();
                this.ResumeLayout();
            }
            else
            {
                foreach(MineCell M in MineField)
                {
                    M.Reset();
                }
            }
        }

        private void GenerateMineField(MineCell excludedCell)
        {
            //Generate Random Mine Locations
            //first click is allways a safe location
            
            Random RX = new Random();
            for (int i = 1; i <= CurrentLevel.Mines; i++)
            {
                int X = 0;
                int Y = 0;

                do
                {
                    X = RX.Next(0, CurrentLevel.Colonnes);
                    Y = RX.Next(0, CurrentLevel.Rows);
                } while (MineField[Y, X].HasMine || MineField[Y,X].Equals(excludedCell));
                MineField[Y, X].HasMine = true;

            }

            //Count the mines
            for (int Row = 0; Row < CurrentLevel.Rows; Row++)
                for (int Col = 0; Col < CurrentLevel.Colonnes; Col++)
                    if (!MineField[Row, Col].HasMine)
                        for (int R = Row - 1; R <= Row + 1; R++)
                            for (int C = Col - 1; C <= Col + 1; C++)
                                if (R >= 0 && R < CurrentLevel.Rows && C >= 0 && C < CurrentLevel.Colonnes && !(Row == R && Col == C))
                                    if (MineField[R, C].HasMine)
                                        MineField[Row, Col].Number++;

            
        }

        private void ResizeForm ()
        {
            this.Hide();
            //Loop to make the form the right size for this number of columns
            //this.Width = CurrentLevel.Colonnes * CellSize;
            //while (this.pnlMine.Width <= (CurrentLevel.Colonnes * CellSize) + 5)
            //{
            //    this.Width += 1;
            //}

            //this.Height = (CurrentLevel.Rows * CellSize) + 150;
            //while (this.pnlMine.Height <= (CurrentLevel.Rows * CellSize) + 5)
            //{
            //    this.Height += 1;
            //}

            this.Width = (CurrentLevel.Colonnes * CellSize) + 40;
            this.Height = (CurrentLevel.Rows * CellSize) + 162;


            this.Show();
        }

        private void StartGame(Difficulty level)
        {
            CurrentLevel = level;
            BuildBoard(true);
            ResizeForm();
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            BuildBoard();
        }

        private void mine_Click(object sender, MouseEventArgs e)
        {
            if (Done) return;
            MineCell M = (MineCell)sender;

            //generate minefield on first click
            if (!timer1.Enabled)
            {
                GenerateMineField(M);

                timer1.Enabled = true;
                labelMessage.Text = "Game in Progress";
            }
            

            if (e.Button == MouseButtons.Left && (M.View == MineCell.MineCellView.Pressed || M.View == MineCell.MineCellView.Button || M.View == MineCell.MineCellView.Question))
            {
                if (M.HasMine)
                {
                    M.HasExplosed = true;
                    
                    EndGame(false);
                }
                else if (M.Number > 0)
                {
                    M.View = MineCell.MineCellView.Number;
                    if (GameOver())
                    {
                        EndGame(true);
                    }
                }else if (M.Number == 0)
                {
                    ShowBlank(M);
                    if (GameOver())
                    {
                        EndGame(true);
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
                    if (R >= 0 && R < CurrentLevel.Rows && C >= 0 && C < CurrentLevel.Colonnes)
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
            labelMines.Text = (CurrentLevel.Mines - MarkedMines).ToString("000");
        }

        private void EndGame (Boolean WinGame)
        {
            timer1.Enabled = false;
            Done = true;
            if (WinGame)
            {
                labelMessage.Text = "You Win !";
                labelMines.Text = 0.ToString("000");
                this.buttonNewGame.BackgroundImage = global::minesweeper.Properties.Resources.smiley4;

                foreach (MineCell MC in MineField)
                {
                    if (MC.HasMine && MC.View != MineCell.MineCellView.Flag)
                        MC.View = MineCell.MineCellView.Flag;
                }
            }
            else
            {
                labelMessage.Text = "Game Over";
                this.buttonNewGame.BackgroundImage = global::minesweeper.Properties.Resources.smiley3;

                foreach (MineCell MC in MineField)
                {
                    if (MC.HasMine && MC.View != MineCell.MineCellView.Flag)
                        MC.View = MineCell.MineCellView.Mine;
                    if (!MC.HasMine && MC.View == MineCell.MineCellView.Flag)
                    {
                        //show wrong mine
                        MC.View = MineCell.MineCellView.Mine;
                        MC.WrongFlag = true;
                    }
                }
            }
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
            if (!beginnerToolStripMenuItem.Checked)
            {
                beginnerToolStripMenuItem.Checked = true;
                intermediateToolStripMenuItem.Checked = false;
                advanceToolStripMenuItem.Checked = false;
                customToolStripMenuItem.Checked = false;
                StartGame(Difficulty.Beginner);
            }
        }

        private void intermediateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!intermediateToolStripMenuItem.Checked)
            {
                beginnerToolStripMenuItem.Checked = false;
                intermediateToolStripMenuItem.Checked = true;
                advanceToolStripMenuItem.Checked = false;
                customToolStripMenuItem.Checked = false;
                StartGame(Difficulty.Intermediate);
            }
        }

        private void advanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!advanceToolStripMenuItem.Checked)
            {
                beginnerToolStripMenuItem.Checked = false;
                intermediateToolStripMenuItem.Checked = false;
                advanceToolStripMenuItem.Checked = true;
                customToolStripMenuItem.Checked = false;
                StartGame(Difficulty.Advanced);
            }
        }

        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustom.Tag = CurrentLevel;
            if (frmCustom.ShowDialog(this) == DialogResult.OK)
            {
                beginnerToolStripMenuItem.Checked = false;
                intermediateToolStripMenuItem.Checked = false;
                advanceToolStripMenuItem.Checked = false;
                customToolStripMenuItem.Checked = true;
                StartGame((Difficulty)frmCustom.Tag);
            }
        }

        private Font LoadFont(byte[] fontData)
        {
            // guide from site : https://bugsdb.com/_en/debug/1f151f87d73a17115c55bc6f957f7fca
            //byte[] fontData = Properties.Resources.digital_7__mono_;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, fontData.Length);
            AddFontMemResourceEx(fontPtr, (uint)fontData.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);
            return new Font(fonts.Families[fonts.Families.Length - 1], 16.0F, FontStyle.Bold);
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
                        if (R >= 0 && R < CurrentLevel.Rows && C >= 0 && C < CurrentLevel.Colonnes)
                        {
                            if (MineField[R, C].View == MineCell.MineCellView.Flag)
                                FC++;

                        }
                    }

                if (FC != M.Number) return;

                for (int R = M.Y - 1; R <= M.Y + 1; R++)
                    for (int C = M.X - 1; C <= M.X + 1; C++)
                    {
                        if (R >= 0 && R < CurrentLevel.Rows && C >= 0 && C < CurrentLevel.Colonnes)
                        {
                            if (MineField[R, C].View == MineCell.MineCellView.Button || MineField[R, C].View == MineCell.MineCellView.Question)
                            {
                                mine_Click(MineField[R, C], new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                            }
                        }
                    }
            }

        }

        private void mine_MouseUp(object sender, MouseEventArgs e)
        {
            if (Done) return;
            this.buttonNewGame.BackgroundImage = global::minesweeper.Properties.Resources.smiley1;
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
                this.buttonNewGame.BackgroundImage = global::minesweeper.Properties.Resources.smiley2;

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

        private void FormMain_Resize(object sender, EventArgs e)
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

        private void pnlMine_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ((Panel)sender).ClientRectangle,
               Color.DarkGray, 3, ButtonBorderStyle.Solid, // left
               Color.DarkGray, 3, ButtonBorderStyle.Solid, // top
               Color.White, 3, ButtonBorderStyle.Solid, // right
               Color.White, 3, ButtonBorderStyle.Solid);// bottom
        }

        private void buttonNewGame_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ((Button)sender).ClientRectangle,
               Color.White, 2, ButtonBorderStyle.Solid, // left
               Color.White, 2, ButtonBorderStyle.Solid, // top
               Color.DarkGray, 2, ButtonBorderStyle.Solid, // right
               Color.DarkGray, 2, ButtonBorderStyle.Solid);// bottom
        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ((Panel)sender).ClientRectangle,
               Color.DarkGray, 2, ButtonBorderStyle.Solid, // left
               Color.DarkGray, 2, ButtonBorderStyle.Solid, // top
               Color.White, 2, ButtonBorderStyle.Solid, // right
               Color.White, 2, ButtonBorderStyle.Solid);// bottom
        }
    }
}
