using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace B21_Ex05_Lior_205983646_Alon_312517725
{
    // $G$ CSS-016 (-3) Bad class name - The name of classes derived from Form should start with Form.
    public class GameSettings : Form
    {
        private Label m_Players;
        private Label m_Player1;
        private Label m_BoardSize;
        private Label m_RowsLabel;
        private Label m_ColsLabel;
        private NumericUpDown m_RowsNumericUpDown;
        private NumericUpDown m_ColsNumericUpDown;
        private CheckBox m_Player2CheckBox;
        private Button m_ButtonStart;
        private TextBox m_TextboxPlayer1Name;
        private TextBox m_TextboxPlayer2Name;

        public GameSettings()
        {
            createComponents();
            initFormSettings();
            initStartButton();
            initPlayerOneLabel();
            initPlayerOneTextBox();
            initPlayerTwoCheckBox();
            initPlayerTwoTextBox();
            initBoardSizeLabel();
            initRowsLabel();
            initRowsNumericUpDown();
            initColsLabel();
            initColsNumericUpDown();
            addControls();
        }

        private void createComponents()
        {
            m_Players = new Label();
            m_Player1 = new Label();
            m_BoardSize = new Label();
            m_RowsLabel = new Label();
            m_ColsLabel = new Label();
            m_RowsNumericUpDown = new NumericUpDown();
            m_ColsNumericUpDown = new NumericUpDown();
            m_Player2CheckBox = new CheckBox();
            m_ButtonStart = new Button();
            m_TextboxPlayer1Name = new TextBox();
            m_TextboxPlayer2Name = new TextBox();
        }

        private void initFormSettings()
        {
            this.Size = new Size(300, 300);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void initStartButton()
        {
            m_ButtonStart.Location = new Point(35, 200);
            m_ButtonStart.AutoSize = true;
            m_ButtonStart.Text = "Start!";
            m_ButtonStart.Width = 220;
            m_ButtonStart.Click += new System.EventHandler(ButtonStart_Click);
        }

        private void initPlayerOneLabel()
        {
            m_Players.Text = "Players:";
            m_Players.Font = new Font(Label.DefaultFont, FontStyle.Bold);
            m_Players.Location = new Point(20, 10);
            m_Player1.Text = "Player 1:";
            m_Player1.Width = 80;
            m_Player1.Left = m_Players.Left + 15;
            m_Player1.Top = m_Players.Top + 30;
        }

        private void initPlayerOneTextBox()
        {
            m_TextboxPlayer1Name.Width = 100;
            m_TextboxPlayer1Name.Top = m_Player1.Top;
            m_TextboxPlayer1Name.Left = m_Player1.Right + 20;
            m_TextboxPlayer1Name.TextAlign = HorizontalAlignment.Left;
            this.m_TextboxPlayer1Name.TextChanged += new System.EventHandler(TextBox1_TextChanged);
        }

        private void initPlayerTwoCheckBox()
        {
            m_Player2CheckBox.Text = "Player 2:";
            m_Player2CheckBox.Width = 80;
            m_Player2CheckBox.Left = m_Player1.Left;
            m_Player2CheckBox.Top = m_Player1.Top + 30;
            this.m_Player2CheckBox.CheckedChanged += new System.EventHandler(TextboxPlayer2Name_CheckedChanged);
        }

        private void initPlayerTwoTextBox()
        {
            m_TextboxPlayer2Name.Width = 100;
            m_TextboxPlayer2Name.Top = m_TextboxPlayer1Name.Top + 30;
            m_TextboxPlayer2Name.Left = m_TextboxPlayer1Name.Left;
            m_TextboxPlayer2Name.TextAlign = HorizontalAlignment.Left;
            m_TextboxPlayer2Name.Enabled = false;
            m_TextboxPlayer2Name.Text = "Computer";
        }

        private void initBoardSizeLabel()
        {
            m_BoardSize.Text = "Board Size:";
            m_BoardSize.Font = new Font(Label.DefaultFont, FontStyle.Bold);
            m_BoardSize.Left = m_Players.Left;
            m_BoardSize.Top = m_TextboxPlayer2Name.Top + 45;
        }

        private void initRowsLabel()
        {
            m_RowsLabel.Text = "Rows:";
            m_RowsLabel.Width = 45;
            m_RowsLabel.Left = m_Player2CheckBox.Left;
            m_RowsLabel.Top = m_BoardSize.Top + 30;
        }

        public int BoardSize
        {
            get { return (int)m_RowsNumericUpDown.Value; }
        }

        public string TextboxPlayer1Name
        {
            get { return m_TextboxPlayer1Name.Text.ToString(); }
        }

        public string TextboxPlayer2Name
        {
            get { return m_TextboxPlayer2Name.Text.ToString(); }
        }

        private void addControls()
        {
            this.Controls.Add(m_RowsLabel);
            this.Controls.Add(m_ButtonStart);
            this.Controls.Add(m_Players);
            this.Controls.Add(m_BoardSize);
            this.Controls.Add(m_Player1);
            this.Controls.Add(m_TextboxPlayer1Name);
            this.Controls.Add(m_Player2CheckBox);
            this.Controls.Add(m_TextboxPlayer2Name);
            this.Controls.Add(m_RowsNumericUpDown);
            this.Controls.Add(m_ColsLabel);
            this.Controls.Add(m_ColsNumericUpDown);
        }

        private void initRowsNumericUpDown()
        {
            m_RowsNumericUpDown.Minimum = 3;
            m_RowsNumericUpDown.Maximum = 9;
            m_RowsNumericUpDown.Left = m_RowsLabel.Right + 10;
            m_RowsNumericUpDown.Top = m_RowsLabel.Top;
            m_RowsNumericUpDown.Size = new Size(40, 26);
            this.m_RowsNumericUpDown.ValueChanged += new System.EventHandler(NumericUpDown_ValueChanged);
        }

        private void initColsNumericUpDown()
        {
            m_ColsNumericUpDown.Minimum = 3;
            m_ColsNumericUpDown.Maximum = 9;
            m_ColsNumericUpDown.Left = m_ColsLabel.Right + 10;
            m_ColsNumericUpDown.Top = m_ColsLabel.Top;
            m_ColsNumericUpDown.Size = new Size(40, 26);
            this.m_ColsNumericUpDown.ValueChanged += new System.EventHandler(NumericUpDown_ValueChanged);
        }

        private void initColsLabel()
        {
            m_ColsLabel.Text = "Cols:";
            m_ColsLabel.Width = 45;
            m_ColsLabel.Left = m_RowsNumericUpDown.Right + 20;
            m_ColsLabel.Top = m_RowsNumericUpDown.Top;
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            bool isTwoPlayersGame = m_Player2CheckBox.Checked; ////if the checkBox is checked so its a two players game.
            string string1 = this.m_TextboxPlayer1Name.Text; ////saving Player1Name.
            string string2 = this.m_TextboxPlayer2Name.Text; ////saving Player2Name.
            this.Close();

            Thread myThread = new Thread((ThreadStart)delegate { Application.Run(new TicTacToeMisere((int)this.m_RowsNumericUpDown.Value, string1, string2, isTwoPlayersGame)); });
            ////Initialize a new Thread of name myThread to call Application.Run() on a new instance of ViewSecond                                                                                                                                                                          //myThread.TrySetApartmentState(ApartmentState.STA); //If you receive errors, comment this out; use this when doing interop with STA COM objects.
            myThread.Start(); ////Start the thread; Run the form\
        }

        private void TextboxPlayer2Name_CheckedChanged(object sender, EventArgs e)
        {
            if (m_Player2CheckBox.Checked)
            {
                m_TextboxPlayer2Name.Enabled = true;
                m_TextboxPlayer2Name.Text = string.Empty;
            }
            else
            {
                m_TextboxPlayer2Name.Enabled = false;
                m_TextboxPlayer2Name.Text = "Computer";
            }
        }
        // $G$ CSS-013 (-5) Bad input variable name (should be in the form of i_PascalCased)
        // $G$ CSS-011 (-3) Bad private method name. Should be pascalCased.
        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            m_ColsNumericUpDown.Value = (sender as NumericUpDown).Value;
            m_RowsNumericUpDown.Value = (sender as NumericUpDown).Value;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            m_TextboxPlayer1Name.Text = (sender as TextBox).Text;
        }
    }
}