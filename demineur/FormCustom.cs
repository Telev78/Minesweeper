using System;
using System.Windows.Forms;

namespace minesweeper
{
    public partial class FormCustom : Form
    {
        Difficulty CustomDifficulty = new Difficulty();

        public FormCustom()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtHeight.Text) <= 50)
                CustomDifficulty.Rows = int.Parse(txtHeight.Text);
            else
                CustomDifficulty.Rows = 50;

            if (int.Parse(txtWidth.Text) <= 100)
                CustomDifficulty.Colonnes = int.Parse(txtWidth.Text);
            else
                CustomDifficulty.Colonnes = 100;

            if(int.Parse(txtMines.Text)<=999)
                CustomDifficulty.Mines = int.Parse (txtMines.Text);
            else
                CustomDifficulty.Mines = 999;
            this.Tag = CustomDifficulty;
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FormCustom_Load(object sender, EventArgs e)
        {
            txtHeight.Text = ((Difficulty)this.Tag).Rows.ToString();
            txtWidth.Text = ((Difficulty)this.Tag).Colonnes.ToString();
            txtMines.Text = ((Difficulty)this.Tag).Mines.ToString();
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
