using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mathmanbeta
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Obiekt klasy Gameboard
        /// </summary>
        public static GameBoard gameboard = new GameBoard();
        /// <summary>
        /// Obiekt klasy Game
        /// </summary>
        public static Game game = new Game();
        /// <summary>
        /// obiekt klasy Pacman
        /// </summary>
        public static Pacman pacman = new Pacman();
        /// <summary>
        /// obiekt klasy Ghost
        /// </summary>
        public static Ghost ghost = new Ghost();
        /// <summary>
        /// obiekt klasy Math
        /// </summary>
        public static Math math = new Math();

        /// <summary>
        /// Konstruktor - dodawanie początkowych zasobów gry
        /// </summary>
        
        public Form1()
        {
            InitializeComponent();
            CenterToScreen();
            gameboard.CreateBoardImage(this);
            game.CreatePlayerDetails(this);
            game.CreateLives(this);
            Tuple<int, int> PacmanStartCoordinates = gameboard.InitialiseBoardMatrix();
            ghost.CreateGhostImage(this);
            pacman.CreatePacmanImage(this, PacmanStartCoordinates.Item1, PacmanStartCoordinates.Item2);
            math.CreateMath(this);
        }
        public Game Game
        {
            get => default;
            set
            {
            }
        }
        public Ghost Ghost
        {
            get => default;
            set
            {
            }
        }

        public GameBoard GameBoard
        {
            get => default;
            set
            {
            }
        }

        public Math Math
        {
            get => default;
            set
            {
            }
        }

        public Pacman Pacman
        {
            get => default;
            set
            {
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            switch (e.KeyCode)
            {
                case Keys.Up: case Keys.W : pacman.nextDirection = 1; pacman.MovePacman(1); break;
                case Keys.Right: case Keys.D: pacman.nextDirection = 2; pacman.MovePacman(2); break;
                case Keys.Down: case Keys.S: pacman.nextDirection = 3; pacman.MovePacman(3); break;
                case Keys.Left: case Keys.A: pacman.nextDirection = 4; pacman.MovePacman(4); break;
            }
        }
        

        
    }
}
