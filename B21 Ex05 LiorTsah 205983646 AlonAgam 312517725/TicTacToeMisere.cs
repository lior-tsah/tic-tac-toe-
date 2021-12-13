using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace B21_Ex05_Lior_205983646_Alon_312517725
{
    // $G$ CSS-016 (-3) Bad class name - The name of classes derived from Form should start with Form.
    public class TicTacToeMisere : Form
    {
        private readonly bool r_IsTwoPlayersGame;
        private readonly StringBuilder m_String;
        private readonly Logic r_Logic;
        private readonly int r_SizeOfBoard;
        private BindingSource bindingSource1;
        private IContainer components;
        private Label m_Player1;
        private Label m_Player2;
        private Label m_Score1;
        private Label m_Score2;

        public TicTacToeMisere(int i_SizeOfBoard, string i_Player1Name, string i_Player2Name, bool i_IsTwoPlayersGame)
        {
            m_String = new StringBuilder();
            r_Logic = new Logic();
            r_SizeOfBoard = i_SizeOfBoard;
            r_IsTwoPlayersGame = i_IsTwoPlayersGame;
            Game.m_ButtonsArray = new Button[r_SizeOfBoard, r_SizeOfBoard];

            initForm();
            initialButtonsArray();
            initialComponents(i_Player1Name, i_Player2Name);
            addControls();
            r_Logic.StartGame(r_SizeOfBoard, r_IsTwoPlayersGame);
        }

        private void initForm()
        {
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.components = new System.ComponentModel.Container();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)this.bindingSource1).BeginInit();
            this.SuspendLayout();
            this.ClientSize = new Size(70 * r_SizeOfBoard, 30 + (70 * r_SizeOfBoard));
            this.Text = "TicTacToeMisere";
            this.CenterToScreen();
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)this.bindingSource1).EndInit();
            this.ResumeLayout(false);
        }

        private void addControls()
        {
            Controls.Add(m_Player1);
            Controls.Add(m_Player2);
            Controls.Add(m_Score1);
            Controls.Add(m_Score2);
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
        }

        private void initialComponents(string i_Player1Name, string i_Player2Name)
        {
            m_Player1 = new Label();
            m_Player2 = new Label();
            m_Score1 = new Label();
            m_Score2 = new Label();

            m_Player1.Text = i_Player1Name;
            m_Player2.Text = i_Player2Name;
            m_Player1.Font = new Font(m_Player2.Font, FontStyle.Bold);
            m_Score1.Text = ":" + r_Logic.Score1.ToString();
            m_Score2.Text = ":" + r_Logic.Score2.ToString();
            m_Player1.Width = TextRenderer.MeasureText(m_Player1.Text, m_Player1.Font).Width;
            m_Player2.Width = TextRenderer.MeasureText(m_Player2.Text, m_Player2.Font).Width;
            m_Score1.Width = TextRenderer.MeasureText(m_Score1.Text, m_Score1.Font).Width;
            m_Score2.Width = TextRenderer.MeasureText(m_Score2.Text, m_Score2.Font).Width;
            m_Player1.Left = (this.Width - (m_Player1.Width + 3 + m_Player2.Width + m_Score1.Width + m_Score2.Width)) / 2;
            m_Score1.Left = m_Player1.Right + 3;
            m_Player2.Left = m_Score1.Right + 3;
            m_Score2.Left = m_Player2.Right + 3;
            m_Player1.Top = this.ClientSize.Height - 25;
            m_Player2.Top = m_Player1.Top;
            m_Score1.Top = m_Player1.Top;
            m_Score2.Top = m_Player1.Top;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void clearButtonsArray()
        {
            for (int i = 0; i < r_SizeOfBoard; i++)
            {
                for (int j = 0; j < r_SizeOfBoard; j++)
                {
                    Game.m_ButtonsArray[i, j].Text = string.Empty;
                    Game.m_ButtonsArray[i, j].Enabled = true;
                }
            }
        }

        private void initialButtonsArray()
        {
            for (int i = 0; i < r_SizeOfBoard; i++)
            {
                for (int j = 0; j < r_SizeOfBoard; j++)
                {
                    Game.m_ButtonsArray[i, j] = new Button
                    {
                        TabStop = false,
                        Location = new Point(10 + (i * 68), 10 + (j * 68)),
                        Size = new Size(60, 60)
                    };
                    Game.m_ButtonsArray[i, j].Click += new System.EventHandler(Button_Click);
                    this.Controls.Add(Game.m_ButtonsArray[i, j]);
                }
            }
        }

        private void checkChoiceOfMessageBox(DialogResult i_DialogResult)
        {
            if (i_DialogResult == DialogResult.Yes)
            {
                clearButtonsArray();
                r_Logic.StartGame(r_SizeOfBoard, r_IsTwoPlayersGame);
                m_Player1.Font = new Font(m_Player1.Font, FontStyle.Bold);
                m_Player2.Font = new Font(m_Player2.Font, FontStyle.Regular);
                m_String.Clear();
            }
            else if (i_DialogResult == DialogResult.No)
            {
                Environment.Exit(1);
            }
        }

        private void ExecuteATie()
        {
            DialogResult dialogResult;

            m_String.AppendLine("Tie!");
            m_String.AppendLine("Would you like to play another round?");
            dialogResult = MessageBox.Show(m_String.ToString(), "A Tie!", MessageBoxButtons.YesNo);
            checkChoiceOfMessageBox(dialogResult);
        }

        private void ExecuteAWin(string i_Winner)
        {
            DialogResult dialogResult;

            m_String.AppendFormat("The Winner is {0}!", i_Winner);
            m_String.AppendLine();
            m_String.AppendLine("Would you like to play another round?");
            dialogResult = MessageBox.Show(m_String.ToString(), "A Win!", MessageBoxButtons.YesNo);

            checkChoiceOfMessageBox(dialogResult);
        }

        // $G$ CSS-999 (-5) Bad refrence variable name (should be in the form of io_PascalCased)
        private void moveOfPlayer(Label i_LabelCurrTurn, Label i_LabelNextTurn, Logic.Player i_CurrPlayer, ref int i_ScoreToChange, Label i_LabelScoreToChange, string i_NextPlayerText, int i_Rows, int i_Columns)
        {
            i_LabelNextTurn.Font = new Font(i_LabelNextTurn.Font, FontStyle.Bold);
            i_LabelCurrTurn.Font = new Font(i_LabelCurrTurn.Font, FontStyle.Regular);
            i_CurrPlayer.ChooseSquare(r_Logic.TheBoard, i_Rows, i_Columns);
            Game.m_ButtonsArray[i_Rows, i_Columns].Text = i_CurrPlayer.Sign;
            Game.m_ButtonsArray[i_Rows, i_Columns].Enabled = false;

            if (r_Logic.TheBoard.CheckForWin(i_CurrPlayer.Sign))
            {
                r_Logic.ThereIsAWinner = true;
                i_ScoreToChange++;
                i_LabelScoreToChange.Text = ":" + i_ScoreToChange;
                ExecuteAWin(i_NextPlayerText);
            }
            else if (r_Logic.Moves == r_SizeOfBoard * r_SizeOfBoard)
            {
                ExecuteATie();
            }
        }

        // $G$ DSN-002 (-10) No UI separation! This class merge the Logic board with the Visual board (UserControl) of the game...
        private void turnOfAGameAgainstPlayer(int i_Rows, int i_Columns)
        {
            r_Logic.Moves++;

            if (r_Logic.Moves % 2 == 1)
            {
                int tempResult = r_Logic.Score2;
                moveOfPlayer(m_Player1, m_Player2, r_Logic.Player1, ref tempResult, m_Score2, m_Player2.Text, i_Rows, i_Columns);
                r_Logic.Score2 = tempResult;
            }
            else
            {
                int tempResult = r_Logic.Score1;
                moveOfPlayer(m_Player2, m_Player1, r_Logic.Player2, ref tempResult, m_Score1, m_Player1.Text, i_Rows, i_Columns);
                r_Logic.Score1 = tempResult;
            }
        }

        private void turnOfAGameAgainstComputer(int i_Rows, int i_Columns)
        {
            int tempResult = r_Logic.Score2;

            r_Logic.Moves++;
            moveOfPlayer(m_Player1, m_Player2, r_Logic.Player1, ref tempResult, m_Score2, m_Player2.Text, i_Rows, i_Columns);
            r_Logic.Score2 = tempResult;

            if (!r_Logic.ThereIsAWinner)
            {
                r_Logic.Comp.MakeMove(r_Logic.TheBoard, r_SizeOfBoard, out int rows, out int colmuns);
                m_Player1.Font = new Font(m_Player1.Font, FontStyle.Bold);
                Game.m_ButtonsArray[rows, colmuns].Text = r_Logic.Comp.Sign;
                Game.m_ButtonsArray[rows, colmuns].Enabled = false;
                r_Logic.Moves++;

                if (r_Logic.TheBoard.CheckForWin(r_Logic.Comp.Sign))
                {
                    r_Logic.ThereIsAWinner = true;
                    r_Logic.Score1++;
                    m_Score1.Text = ":" + r_Logic.Score1;
                    ExecuteAWin(m_Player1.Text);
                }
                else if (r_Logic.Moves == r_SizeOfBoard * r_SizeOfBoard)
                {
                    ExecuteATie();
                }

                m_Player2.Font = new Font(m_Player2.Font, FontStyle.Regular);
            }

            r_Logic.ThereIsAWinner = false;
        }
        // $G$ DSN-999 (-5) function should have only 1 return statement
        private void Button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < r_SizeOfBoard; i++)
            {
                for (int j = 0; j < r_SizeOfBoard; j++)
                {
                    if (r_IsTwoPlayersGame)
                    {
                        if (sender == Game.m_ButtonsArray[i, j])
                        {
                            turnOfAGameAgainstPlayer(i, j);
                            return;
                        }
                    }
                    else
                    {
                        if (sender == Game.m_ButtonsArray[i, j])
                        {
                            turnOfAGameAgainstComputer(i, j);
                            return;
                        }
                    }
                }
            }
        }
    }
}