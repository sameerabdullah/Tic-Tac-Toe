using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace tactactoeform
{
    public partial class grid3 : Form
    {

        bool turn = true;
        bool againstComputerhard = false;
        bool againstComputermedium = false;
        bool againstComputereasy = false;
        int turnCount = 0;
        public grid3()
        {
            InitializeComponent();
        }
        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";
            turn = !turn;
            b.Enabled = false;
            turnCount++;
            checkWin();
            if ((!turn) && (againstComputerhard))
            {
                computermakemovehard();
            }
            if ((!turn) && (againstComputereasy)) {
                computermakemoveeasy();
            }
            if((!turn) && (againstComputermedium)){
                computermakemovemedium();
            }
        }
        private void computermakemovemedium()
        {
            Button move = null;
            move = look_for_win_or_block("O"); 
            if (move == null)
            {
                move = look_for_corner();
                if (move == null)
                {
                    move = look_for_open_space();
                }
            }
            if (move != null)
                move.PerformClick();
        }
        private void computermakemoveeasy()
        {
            Button move = null;
            move = look_for_win_or_block("X");
            if (move == null)
            {
                move = look_for_open_space();
            }
            if (move != null)
                move.PerformClick();
        }
        private void computermakemovehard()
        {
            Button move = null;

            //look for tic tac toe opportunities
            move = look_for_win_or_block("O"); //look for win
            if (move == null)
            {
                move = look_for_win_or_block("X"); //look for block
                if (move == null)
                {
                    move = look_for_corner();
                    if (move == null)
                    {
                        move = look_for_open_space();
                    }//end if
                }//end if
            }//end if

            if (move != null)
                move.PerformClick();
        }

        private Button look_for_open_space()
        {
            Console.WriteLine("Looking for open space");
            Button b = null;
            foreach (Control c in Controls)
            {
                b = c as Button;
                if (b != null)
                {
                    if (b.Text == "")
                        return b;
                }//end if
            }//end if

            return null;
        }

        private Button look_for_corner()
        {
            Console.WriteLine("Looking for corner");
            if (A1.Text == "O")
            {
                if (A3.Text == "")
                    return A3;
                if (C3.Text == "")
                    return C3;
                if (C1.Text == "")
                    return C1;
            }

            if (A3.Text == "O")
            {
                if (A1.Text == "")
                    return A1;
                if (C3.Text == "")
                    return C3;
                if (C1.Text == "")
                    return C1;
            }

            if (C3.Text == "O")
            {
                if (A1.Text == "")
                    return A3;
                if (A3.Text == "")
                    return A3;
                if (C1.Text == "")
                    return C1;
            }

            if (C1.Text == "O")
            {
                if (A1.Text == "")
                    return A3;
                if (A3.Text == "")
                    return A3;
                if (C3.Text == "")
                    return C3;
            }

            if (A1.Text == "")
                return A1;
            if (A3.Text == "")
                return A3;
            if (C1.Text == "")
                return C1;
            if (C3.Text == "")
                return C3;

            return null;
        }

        private Button look_for_win_or_block(string mark)
        {
            Console.WriteLine("Looking for win or block:  " + mark);
            //HORIZONTAL TESTS
            if ((A1.Text == mark) && (A2.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A2.Text == mark) && (A3.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A1.Text == mark) && (A3.Text == mark) && (A2.Text == ""))
                return A2;

            if ((B1.Text == mark) && (B2.Text == mark) && (B3.Text == ""))
                return B3;
            if ((B2.Text == mark) && (B3.Text == mark) && (B1.Text == ""))
                return B1;
            if ((B1.Text == mark) && (B3.Text == mark) && (B2.Text == ""))
                return B2;

            if ((C1.Text == mark) && (C2.Text == mark) && (C3.Text == ""))
                return C3;
            if ((C2.Text == mark) && (C3.Text == mark) && (C1.Text == ""))
                return C1;
            if ((C1.Text == mark) && (C3.Text == mark) && (C2.Text == ""))
                return C2;

            //VERTICAL TESTS
            if ((A1.Text == mark) && (B1.Text == mark) && (C1.Text == ""))
                return C1;
            if ((B1.Text == mark) && (C1.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A1.Text == mark) && (C1.Text == mark) && (B1.Text == ""))
                return B1;

            if ((A2.Text == mark) && (B2.Text == mark) && (C2.Text == ""))
                return C2;
            if ((B2.Text == mark) && (C2.Text == mark) && (A2.Text == ""))
                return A2;
            if ((A2.Text == mark) && (C2.Text == mark) && (B2.Text == ""))
                return B2;

            if ((A3.Text == mark) && (B3.Text == mark) && (C3.Text == ""))
                return C3;
            if ((B3.Text == mark) && (C3.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A3.Text == mark) && (C3.Text == mark) && (B3.Text == ""))
                return B3;

            //DIAGONAL TESTS
            if ((A1.Text == mark) && (B2.Text == mark) && (C3.Text == ""))
                return C3;
            if ((B2.Text == mark) && (C3.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A1.Text == mark) && (C3.Text == mark) && (B2.Text == ""))
                return B2;

            if ((A3.Text == mark) && (B2.Text == mark) && (C1.Text == ""))
                return C1;
            if ((B2.Text == mark) && (C1.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A3.Text == mark) && (C1.Text == mark) && (B2.Text == ""))
                return B2;

            return null;
        }
        private void checkWin()
        {
            bool winner = false;
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                winner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                winner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                winner = true;
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                winner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                winner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                winner = true;
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                winner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                winner = true;
            if (winner)
            {
                disableButtons();
                String win = "";
                if (turn)
                {
                    win = textBox1.Text;
                    x_win_count.Text = (Int32.Parse(x_win_count.Text) + 1).ToString();
                }
                else
                {
                    win = textBox2.Text;
                    o_win_count.Text = (Int32.Parse(o_win_count.Text) + 1).ToString();
                }
                MessageBox.Show(win + " Wins!", "Result");
                if (A1.Text == "")
                    A1.Enabled = false;
                if (A2.Text == "")
                    A2.Enabled = false;
                if (A3.Text == "")
                    A3.Enabled = false;
                if (B1.Text == "")
                    B1.Enabled = false;
                if (B2.Text == "")
                    B2.Enabled = false;
                if (B3.Text == "")
                    B3.Enabled = false;
                if (C1.Text == "")
                    C1.Enabled = false;
                if (C2.Text == "")
                    C2.Enabled = false;
                if (C3.Text == "")
                    C3.Enabled = false;
            }
            else if (turnCount == 9)
            {
                draw_count.Text = (Int32.Parse(draw_count.Text) + 1).ToString();
                MessageBox.Show("Draw!", "Result");
            }
        }
        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }
        }
        private void setPlayerDefaultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Sameer";
            textBox2.Text = "Osama";
        }

        private void grid3_Load(object sender, EventArgs e)
        {

        }

        private void resetCounterToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            o_win_count.Text = "0";
            x_win_count.Text = "0";
            draw_count.Text = "0";
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu m = new MainMenu();
            m.ShowDialog();
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("THIS IS A TIC TAC TOE GAME DEVELOPED BY SAMEER ABDULLAH RAJA", "About Tic Tac Toe");
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turnCount = 0;

            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";

                }
                catch { }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.ToUpper() == "COMPUTER HARD")
                againstComputerhard = true;
            else
                againstComputerhard = false;
            if (textBox1.Text.ToUpper() == "COMPUTER MEDIUM")
                againstComputermedium = true;
            else
                againstComputermedium = false;
            if (textBox1.Text.ToUpper() == "COMPUTER EASY")
                againstComputereasy = true;
            else
                againstComputereasy = false;
        }

        private void save(object sender, EventArgs e)
        {
            StreamWriter File = new StreamWriter("After " + turnCount + " Turns in 3X3.txt");
            if (A1.Enabled)
                File.Write(A1.Text + "\n");
            else
                File.Write(A1.Text + "\n");
            if (A2.Enabled)
                File.Write(A2.Text + "\n");
            else
                File.Write(A2.Text + "\n");
            if (A3.Enabled)
                File.Write(A3.Text + "\n");
            else
                File.Write(A3.Text + "\n");
            if (B1.Enabled)
                File.Write(B1.Text + "\n");
            else
                File.Write(B1.Text + "\n");
            if (B2.Enabled)
                File.Write(B2.Text + "\n");
            else
                File.Write(B2.Text + "\n");
            if (B3.Enabled)
                File.Write(B3.Text + "\n");
            else
                File.Write(B3.Text + "\n");
            if (C1.Enabled)
                File.Write(C1.Text + "\n");
            else
                File.Write(C1.Text + "\n");
            if (C2.Enabled)
                File.Write(C2.Text + "\n");
            else
                File.Write(C2.Text + "\n");
            if (C3.Enabled)
                File.Write(C3.Text + "\n");
            else
                File.Write(C3.Text + "\n");
            File.Close();
         }
        private void button2_Click(object sender, EventArgs e)
        {
            int cott = 0;
            using (OpenFileDialog ifd = new OpenFileDialog() { Filter = "Text documents|*.txt", ValidateNames = true, Multiselect = false })
            {
                if (ifd.ShowDialog() == DialogResult.OK)
                    using (StreamReader loader = new StreamReader(ifd.FileName))
                    {
                        A1.Text = loader.ReadLine();
                        A2.Text = loader.ReadLine();
                        A3.Text = loader.ReadLine();
                        B1.Text = loader.ReadLine();
                        B2.Text = loader.ReadLine();
                        B3.Text = loader.ReadLine();
                        C1.Text = loader.ReadLine();
                        C2.Text = loader.ReadLine();
                        C3.Text = loader.ReadLine();
                        loader.Close();
                    }
            }
            if (A1.Text == "X" || A1.Text == "O")
            {
                A1.Enabled = false;
                cott++;
            }
            else
                A1.Enabled = true;
            if (A2.Text == "X" || A2.Text == "O")
            {
                A2.Enabled = false;
                cott++;
            }
            else
                A2.Enabled = true;
            if (A3.Text == "X" || A3.Text == "O")
            {
                A3.Enabled = false;
                cott++;
            }
            else
                A3.Enabled = true;
            if (B1.Text == "X" || B1.Text == "O")
            {
                B1.Enabled = false;
                cott++;
            }
            else
                B1.Enabled = true;
            if (B2.Text == "X" || B2.Text == "O")
            {
                B2.Enabled = false;
                cott++;
            }
            else
                B2.Enabled = true;
            if (B3.Text == "X" || B3.Text == "O")
            {
                B3.Enabled = false;
                cott++;
            }
            else
                B3.Enabled = true;
            if (C1.Text == "X" || C1.Text == "O")
            {
                C1.Enabled = false;
                cott++;
            }
            else
                C1.Enabled = true;
            if (C2.Text == "X" || C2.Text == "O")
            {
                C2.Enabled = false;
                cott++;
            }
            else
                C2.Enabled = true;
            if (C3.Text == "X" || C3.Text == "O")
            {
                C3.Enabled = false;
                cott++;
            }
            else
                C3.Enabled = true;
            turnCount = cott;
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string rootPath = @"C:\Users\samee\source\repos\tactactoeform\tactactoeform\bin\Debug";
            {
                string[] files = Directory.GetFiles(rootPath);
                foreach (string file in files)
                {
                    //listBox1.Items.Add(Path.GetFileName(file));
                }
            }
        }
    }
}
