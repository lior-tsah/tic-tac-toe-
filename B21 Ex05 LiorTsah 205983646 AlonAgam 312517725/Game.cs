using System.Windows.Forms;

namespace B21_Ex05_Lior_205983646_Alon_312517725
{
    public class Game
    {
        private readonly GameSettings m_GameSettings;
        public static Button[,] m_ButtonsArray;

        public Game()
        {
            m_GameSettings = new GameSettings();
            Application.Run(m_GameSettings);
        }
    }
}