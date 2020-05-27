namespace minesweeper
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.beginnerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intermediateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.cheatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelMines = new System.Windows.Forms.Label();
            this.labelClock = new System.Windows.Forms.Label();
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.pnlMine = new System.Windows.Forms.Panel();
            this.labelMessage = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(454, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripMenuItem1,
            this.beginnerToolStripMenuItem,
            this.intermediateToolStripMenuItem,
            this.advanceToolStripMenuItem,
            this.toolStripMenuItem2,
            this.cheatToolStripMenuItem,
            this.toolStripMenuItem3,
            this.exitToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "&Game";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.buttonNewGame_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(138, 6);
            // 
            // beginnerToolStripMenuItem
            // 
            this.beginnerToolStripMenuItem.Name = "beginnerToolStripMenuItem";
            this.beginnerToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.beginnerToolStripMenuItem.Text = "&Beginner";
            this.beginnerToolStripMenuItem.Click += new System.EventHandler(this.beginnerToolStripMenuItem_Click);
            // 
            // intermediateToolStripMenuItem
            // 
            this.intermediateToolStripMenuItem.Name = "intermediateToolStripMenuItem";
            this.intermediateToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.intermediateToolStripMenuItem.Text = "&Intermediate";
            this.intermediateToolStripMenuItem.Click += new System.EventHandler(this.intermediateToolStripMenuItem_Click);
            // 
            // advanceToolStripMenuItem
            // 
            this.advanceToolStripMenuItem.Name = "advanceToolStripMenuItem";
            this.advanceToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.advanceToolStripMenuItem.Text = "&Advanced";
            this.advanceToolStripMenuItem.Click += new System.EventHandler(this.advanceToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(138, 6);
            // 
            // cheatToolStripMenuItem
            // 
            this.cheatToolStripMenuItem.Name = "cheatToolStripMenuItem";
            this.cheatToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.cheatToolStripMenuItem.Text = "&Cheat";
            this.cheatToolStripMenuItem.Click += new System.EventHandler(this.cheatToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(138, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.labelMines, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelClock, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonNewGame, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlMine, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelMessage, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(454, 344);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // labelMines
            // 
            this.labelMines.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.labelMines.BackColor = System.Drawing.Color.Black;
            this.labelMines.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMines.ForeColor = System.Drawing.Color.Red;
            this.labelMines.Location = new System.Drawing.Point(53, 9);
            this.labelMines.Margin = new System.Windows.Forms.Padding(9);
            this.labelMines.Name = "labelMines";
            this.labelMines.Size = new System.Drawing.Size(90, 42);
            this.labelMines.TabIndex = 0;
            this.labelMines.Text = "0";
            this.labelMines.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelClock
            // 
            this.labelClock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.labelClock.BackColor = System.Drawing.Color.Black;
            this.labelClock.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClock.ForeColor = System.Drawing.Color.Red;
            this.labelClock.Location = new System.Drawing.Point(310, 9);
            this.labelClock.Margin = new System.Windows.Forms.Padding(9);
            this.labelClock.Name = "labelClock";
            this.labelClock.Size = new System.Drawing.Size(90, 42);
            this.labelClock.TabIndex = 1;
            this.labelClock.Text = "0";
            this.labelClock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.BackColor = System.Drawing.SystemColors.Control;
            this.buttonNewGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNewGame.Image = global::minesweeper.Properties.Resources.smiley1;
            this.buttonNewGame.Location = new System.Drawing.Point(206, 9);
            this.buttonNewGame.Margin = new System.Windows.Forms.Padding(9);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(42, 42);
            this.buttonNewGame.TabIndex = 2;
            this.buttonNewGame.UseVisualStyleBackColor = false;
            this.buttonNewGame.Click += new System.EventHandler(this.buttonNewGame_Click);
            // 
            // pnlMine
            // 
            this.pnlMine.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.SetColumnSpan(this.pnlMine, 3);
            this.pnlMine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMine.Location = new System.Drawing.Point(9, 69);
            this.pnlMine.Margin = new System.Windows.Forms.Padding(9);
            this.pnlMine.Name = "pnlMine";
            this.pnlMine.Size = new System.Drawing.Size(436, 236);
            this.pnlMine.TabIndex = 3;
            // 
            // labelMessage
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.labelMessage, 3);
            this.labelMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMessage.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelMessage.Location = new System.Drawing.Point(3, 314);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(448, 30);
            this.labelMessage.TabIndex = 4;
            this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 368);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minesweeper";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem beginnerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem intermediateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem advanceToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelMines;
        private System.Windows.Forms.Label labelClock;
        private System.Windows.Forms.Button buttonNewGame;
        private System.Windows.Forms.Panel pnlMine;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem cheatToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

