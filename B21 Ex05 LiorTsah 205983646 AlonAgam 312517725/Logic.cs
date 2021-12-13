namespace B21_Ex05_Lior_205983646_Alon_312517725
{
    using System;

    public class Logic
    {
        private const string k_StringX = "X";
        private const string k_StringO = "O";
        private readonly Random r_Random = new Random();
        private Computer m_Comp;
        private Player m_Player1;
        private Player m_Player2;
        private Board m_Board = new Board();
        private bool m_AgainstComputer;
        private bool m_NewGame = true;
        private int m_Moves = 0;
        private int m_Opponent;
        private int m_Score1 = 0;
        private int m_Score2 = 0;
        private bool m_ThereIsAwinner = false;

        public string GiveRandomSign()
        {
            int randomInt = r_Random.Next();

            return randomInt % 2 == 0 ? k_StringX : k_StringO;
        }

        public bool ThereIsAWinner
        {
            get => m_ThereIsAwinner;

            set => m_ThereIsAwinner = value;
        }

        public int Score1
        {
            get => m_Score1;

            set => m_Score1 = value;
        }

        public int Score2
        {
            get => m_Score2;

            set => m_Score2 = value;
        }

        public Player Player1
        {
            get => m_Player1;

            set => m_Player1 = value;
        }

        public Player Player2
        {
            get => m_Player2;

            set => m_Player2 = value;
        }

        public Computer Comp
        {
            get => m_Comp;

            set => m_Comp = value;
        }

        public Board TheBoard
        {
            get => m_Board;

            set => m_Board = value;
        }

        public bool AgainstComputer
        {
            get => m_AgainstComputer;

            set => m_AgainstComputer = value;
        }

        public bool NewGame
        {
            get => m_NewGame;

            set => m_NewGame = value;
        }

        public int Moves
        {
            get => m_Moves;

            set => m_Moves = value;
        }

        public int Opponent
        {
            get => m_Opponent;

            set => m_Opponent = value;
        }

        public class Computer
        {
            private readonly Random r_Random = new Random();
            private string m_Sign;

            public string Sign
            {
                get => m_Sign;

                set => m_Sign = value;
            }

            public void MakeMove(Board i_Board, int i_SizeOfBoard, out int o_Row, out int o_Column)
            {
                int numberOfRow;
                int numberOfColumn;

                do
                {
                    numberOfRow = r_Random.Next(0, i_SizeOfBoard);
                    numberOfColumn = r_Random.Next(0, i_SizeOfBoard);
                    if (i_Board.BoardArray[numberOfRow, numberOfColumn] == "   ")
                    {
                        break;
                    }
                }
                while (true);

                i_Board.BoardArray[numberOfRow, numberOfColumn] = this.Sign;
                o_Row = numberOfRow;
                o_Column = numberOfColumn;
            }
        }

        public class Board
        {
            private int m_Size;
            private string[,] m_Board;

            public string[,] BoardArray
            {
                get => m_Board;

                set => m_Board = value;
            }

            public int Size
            {
                get => m_Size;

                set => m_Size = value;
            }

            public void InitBoard(int i_SizeOfBoard)
            {
                m_Size = i_SizeOfBoard;
                m_Board = new string[i_SizeOfBoard, i_SizeOfBoard];

                for (int i = 0; i < i_SizeOfBoard; i++)
                {
                    for (int j = 0; j < i_SizeOfBoard; j++)
                    {
                        m_Board[i, j] = "   ";
                    }
                }
            }

            public void ClearBoard(int i_SizeOfBoard)
            {
                for (int i = 0; i < i_SizeOfBoard; i++)
                {
                    for (int j = 0; j < i_SizeOfBoard; j++)
                    {
                        m_Board[i, j] = "   ";
                    }
                }
            }

            public bool CheckRows(string i_Sign)
            {
                bool thereIsAWinner = false;

                for (int i = 0; i < m_Size; i++)
                {
                    if (m_Board[i, 0] == i_Sign)
                    {
                        for (int j = 0; j < m_Size - 1; j++)
                        {
                            if (m_Board[i, j] == m_Board[i, j + 1])
                            {
                                if (j == m_Size - 2)
                                {
                                    thereIsAWinner = true;
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    if (thereIsAWinner)
                    {
                        break;
                    }
                }

                return thereIsAWinner;
            }

            public bool CheckMainDiagonal(string i_Sign)
            {
                bool thereIsAWinner = false;

                if (m_Board[0, 0] == i_Sign)
                {
                    for (int i = 0; i < m_Size - 1; i++)
                    {
                        if (m_Board[i, i] == m_Board[i + 1, i + 1])
                        {
                            if (i == m_Size - 2)
                            {
                                thereIsAWinner = true;
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                return thereIsAWinner;
            }

            public bool CheckSecondaryDiagonal(string i_Sign)
            {
                bool thereIsAWinner = false;

                if (m_Board[0, m_Size - 1] == i_Sign)
                {
                    for (int i = 0, j = m_Size - 1; i < m_Size - 1; i++, j--)
                    {
                        if (m_Board[i, j] == m_Board[i + 1, j - 1])
                        {
                            if (i == m_Size - 2)
                            {
                                thereIsAWinner = true;
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                return thereIsAWinner;
            }

            public bool CheckDiagonals(string i_Sign)
            {
                bool thereIsAWinner = CheckMainDiagonal(i_Sign);
                if (!thereIsAWinner)
                {
                    thereIsAWinner = CheckSecondaryDiagonal(i_Sign);
                }

                return thereIsAWinner;
            }

            public bool CheckColumns(string i_Sign)
            {
                bool thereIsAWinner = false;

                for (int i = 0; i < m_Size; i++)
                {
                    if (m_Board[0, i] == i_Sign)
                    {
                        for (int j = 0; j < m_Size - 1; j++)
                        {
                            if (m_Board[j, i] == m_Board[j + 1, i])
                            {
                                if (j == m_Size - 2)
                                {
                                    thereIsAWinner = true;
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (thereIsAWinner)
                        {
                            break;
                        }
                    }
                }

                return thereIsAWinner;
            }

            public bool CheckForWin(string i_Sign)
            {
                bool thereIsAWinner = CheckRows(i_Sign);

                if (!thereIsAWinner)
                {
                    thereIsAWinner = CheckDiagonals(i_Sign);
                    if (!thereIsAWinner)
                    {
                        thereIsAWinner = CheckColumns(i_Sign);
                    }
                }

                return thereIsAWinner;
            }
        }

        public class Player
        {
            private string m_Sign;

            public string Sign
            {
                get => m_Sign;

                set => m_Sign = value;
            }

            public void ChooseSquare(Logic.Board i_Board, int i_row, int i_col)
            {
                i_Board.BoardArray[i_row, i_col] = this.Sign;
            }
        }

        public void InitialPlayerAndComputer()
        {
            m_Comp = new Computer();
            m_Player1 = new Player { Sign = GiveRandomSign() };
            m_Comp.Sign = m_Player1.Sign == k_StringX ? k_StringO: k_StringX;
            m_NewGame = false;
        }

        public void InitialPlayers()
        {
            Player1 = new Player { Sign = GiveRandomSign() };
            Player2 = new Player
            {
                Sign = Player1.Sign == k_StringX ? k_StringO : k_StringX
            };
            this.m_NewGame = false;
        }

        public void StartGame(int i_SizeOfBoard, bool i_IsTwoPlayersGame)
        {
            m_Moves = 0;

            if (m_NewGame)
            {
                m_Board.InitBoard(i_SizeOfBoard);
                if (!i_IsTwoPlayersGame)
                {
                    InitialPlayerAndComputer();
                }
                else
                {
                    InitialPlayers();
                }
            }
            else
            {
                m_Board.ClearBoard(i_SizeOfBoard);
            }
        }
    }
}