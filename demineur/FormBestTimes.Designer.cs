namespace minesweeper
{
    partial class FormBestTimes
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblExpertTime = new System.Windows.Forms.Label();
            this.lblIntermediateTime = new System.Windows.Forms.Label();
            this.lblBeginnerTime = new System.Windows.Forms.Label();
            this.lblExpertName = new System.Windows.Forms.Label();
            this.lblIntermediateName = new System.Windows.Forms.Label();
            this.lblBeginnerName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(212, 106);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(122, 106);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(84, 23);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "&Reset Scores";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblExpertTime);
            this.groupBox1.Controls.Add(this.lblIntermediateTime);
            this.groupBox1.Controls.Add(this.lblBeginnerTime);
            this.groupBox1.Controls.Add(this.lblExpertName);
            this.groupBox1.Controls.Add(this.lblIntermediateName);
            this.groupBox1.Controls.Add(this.lblBeginnerName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 87);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fastest Mine Sweepers";
            // 
            // lblExpertTime
            // 
            this.lblExpertTime.AutoSize = true;
            this.lblExpertTime.Location = new System.Drawing.Point(84, 61);
            this.lblExpertTime.Name = "lblExpertTime";
            this.lblExpertTime.Size = new System.Drawing.Size(89, 13);
            this.lblExpertTime.TabIndex = 8;
            this.lblExpertTime.Text = "9999,00 seconds";
            // 
            // lblIntermediateTime
            // 
            this.lblIntermediateTime.AutoSize = true;
            this.lblIntermediateTime.Location = new System.Drawing.Point(84, 38);
            this.lblIntermediateTime.Name = "lblIntermediateTime";
            this.lblIntermediateTime.Size = new System.Drawing.Size(89, 13);
            this.lblIntermediateTime.TabIndex = 7;
            this.lblIntermediateTime.Text = "9999,00 seconds";
            // 
            // lblBeginnerTime
            // 
            this.lblBeginnerTime.AutoSize = true;
            this.lblBeginnerTime.Location = new System.Drawing.Point(84, 15);
            this.lblBeginnerTime.Name = "lblBeginnerTime";
            this.lblBeginnerTime.Size = new System.Drawing.Size(89, 13);
            this.lblBeginnerTime.TabIndex = 6;
            this.lblBeginnerTime.Text = "9999,00 seconds";
            // 
            // lblExpertName
            // 
            this.lblExpertName.AutoSize = true;
            this.lblExpertName.Location = new System.Drawing.Point(175, 61);
            this.lblExpertName.Name = "lblExpertName";
            this.lblExpertName.Size = new System.Drawing.Size(62, 13);
            this.lblExpertName.TabIndex = 5;
            this.lblExpertName.Text = "Anonymous";
            // 
            // lblIntermediateName
            // 
            this.lblIntermediateName.AutoSize = true;
            this.lblIntermediateName.Location = new System.Drawing.Point(175, 38);
            this.lblIntermediateName.Name = "lblIntermediateName";
            this.lblIntermediateName.Size = new System.Drawing.Size(62, 13);
            this.lblIntermediateName.TabIndex = 4;
            this.lblIntermediateName.Text = "Anonymous";
            // 
            // lblBeginnerName
            // 
            this.lblBeginnerName.AutoSize = true;
            this.lblBeginnerName.Location = new System.Drawing.Point(175, 16);
            this.lblBeginnerName.Name = "lblBeginnerName";
            this.lblBeginnerName.Size = new System.Drawing.Size(62, 13);
            this.lblBeginnerName.TabIndex = 3;
            this.lblBeginnerName.Text = "Anonymous";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Expert:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Intermediate:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Beginner:";
            // 
            // FormBestTimes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 141);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBestTimes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Best Times";
            this.Load += new System.EventHandler(this.FormBestTimes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblExpertTime;
        private System.Windows.Forms.Label lblIntermediateTime;
        private System.Windows.Forms.Label lblBeginnerTime;
        private System.Windows.Forms.Label lblExpertName;
        private System.Windows.Forms.Label lblIntermediateName;
        private System.Windows.Forms.Label lblBeginnerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}