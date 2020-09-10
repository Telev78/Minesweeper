using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minesweeper
{
    public partial class FormBestTimes : Form
    {
        public FormBestTimes()
        {
            InitializeComponent();
        }

        private void ShowScores()
        {
            lblBeginnerTime.Text = Properties.Settings.Default.beginnerTime.ToString() + " seconds";
            lblIntermediateTime.Text = Properties.Settings.Default.intermediateTime.ToString() + " seconds";
            lblExpertTime.Text = Properties.Settings.Default.expertTime.ToString() + " seconds";

            lblBeginnerName.Text = Properties.Settings.Default.beginnerName;
            lblIntermediateName.Text = Properties.Settings.Default.intermediateName;
            lblExpertName.Text = Properties.Settings.Default.expertName;

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.beginnerTime = 9999.99f;
            Properties.Settings.Default.intermediateTime = 9999.99f;
            Properties.Settings.Default.expertTime = 9999.99f;

            Properties.Settings.Default.beginnerName = "Anonymous";
            Properties.Settings.Default.intermediateName = "Anonymous";
            Properties.Settings.Default.expertName = "Anonymous";

            Properties.Settings.Default.Save();

            ShowScores();
        }

        private void FormBestTimes_Load(object sender, EventArgs e)
        {
            ShowScores();
        }
    }
}
