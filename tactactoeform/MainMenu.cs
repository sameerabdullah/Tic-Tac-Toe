using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tactactoeform
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void GRID3X3_Click(object sender, EventArgs e)
        {
            this.Hide();
           grid3  d=new grid3();
            d.ShowDialog();
            this.Close();
        }

        private void grid4x4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 g = new Form2();
            g.ShowDialog();
            this.Close();
        }

        private void grid5x5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f = new Form3();
            f.ShowDialog();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Thanks For Using." +
                "\nDeveloped By *SAMEER ABDULLAH*","About us");
            Application.Exit();
        }

        private void grid6x6_Click(object sender, EventArgs e)
        {
            this.Hide();
            grid6x6 s = new grid6x6();
            s.ShowDialog();
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is Main Menu Of TICTACTOE Game.\n You can play on four different size of Grids." +
                "\nMost exictingly you can play against Computer as well." +
                "\nFor playing against Computer Check Instruction Menu.\n Thanks","About Game");
        }

        private void instructionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In Single Player Mode you can have 3 different levels of difficulty" +
                "\nEasy, Medium and Hard.\nFor Playing against easy difficulty Level type computer easy." +
                "For Playing against medium difficulty level type computer medium" +
                "For Playing against Hard difficulty level type computer hard","Instructions");
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a game developed by SAMEER ABDULLAH ","About Us");
        }
    }
}
