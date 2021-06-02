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
    public partial class grid6x6 : Form
    {
        bool turn = true;
        bool againstcomputerhard = false;
        bool againstcomputereasy = false;
        bool againstcomputermedium = false;
        int turnCount = 0;
        public grid6x6()
        {
            InitializeComponent();
        }

        private void grid6x6_Load(object sender, EventArgs e)
        {

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
                }//end if
            }//end if

            return null;
        }
        private Button look_for_corner()
        {
            if (A1.Text == "O")
            {
                if (A6.Text == "")
                    return A6;
                if (F6.Text == "")
                    return F6;
                if (F6.Text == "")
                    return F6;
            }

            if (A6.Text == "O")
            {
                if (A1.Text == "")
                    return A1;
                if (F6.Text == "")
                    return F6;
                if (F1.Text == "")
                    return F1;
            }

            if (F6.Text == "O")
            {
                if (A1.Text == "")
                    return A1;
                if (A6.Text == "")
                    return A6;
                if (F1.Text == "")
                    return F1;
            }

            if (F1.Text == "O")
            {
                if (A1.Text == "")
                    return A1;
                if (A6.Text == "")
                    return A6;
                if (F6.Text == "")
                    return F6;
            }

            if (A1.Text == "")
                return A1;
            if (A6.Text == "")
                return A6;
            if (F1.Text == "")
                return F1;
            if (F6.Text == "")
                return F6;
            return null;
        }

        private Button look_for_win_or_block(string mark)
        {
            Console.WriteLine("Looking for win or block:  " + mark);
            //HORIZONTAL TESTS
            if ((A1.Text == mark) && (A2.Text == mark) && (A3.Text == mark) && (A4.Text == mark) && (A6.Text == mark) && (A5.Text == ""))
                return A5;
            if ((A2.Text == mark) && (A3.Text == mark) && (A4.Text == mark) && (A5.Text == mark) && (A6.Text == mark) &&(A1.Text == ""))
                return A1;
            if ((A3.Text == mark) && (A4.Text == mark) && (A5.Text == mark) && (A1.Text == mark) && (A6.Text == mark) && (A2.Text == ""))
                return A2;
            if ((A4.Text == mark) && (A5.Text == mark) && (A1.Text == mark) && (A2.Text == mark) && (A6.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A5.Text == mark) && (A1.Text == mark) && (A2.Text == mark) && (A3.Text == mark) && (A6.Text == mark) && (A4.Text == ""))
                return A4;
            if ((A5.Text == mark) && (A1.Text == mark) && (A2.Text == mark) && (A3.Text == mark) && (A6.Text == "") && (A4.Text == mark))
                return A6;

            if ((B1.Text == mark) && (B2.Text == mark) && (B3.Text == mark) && (B4.Text == mark) && (B6.Text == mark) && (B5.Text == ""))
                return B5;
            if ((B2.Text == mark) && (B3.Text == mark) && (B4.Text == mark) && (B5.Text == mark) && (B6.Text == mark) && (B1.Text == ""))
                return B1;
            if ((B3.Text == mark) && (B4.Text == mark) && (B5.Text == mark) && (B1.Text == mark) && (B2.Text == "") && (B6.Text == mark))
                return B2;
            if ((B4.Text == mark) && (B5.Text == mark) && (B1.Text == mark) && (B2.Text == mark) && (B3.Text == "") && (B6.Text == mark))
                return B3;
            if ((B5.Text == mark) && (B6.Text == mark) && (B1.Text == mark) && (B2.Text == mark) && (B3.Text == mark) && (B4.Text == ""))
                return B4;
            if ((B5.Text == mark) && (B6.Text == "") && (B1.Text == mark) && (B2.Text == mark) && (B3.Text == mark) && (B4.Text == mark))
                return B6;

            if ((C1.Text == mark) && (C2.Text == mark) && (C3.Text == mark) && (C6.Text == mark) && (C4.Text == mark) && (C5.Text == ""))
                return C5;
            if ((C2.Text == mark) && (C3.Text == mark) && (C4.Text == mark) && (C6.Text == mark) && (C5.Text == mark) && (C1.Text == ""))
                return C1;
            if ((C3.Text == mark) && (C4.Text == mark) && (C5.Text == mark) && (C1.Text == mark) && (C6.Text == mark) && (C2.Text == ""))
                return C2;
            if ((C4.Text == mark) && (C5.Text == mark) && (C1.Text == mark) && (C2.Text == mark) && (C6.Text == mark) && (C3.Text == ""))
                return C3;
            if ((C5.Text == mark) && (C1.Text == mark) && (C2.Text == mark) && (C3.Text == mark) && (C6.Text == mark) && (C4.Text == ""))
                return C4;
            if ((C5.Text == mark) && (C1.Text == mark) && (C2.Text == mark) && (C3.Text == mark) && (C6.Text == "") && (C4.Text == mark))
                return C6;
            
            if ((D1.Text == mark) && (D2.Text == mark) && (D3.Text == mark) && (D4.Text == mark) && (D6.Text == mark) && (D5.Text == ""))
                return D5;
            if ((D2.Text == mark) && (D3.Text == mark) && (D4.Text == mark) && (D5.Text == mark) && (D6.Text == mark) && (D1.Text == ""))
                return D1;
            if ((D3.Text == mark) && (D4.Text == mark) && (D5.Text == mark) && (D1.Text == mark) && (D6.Text == mark) && (D2.Text == ""))
                return D2;
            if ((D4.Text == mark) && (D5.Text == mark) && (D1.Text == mark) && (D2.Text == mark) && (D6.Text == mark) && (D3.Text == ""))
                return D3;
            if ((D5.Text == mark) && (D1.Text == mark) && (D2.Text == mark) && (D3.Text == mark) && (D6.Text == mark) && (D4.Text == ""))
                return D4;
            if ((D5.Text == mark) && (D1.Text == mark) && (D2.Text == mark) && (D3.Text == mark) && (D6.Text == "") && (D4.Text == mark))
                return D6;

            if ((E1.Text == mark) && (E2.Text == mark) && (E3.Text == mark) && (E4.Text == mark) && (E6.Text == mark) && (E5.Text == ""))
                return E5;
            if ((E2.Text == mark) && (E3.Text == mark) && (E4.Text == mark) && (E5.Text == mark) && (E6.Text == mark) && (E1.Text == ""))
                return E1;
            if ((E3.Text == mark) && (E4.Text == mark) && (E5.Text == mark) && (E1.Text == mark) && (E6.Text == mark) && (E2.Text == ""))
                return E2;
            if ((E4.Text == mark) && (E5.Text == mark) && (E1.Text == mark) && (E2.Text == mark) && (E6.Text == mark) && (E3.Text == ""))
                return E3;
            if ((E5.Text == mark) && (E1.Text == mark) && (E2.Text == mark) && (E3.Text == mark) && (E6.Text == mark) && (E4.Text == ""))
                return E4;
            if ((E5.Text == mark) && (E1.Text == mark) && (E2.Text == mark) && (E3.Text == mark) && (E6.Text == "") && (E4.Text == mark))
                return E6;
            
            if ((F1.Text == mark) && (F2.Text == mark) && (F3.Text == mark) && (F4.Text == mark) && (F6.Text == mark) && (F5.Text == ""))
                return F5;
            if ((F2.Text == mark) && (F3.Text == mark) && (F4.Text == mark) && (F5.Text == mark) && (F6.Text == mark) && (F1.Text == ""))
                return F1;
            if ((F3.Text == mark) && (F4.Text == mark) && (F5.Text == mark) && (F1.Text == mark) && (F6.Text == mark) && (F2.Text == ""))
                return F2;
            if ((F4.Text == mark) && (F5.Text == mark) && (F1.Text == mark) && (F2.Text == mark) && (F6.Text == mark) && (F3.Text == ""))
                return F3;
            if ((F5.Text == mark) && (F1.Text == mark) && (F2.Text == mark) && (F3.Text == mark) && (F6.Text == mark) && (F4.Text == ""))
                return F4;
            if ((F5.Text == mark) && (F1.Text == mark) && (F2.Text == mark) && (F3.Text == mark) && (F6.Text == "") && (F4.Text == mark))
                return F6;

            //VERTICAL TESTS
            if ((A1.Text == mark) && (B1.Text == mark) && (C1.Text == mark) && (D1.Text == mark) && (F1.Text == mark) && (E1.Text == ""))
                return E1;
            if ((B1.Text == mark) && (C1.Text == mark) && (D1.Text == mark) && (E1.Text == mark) && (F1.Text == mark) && (A1.Text == ""))
                return A1;
            if ((C1.Text == mark) && (D1.Text == mark) && (E1.Text == mark) && (A1.Text == mark) && (F1.Text == mark) && (B1.Text == ""))
                return B1;
            if ((D1.Text == mark) && (E1.Text == mark) && (A1.Text == mark) && (B1.Text == mark) && (F1.Text == mark) && (C1.Text == ""))
                return C1;
            if ((E1.Text == mark) && (A1.Text == mark) && (B1.Text == mark) && (C1.Text == mark) && (F1.Text == mark) && (D1.Text == ""))
                return D1;
            if ((E1.Text == mark) && (A1.Text == mark) && (B1.Text == mark) && (C1.Text == mark) && (F1.Text == "") && (D1.Text == mark))
                return F1;

            if ((A2.Text == mark) && (B2.Text == mark) && (C2.Text == mark) && (D2.Text == mark) && (F2.Text == mark) && (E2.Text == ""))
                return E2;
            if ((B2.Text == mark) && (C2.Text == mark) && (D2.Text == mark) && (E2.Text == mark) && (F2.Text == mark) && (A2.Text == ""))
                return A2;
            if ((C2.Text == mark) && (D2.Text == mark) && (E2.Text == mark) && (A2.Text == mark) && (F2.Text == mark) && (B2.Text == ""))
                return B2;
            if ((D2.Text == mark) && (E2.Text == mark) && (A2.Text == mark) && (B2.Text == mark) && (F2.Text == mark) && (C2.Text == ""))
                return C2;
            if ((E2.Text == mark) && (A2.Text == mark) && (B2.Text == mark) && (C2.Text == mark) && (F2.Text == mark) && (D2.Text == ""))
                return D2;
            if ((E2.Text == mark) && (A2.Text == mark) && (B2.Text == mark) && (C2.Text == mark) && (F2.Text == "") && (D2.Text == mark))
                return F2;

            if ((A3.Text == mark) && (B3.Text == mark) && (C3.Text == mark) && (D3.Text == mark) && (F3.Text == mark) && (E3.Text == ""))
                return E3;
            if ((B3.Text == mark) && (C3.Text == mark) && (D3.Text == mark) && (E3.Text == mark) && (F3.Text == mark) && (A3.Text == ""))
                return A3;
            if ((C3.Text == mark) && (D3.Text == mark) && (E3.Text == mark) && (A3.Text == mark) && (F3.Text == mark) && (B3.Text == ""))
                return B3;
            if ((D3.Text == mark) && (E3.Text == mark) && (A3.Text == mark) && (B3.Text == mark) && (F3.Text == mark) && (C3.Text == ""))
                return C3;
            if ((E3.Text == mark) && (A3.Text == mark) && (B3.Text == mark) && (C3.Text == mark) && (F3.Text == mark) && (D3.Text == ""))
                return D3;
            if ((E3.Text == mark) && (A3.Text == mark) && (B3.Text == mark) && (C3.Text == mark) && (F3.Text == "") && (D3.Text == mark))
                return F3;

            if ((A4.Text == mark) && (B4.Text == mark) && (C4.Text == mark) && (D4.Text == mark) && (F4.Text == mark) && (E4.Text == ""))
                return E4;
            if ((B4.Text == mark) && (C4.Text == mark) && (D4.Text == mark) && (E4.Text == mark) && (F4.Text == mark) && (A4.Text == ""))
                return A4;
            if ((C4.Text == mark) && (D4.Text == mark) && (E4.Text == mark) && (A4.Text == mark) && (F4.Text == mark) && (B4.Text == ""))
                return B4;
            if ((D4.Text == mark) && (E4.Text == mark) && (A4.Text == mark) && (B4.Text == mark) && (F4.Text == mark) && (C4.Text == ""))
                return C4;
            if ((E4.Text == mark) && (A4.Text == mark) && (B4.Text == mark) && (C4.Text == mark) && (F4.Text == mark) && (D4.Text == ""))
                return D4;
            if ((E4.Text == mark) && (A4.Text == mark) && (B4.Text == mark) && (C4.Text == mark) && (F4.Text == "") && (D4.Text == mark))
                return F4;

            if ((A5.Text == mark) && (B5.Text == mark) && (C5.Text == mark) && (D5.Text == mark) && (F5.Text == mark) && (E5.Text == ""))
                return E5;
            if ((B5.Text == mark) && (C5.Text == mark) && (D5.Text == mark) && (E5.Text == mark) && (F5.Text == mark) && (A5.Text == ""))
                return A5;
            if ((C5.Text == mark) && (D5.Text == mark) && (E5.Text == mark) && (A5.Text == mark) && (F5.Text == mark) && (B5.Text == ""))
                return B5;
            if ((D5.Text == mark) && (E5.Text == mark) && (A5.Text == mark) && (B5.Text == mark) && (F5.Text == mark) && (C5.Text == ""))
                return C5;
            if ((E5.Text == mark) && (A5.Text == mark) && (B5.Text == mark) && (C5.Text == mark) && (F5.Text == mark) && (D5.Text == ""))
                return D5;
            if ((E5.Text == mark) && (A5.Text == mark) && (B5.Text == mark) && (C5.Text == mark) && (F5.Text == "") && (D5.Text == mark))
                return F5;

            if ((A6.Text == mark) && (B6.Text == mark) && (C6.Text == mark) && (D6.Text == mark) && (F6.Text == mark) && (E6.Text == ""))
                return E6;
            if ((B6.Text == mark) && (C6.Text == mark) && (D6.Text == mark) && (E6.Text == mark) && (F6.Text == mark) && (A6.Text == ""))
                return A6;
            if ((C6.Text == mark) && (D6.Text == mark) && (E6.Text == mark) && (A6.Text == mark) && (F6.Text == mark) && (B6.Text == ""))
                return B6;
            if ((D6.Text == mark) && (E6.Text == mark) && (A6.Text == mark) && (B6.Text == mark) && (F6.Text == mark) && (C6.Text == ""))
                return C6;
            if ((E6.Text == mark) && (A6.Text == mark) && (B6.Text == mark) && (C6.Text == mark) && (F6.Text == mark) && (D6.Text == ""))
                return D6;
            if ((E6.Text == mark) && (A6.Text == mark) && (B6.Text == mark) && (C6.Text == mark) && (F6.Text == "") && (D6.Text == mark))
                return F6;
            //DIAGONAL TESTS
            if ((A1.Text == mark) && (B2.Text == mark) && (C3.Text == mark) && (D4.Text == mark) && (F6.Text == mark) && (E5.Text == ""))
                return D4;
            if ((B2.Text == mark) && (C3.Text == mark) && (D4.Text == mark) && (E5.Text == mark) && (F6.Text == mark) && (A1.Text == ""))
                return A1;
            if ((C3.Text == mark) && (D4.Text == mark) && (E5.Text == mark) && (A1.Text == mark) && (F6.Text == mark) && (B2.Text == ""))
                return B2;
            if ((D4.Text == mark) && (E5.Text == mark) && (A1.Text == mark) && (B2.Text == mark) && (F6.Text == mark) && (C3.Text == ""))
                return C3;
            if ((E5.Text == mark) && (A1.Text == mark) && (B2.Text == mark) && (C3.Text == mark) && (F6.Text == mark) && (D4.Text == ""))
                return D4;
            if ((E5.Text == mark) && (A1.Text == mark) && (B2.Text == mark) && (C3.Text == mark) && (F6.Text == "") && (D4.Text == mark))
                return F6;

            if ((A6.Text == mark) && (B5.Text == mark) && (C4.Text == mark) && (D3.Text == mark) && (F1.Text == mark) && (E2.Text == ""))
                return E2;
            if ((B5.Text == mark) && (C4.Text == mark) && (D3.Text == mark) && (E2.Text == mark) && (F1.Text == mark) && (A6.Text == ""))
                return A6;
            if ((C4.Text == mark) && (D3.Text == mark) && (E2.Text == mark) && (A6.Text == mark) && (F1.Text == mark) && (B5.Text == ""))
                return B5;
            if ((D3.Text == mark) && (E2.Text == mark) && (A6.Text == mark) && (B5.Text == mark) && (F1.Text == mark) && (C4.Text == ""))
                return C4;
            if ((E2.Text == mark) && (A6.Text == mark) && (B5.Text == mark) && (C4.Text == mark) && (F1.Text == mark) && (D3.Text == ""))
                return D3;
            if ((E2.Text == mark) && (A6.Text == mark) && (B5.Text == mark) && (C4.Text == mark) && (F1.Text == "") && (D3.Text == mark))
                return F1;

            return null;
        }
        private void checkWin()
        {//vertical win check
            bool winner = false;
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (A3.Text == A4.Text) && (A4.Text == A5.Text) && (A5.Text==A6.Text) && (!A1.Enabled))
                winner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (B3.Text == B4.Text) && (B4.Text == B5.Text) && (B5.Text == B6.Text) && (!B1.Enabled))
                winner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (C3.Text == C4.Text) && (C4.Text == C5.Text) && (C5.Text == C6.Text) && (!C1.Enabled))
                winner = true;
            else if ((D1.Text == D2.Text) && (D2.Text == D3.Text) && (D3.Text == D4.Text) && (D4.Text == D5.Text) && (D5.Text == D6.Text) && (!D1.Enabled))
                winner = true;
            else if ((E1.Text == E2.Text) && (E2.Text == E3.Text) && (E3.Text == E4.Text) && (E4.Text == E5.Text) && (E5.Text == E6.Text) && (!E1.Enabled))
                winner = true;
            else if ((F1.Text == F2.Text) && (F2.Text == F3.Text) && (F3.Text == F4.Text) && (F4.Text == F5.Text) && (F5.Text == F6.Text) && (!F1.Enabled))
                winner = true;
            //horizantal win check
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (C1.Text == D1.Text) && (D1.Text == E1.Text) && (E1.Text == F1.Text) && (!A1.Enabled))
                winner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (C2.Text == D2.Text) && (D2.Text == E2.Text) && (E2.Text == F2.Text) && (!A2.Enabled))
                winner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (C3.Text == D3.Text) && (D3.Text == E3.Text) && (E3.Text == F3.Text) && (!A3.Enabled))
                winner = true;
            else if ((A4.Text == B4.Text) && (B4.Text == C4.Text) && (C4.Text == D4.Text) && (D4.Text == E4.Text) && (E4.Text == F4.Text) && (!A4.Enabled))
                winner = true;
            else if ((A5.Text == B5.Text) && (B5.Text == C5.Text) && (C5.Text == D5.Text) && (D5.Text == E5.Text) && (E5.Text == F5.Text) && (!A5.Enabled))
                winner = true;
            else if ((A6.Text == B6.Text) && (B6.Text == C6.Text) && (C6.Text == D6.Text) && (D6.Text == E6.Text) && (E6.Text == F6.Text) && (!A6.Enabled))
                winner = true;
            //diagonal win check
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (C3.Text == D4.Text) && (D4.Text == E5.Text) && (E5.Text==F6.Text) && (!A1.Enabled))
                winner = true;
            else if ((F1.Text==E2.Text) && (E2.Text == D3.Text) && (D3.Text == C4.Text) && (C4.Text == B5.Text) && (B5.Text == A5.Text) && (!F1.Enabled))
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
            else if (turnCount == 36)
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

        private void exitToMainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu m = new MainMenu();
            m.ShowDialog();
            this.Close();
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

        private void save_Click(object sender, EventArgs e)
        {
            StreamWriter File = new StreamWriter("After " + turnCount + " Turns in 6X6.txt");
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
            if (A5.Enabled)
                File.Write(A5.Text + "\n");
            else
                File.Write(A5.Text + "\n");
            if (A6.Enabled)
                File.Write(A6.Text + "\n");
            else
                File.Write(A6.Text + "\n");

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
            if (B5.Enabled)
                File.Write(B5.Text + "\n");
            else
                File.Write(B5.Text + "\n");
            if (B6.Enabled)
                File.Write(B6.Text + "\n");
            else
                File.Write(B6.Text + "\n");

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
            if (C5.Enabled)
                File.Write(C5.Text + "\n");
            else
                File.Write(C5.Text + "\n");
            if (C6.Enabled)
                File.Write(C6.Text + "\n");
            else
                File.Write(C6.Text + "\n");

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
            if (D5.Enabled)
                File.Write(D5.Text + "\n");
            else
                File.Write(D5.Text + "\n");
            if (D6.Enabled)
                File.Write(D6.Text + "\n");
            else
                File.Write(D6.Text + "\n");

            if (E1.Enabled)
                File.Write(E1.Text + "\n");
            else
                File.Write(E1.Text + "\n");
            if (E2.Enabled)
                File.Write(E2.Text + "\n");
            else
                File.Write(E2.Text + "\n");
            if (E3.Enabled)
                File.Write(E3.Text + "\n");
            else
                File.Write(E3.Text + "\n");
            if (E4.Enabled)
                File.Write(E4.Text + "\n");
            else
                File.Write(E4.Text + "\n");
            if (E5.Enabled)
                File.Write(E5.Text + "\n");
            else
                File.Write(E5.Text + "\n");
            if (E6.Enabled)
                File.Write(E6.Text + "\n");
            else
                File.Write(E6.Text + "\n");

            if (F1.Enabled)
                File.Write(F1.Text + "\n");
            else
                File.Write(F1.Text + "\n");
            if (F2.Enabled)
                File.Write(F2.Text + "\n");
            else
                File.Write(F2.Text + "\n");
            if (F3.Enabled)
                File.Write(F3.Text + "\n");
            else
                File.Write(F3.Text + "\n");
            if (F4.Enabled)
                File.Write(F4.Text + "\n");
            else
                File.Write(F4.Text + "\n");
            if (F5.Enabled)
                File.Write(F5.Text + "\n");
            else
                File.Write(F5.Text + "\n");
            if (F6.Enabled)
                File.Write(F6.Text + "\n");
            else
                File.Write(F6.Text + "\n");
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
                        A4.Text = loader.ReadLine();
                        A5.Text = loader.ReadLine();
                        A6.Text = loader.ReadLine();
                        B1.Text = loader.ReadLine();
                        B2.Text = loader.ReadLine();
                        B3.Text = loader.ReadLine();
                        B4.Text = loader.ReadLine();
                        B5.Text = loader.ReadLine();
                        B6.Text = loader.ReadLine();
                        C1.Text = loader.ReadLine();
                        C2.Text = loader.ReadLine();
                        C3.Text = loader.ReadLine();
                        C4.Text = loader.ReadLine();
                        C5.Text = loader.ReadLine();
                        C6.Text = loader.ReadLine();
                        D1.Text = loader.ReadLine();
                        D2.Text = loader.ReadLine();
                        D3.Text = loader.ReadLine();
                        D4.Text = loader.ReadLine();
                        D5.Text = loader.ReadLine();
                        D6.Text = loader.ReadLine();
                        E1.Text = loader.ReadLine();
                        E2.Text = loader.ReadLine();
                        E3.Text = loader.ReadLine();
                        E4.Text = loader.ReadLine();
                        E5.Text = loader.ReadLine();
                        E6.Text = loader.ReadLine();
                        F1.Text = loader.ReadLine();
                        F2.Text = loader.ReadLine();
                        F3.Text = loader.ReadLine();
                        F4.Text = loader.ReadLine();
                        F5.Text = loader.ReadLine();
                        F6.Text = loader.ReadLine();
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
            if (A5.Text == "X" || A5.Text == "O")
            {
                A5.Enabled = false;
                cott++;
            }
            else
                A5.Enabled = true;
            if (A6.Text == "X" || A6.Text == "O")
            {
                A6.Enabled = false;
                cott++;
            }
            else
                A6.Enabled = true;
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
            if (B5.Text == "X" || B5.Text == "O")
            {
                B5.Enabled = false;
                cott++;
            }
            else
                B5.Enabled = true;
            if (B6.Text == "X" || B6.Text == "O")
            {
                B6.Enabled = false;
                cott++;
            }
            else
                B6.Enabled = true;
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
            if (C5.Text == "X" || C5.Text == "O")
            {
                C5.Enabled = false;
                cott++;
            }
            else
                C5.Enabled = true;
            if (C6.Text == "X" || C6.Text == "O")
            {
                C6.Enabled = false;
                cott++;
            }
            else
                C6.Enabled = true;
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
            if (D5.Text == "X" || D5.Text == "O")
            {
                D5.Enabled = false;
                cott++;
            }
            else
                D5.Enabled = true;
            if (D6.Text == "X" || D6.Text == "O")
            {
                D6.Enabled = false;
                cott++;
            }
            else
                D6.Enabled = true;
            if (E1.Text == "X" || E1.Text == "O")
            {
                E1.Enabled = false;
                cott++;
            }
            else
                E1.Enabled = true;
            if (E2.Text == "X" || E2.Text == "O")
            {
                E2.Enabled = false;
                cott++;
            }
            else
                E2.Enabled = true;
            if (E3.Text == "X" || E3.Text == "O")
            {
                E3.Enabled = false;
                cott++;
            }
            else
                E3.Enabled = true;
            if (E4.Text == "X" || E4.Text == "O")
            {
                E4.Enabled = false;
                cott++;
            }
            else
                E4.Enabled = true;
            if (E5.Text == "X" || E5.Text == "O")
            {
                E5.Enabled = false;
                cott++;
            }
            else
                E5.Enabled = true;
            if (E6.Text == "X" || E6.Text == "O")
            {
                E6.Enabled = false;
                cott++;
            }
            else
                E6.Enabled = true;
            if (F1.Text == "X" || F1.Text == "O")
            {
                F1.Enabled = false;
                cott++;
            }
            else
                F1.Enabled = true;
            if (F2.Text == "X" || F2.Text == "O")
            {
                F2.Enabled = false;
                cott++;
            }
            else
                F2.Enabled = true;
            if (F3.Text == "X" || F3.Text == "O")
            {
                F3.Enabled = false;
                cott++;
            }
            else
                F3.Enabled = true;
            if (F4.Text == "X" || F4.Text == "O")
            {
                F4.Enabled = false;
                cott++;
            }
            else
                F4.Enabled = true;
            if (F5.Text == "X" || F5.Text == "O")
            {
                F5.Enabled = false;
                cott++;
            }
            else
                F5.Enabled = true;
            if (F6.Text == "X" || F6.Text == "O")
            {
                F6.Enabled = false;
                cott++;
            }
            else
                F6.Enabled = true;
            turnCount = cott;
        }
    }
}
