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
    public partial class Form2 : Form
    {
        bool turn = true;
        bool againstcomputerhard = false;
        bool againstcomputermedium = false;
        bool againstcomputereasy = false;
        int turnCount = 0;
        public Form2()
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
            if ((!turn) && (againstcomputerhard))
            {
                computermakemovehard();
            }
            if ((!turn) && (againstcomputereasy))
            {
                computermakemoveeasy();
            }
            if ((!turn) && (againstcomputermedium))
            {
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
                }
            }
            return null;
        }
        private Button look_for_corner()
        {
            if (A1.Text == "O")
            {
                if (A4.Text == "")
                    return A4;
                if (D4.Text == "")
                    return D4;
                if (D1.Text == "")
                    return D1;
            }

            if (A4.Text == "O")
            {
                if (A1.Text == "")
                    return A1;
                if (D4.Text == "")
                    return D4;
                if (D1.Text == "")
                    return D1;
            }

            if (D4.Text == "O")
            {
                if (A1.Text == "")
                    return A1;
                if (A4.Text == "")
                    return A4;
                if (D1.Text == "")
                    return D1;
            }

            if (D1.Text == "O")
            {
                if (A1.Text == "")
                    return A1;
                if (A4.Text == "")
                    return A4;
                if (D4.Text == "")
                    return D4;
            }

            if (A1.Text == "")
                return A1;
            if (A4.Text == "")
                return A4;
            if (D1.Text == "")
                return D1;
            if (D4.Text == "")
                return D4;
            return null;
        }

        private Button look_for_win_or_block(string mark)
        {
            //HORIZONTAL TESTS
            if ((A1.Text == mark) && (A2.Text == mark) && (A3.Text == mark) && (A4.Text == "") )
                return A4;
            if ((A2.Text == mark) && (A3.Text == mark) && (A4.Text == mark)  && (A1.Text == ""))
                return A1;
            if ((A3.Text == mark) && (A4.Text == mark) && (A1.Text == mark) && (A2.Text == ""))
                return A2;
            if ((A4.Text == mark)  && (A1.Text == mark) && (A2.Text == mark) && (A3.Text == ""))
                return A3;
            if ((B2.Text == mark) && (B3.Text == mark) && (B4.Text == mark) && (B1.Text == ""))
                return B1;
            if ((B3.Text == mark) && (B4.Text == mark)  && (B1.Text == mark) && (B2.Text == ""))
                return B2;
            if ((B4.Text == mark) && (B1.Text == mark) && (B2.Text == mark) && (B3.Text == ""))
                return B3;
            if ( (B1.Text == mark) && (B2.Text == mark) && (B3.Text == mark) && (B4.Text == ""))
                return B4;
            if ((C2.Text == mark) && (C3.Text == mark) && (C4.Text == mark) && (C1.Text == ""))
                return C1;
            if ((C3.Text == mark) && (C4.Text == mark) && (C1.Text == mark) && (C2.Text == ""))
                return C2;
            if ((C4.Text == mark) && (C1.Text == mark) && (C2.Text == mark) && (C3.Text == ""))
                return C3;
            if ((C1.Text == mark) && (C2.Text == mark) && (C3.Text == mark) && (C4.Text == ""))
                return C4;
            if ((D2.Text == mark) && (D3.Text == mark) && (D4.Text == mark) && (D1.Text == ""))
                return D1;
            if ((D3.Text == mark) && (D4.Text == mark) && (D1.Text == mark) && (D2.Text == ""))
                return D2;
            if ((D4.Text == mark) && (D1.Text == mark) && (D2.Text == mark) && (D3.Text == ""))
                return D3;
            if ((D1.Text == mark) && (D2.Text == mark) && (D3.Text == mark) && (D4.Text == ""))
                return D4;
            //VERTICAL TESTS
            if ((B1.Text == mark) && (C1.Text == mark) && (D1.Text == mark) && (A1.Text == ""))
                return A1;
            if ((C1.Text == mark) && (D1.Text == mark) && (A1.Text == mark) && (B1.Text == ""))
                return B1;
            if ((D1.Text == mark) && (A1.Text == mark) && (B1.Text == mark) && (C1.Text == ""))
                return C1;
            if ((A1.Text == mark) && (B1.Text == mark) && (C1.Text == mark) && (D1.Text == ""))
                return D1;
            if ((B2.Text == mark) && (C2.Text == mark) && (D2.Text == mark) && (A2.Text == ""))
                return A2;
            if ((C2.Text == mark) && (D2.Text == mark) && (A2.Text == mark) && (B2.Text == ""))
                return B2;
            if ((D2.Text == mark) && (A2.Text == mark) && (B2.Text == mark) && (C2.Text == ""))
                return C2;
            if ((A2.Text == mark) && (B2.Text == mark) && (C2.Text == mark) && (D2.Text == ""))
                return D2;
            if ((B3.Text == mark) && (C3.Text == mark) && (D3.Text == mark) && (A3.Text == ""))
                return A3;
            if ((C3.Text == mark) && (D3.Text == mark) && (A3.Text == mark) && (B3.Text == ""))
                return B3;
            if ((D3.Text == mark) && (A3.Text == mark) && (B3.Text == mark) && (C3.Text == ""))
                return C3;
            if ((A3.Text == mark) && (B3.Text == mark) && (C3.Text == mark) && (D3.Text == ""))
                return D3;
            if ((B4.Text == mark) && (C4.Text == mark) && (D4.Text == mark) && (A4.Text == ""))
                return A4;
            if ((C4.Text == mark) && (D4.Text == mark) && (A4.Text == mark) && (B4.Text == ""))
                return B4;
            if ((D4.Text == mark) && (A4.Text == mark) && (B4.Text == mark) && (C4.Text == ""))
                return C4;
            if ((A4.Text == mark) && (B4.Text == mark) && (C4.Text == mark) && (D4.Text == ""))
                return D4;
            //DIAGONAL TESTS
            if ((B2.Text == mark) && (C3.Text == mark) && (D4.Text == mark) && (A1.Text == ""))
                return A1;
            if ((C3.Text == mark) && (D4.Text == mark) && (A1.Text == mark) && (B2.Text == ""))
                return B2;
            if ((D4.Text == mark) && (A1.Text == mark) && (B2.Text == mark) && (C3.Text == ""))
                return C3;
            if ((A1.Text == mark) && (B2.Text == mark) && (C3.Text == mark) && (D4.Text == ""))
                return D4;

            if ((C2.Text == mark) && (B3.Text == mark)  && (D1.Text == mark) && (A4.Text == ""))
                return A4;
            if ((D1.Text == mark) && (A4.Text == mark) && (B3.Text == mark) && (C2.Text == ""))
                return C2;
            if ((A4.Text == mark) && (B3.Text == mark) && (C2.Text == mark) && (D1.Text == ""))
                return D1;
            if ((A4.Text == mark) && (B3.Text == "") && (C2.Text == mark) && (D1.Text == ""))
                return B3;
            return null;
        }
        private void button_enter(object sender, EventArgs e)
        {

        }
        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
                b.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //if (textBox2.Text.ToUpper() == "COMPUTER")
              //  againstComputerha = true;
            //else
              //  againstComputer = false;
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

        private void checkWin()
        {//vertical win check
            bool winner = false;
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (A3.Text == A4.Text) && (!A1.Enabled))
                winner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (B3.Text == B4.Text) && (!B1.Enabled))
                winner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (C3.Text == C4.Text) && (!C1.Enabled))
                winner = true;
            else if ((D1.Text == D2.Text) && (D2.Text == D3.Text) && (D3.Text == D4.Text) && (!D1.Enabled))
                winner = true;
            //horizantal win check
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (C1.Text == D1.Text) && (!A1.Enabled))
                winner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (C2.Text == D2.Text) && (!A2.Enabled))
                winner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (C3.Text == D3.Text) && (!A3.Enabled))
                winner = true;
            else if ((A4.Text == B4.Text) && (B4.Text == C4.Text) && (C4.Text == D4.Text) && (!A4.Enabled))
                winner = true;
            //diagonal win check
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (C3.Text == D4.Text) && (!A1.Enabled))
                winner = true;
            else if ((D1.Text == C2.Text) && (C2.Text == B3.Text) && (B3.Text == A4.Text) && (!D1.Enabled))
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
            }
            else if (turnCount == 16)
            {
                draw_count.Text = (Int32.Parse(draw_count.Text) + 1).ToString();
                MessageBox.Show("Draw!", "Result");
            }
        }

        private void resetWinCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            o_win_count.Text = "0";
            x_win_count.Text = "0";
            draw_count.Text = "0";
        }

        private void setPlayersDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Sameer";
            textBox2.Text = "Osama";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu m = new MainMenu();
            m.ShowDialog();
            this.Close();
        }

        private void saveee_Click(object sender, EventArgs e)
        {
            StreamWriter File = new StreamWriter("After " + turnCount + " Turns in 4X4.txt");
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
            if (A4.Enabled)
                File.Write(A4.Text + "\n");
            else
                File.Write(A4.Text + "\n");
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
            if (B4.Enabled)
                File.Write(B4.Text + "\n");
            else
                File.Write(B4.Text + "\n");
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
            if (C4.Enabled)
                File.Write(C4.Text + "\n");
            else
                File.Write(C4.Text + "\n");
            if (D1.Enabled)
                File.Write(D1.Text + "\n");
            else
                File.Write(D1.Text + "\n");
            if (D2.Enabled)
                File.Write(D2.Text + "\n");
            else
                File.Write(D2.Text + "\n");
            if (D3.Enabled)
                File.Write(D3.Text + "\n");
            else
                File.Write(D3.Text + "\n");
            if (D4.Enabled)
                File.Write(D4.Text + "\n");
            else
                File.Write(D4.Text + "\n");
            File.Close();
        }

        private void load_Click(object sender, EventArgs e)
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
                        A4.Text = loader.ReadLine();
                        B1.Text = loader.ReadLine();
                        B2.Text = loader.ReadLine();
                        B3.Text = loader.ReadLine();
                        B4.Text = loader.ReadLine();
                        C1.Text = loader.ReadLine();
                        C2.Text = loader.ReadLine();
                        C3.Text = loader.ReadLine();
                        C4.Text = loader.ReadLine();
                        D1.Text = loader.ReadLine();
                        D2.Text = loader.ReadLine();
                        D3.Text = loader.ReadLine();
                        D4.Text = loader.ReadLine();
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
            if (A4.Text == "X" || A4.Text == "O")
            {
                A4.Enabled = false;
                cott++;
            }
            else
                A4.Enabled = true;
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
            if (B4.Text == "X" || B4.Text == "O")
            {
                B4.Enabled = false;
                cott++;
            }
            else
                B4.Enabled = true;
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
            if (C4.Text == "X" || C4.Text == "O")
            {
                C4.Enabled = false;
                cott++;
            }
            else
                C4.Enabled = true;
            if (D1.Text == "X" || D1.Text == "O")
            {
                D1.Enabled = false;
                cott++;
            }
            else
                D1.Enabled = true;
            if (D2.Text == "X" || D2.Text == "O")
            {
                D2.Enabled = false;
                cott++;
            }
            else
                D2.Enabled = true;
            if (D3.Text == "X" || D3.Text == "O")
            {
                D3.Enabled = false;
                cott++;
            }
            else
                D3.Enabled = true;
            if (D4.Text == "X" || D4.Text == "O")
            {
                D4.Enabled = false;
                cott++;
            }
            else
                D4.Enabled = true;
            turnCount = cott;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.ToUpper() == "COMPUTER HARD")
                againstcomputerhard = true;
            else
                againstcomputerhard = false;
            if (textBox1.Text.ToUpper() == "COMPUTER MEDIUM")
                againstcomputermedium = true;
            else
                againstcomputermedium = false;
            if (textBox1.Text.ToUpper() == "COMPUTER EASY")
                againstcomputereasy = true;
            else
                againstcomputereasy = false;
        }
    }
}
