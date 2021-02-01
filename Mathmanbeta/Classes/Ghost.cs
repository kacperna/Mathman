using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mathmanbeta
{
    /// <summary>
    /// Klasa odpowiedzialna za konfigurację i mechanikę duchów
    /// </summary>
    public class Ghost
    {
        private const int GhostAmount = 6;
        private readonly ImageList GhostImages = new ImageList();
        /// <summary>
        /// Tablica zawierająca obrazki duchów
        /// </summary>
        public PictureBox[] GhostImage = new PictureBox[GhostAmount];
        /// <summary>
        /// Timer w którego interwałach poruszająsię duchy 
        /// </summary>
        public Timer timer = new Timer();
        private int[] xCoordinate = new int[GhostAmount];
        private int[] yCoordinate = new int[GhostAmount];
        private readonly int[] xStart = new int[GhostAmount];
        private readonly int[] yStart = new int[GhostAmount];
        private int[] Direction = new int[GhostAmount];
        private readonly Random ran = new Random();


        /// <summary>
        /// Konstruktor - wczytywanie obrazków duchów,ustalenie ich wielkości oraz ustawienie Timera
        /// </summary>
        public Ghost()
        {
            GhostImages.Images.Add(Properties.Resources.Ghost_0_1);
            GhostImages.Images.Add(Properties.Resources.Ghost_0_2);
            GhostImages.Images.Add(Properties.Resources.Ghost_0_3);
            GhostImages.Images.Add(Properties.Resources.Ghost_0_4);

            GhostImages.Images.Add(Properties.Resources.Ghost_1_1);
            GhostImages.Images.Add(Properties.Resources.Ghost_1_2);
            GhostImages.Images.Add(Properties.Resources.Ghost_1_3);
            GhostImages.Images.Add(Properties.Resources.Ghost_1_4);

            GhostImages.Images.Add(Properties.Resources.Ghost_2_1);
            GhostImages.Images.Add(Properties.Resources.Ghost_2_2);
            GhostImages.Images.Add(Properties.Resources.Ghost_2_3);
            GhostImages.Images.Add(Properties.Resources.Ghost_2_4);

            GhostImages.Images.Add(Properties.Resources.Ghost_3_1);
            GhostImages.Images.Add(Properties.Resources.Ghost_3_2);
            GhostImages.Images.Add(Properties.Resources.Ghost_3_3);
            GhostImages.Images.Add(Properties.Resources.Ghost_3_4);

            GhostImages.Images.Add(Properties.Resources.Ghost_4_1);
            GhostImages.Images.Add(Properties.Resources.Ghost_4_2);
            GhostImages.Images.Add(Properties.Resources.Ghost_4_3);
            GhostImages.Images.Add(Properties.Resources.Ghost_4_4);

            GhostImages.Images.Add(Properties.Resources.Ghost_5_1);
            GhostImages.Images.Add(Properties.Resources.Ghost_5_2);
            GhostImages.Images.Add(Properties.Resources.Ghost_5_3);
            GhostImages.Images.Add(Properties.Resources.Ghost_5_4);


            GhostImages.ImageSize = new Size(27, 28);

            timer.Interval = 95;
            timer.Enabled = true;
            timer.Tick += new EventHandler(Timer_Tick);           

        }
        /// <summary>
        /// Tworzenie tablicy pól graficznych zawierających obrazki duchów
        /// </summary>
        /// <param name="formInstance">Komunikacja z formularzem wyświetlającym duchy</param>
        public void CreateGhostImage(Form formInstance)
        {
            // Create Ghost Image
            for (int x = 0; x < GhostAmount; x++)
            {
                GhostImage[x] = new PictureBox();
                GhostImage[x].Name = "GhostImage" + x.ToString();
                GhostImage[x].SizeMode = PictureBoxSizeMode.AutoSize;
                formInstance.Controls.Add(GhostImage[x]);
                GhostImage[x].BringToFront();
            }
            Set_Ghosts();
            ResetGhosts();
        }

        /// <summary>
        /// Metoda znajdująca pozycje początkowe duchów
        /// </summary>
        public void Set_Ghosts()
        {
            int Amount = -1;
            for (int y = 0; y < 30; y++)
            {
                for (int x = 0; x < 63; x++)
                {
                    if (Form1.gameboard.Matrix[y, x] == 15)
                    {
                        Amount++;
                        xStart[Amount] = x;
                        yStart[Amount] = y;
                    }
                }
            }
        }

        /// <summary>
        /// Metoda wczytująca obrazki duchów na pozycjach początkowych
        /// </summary>
        public void ResetGhosts()
        {
            for (int x = 0; x < GhostAmount; x++)
            {
                xCoordinate[x] = xStart[x];
                yCoordinate[x] = yStart[x];
                GhostImage[x].Location = new Point(xStart[x] * 16 - 3, yStart[x] * 16 + 43);
                GhostImage[x].Image = GhostImages.Images[x * 4];
                Direction[x] = 0; 
            }
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Keep moving the ghosts
            for (int x = 0; x < GhostAmount; x++)
            {                
                MoveGhosts(x);
            }
            CheckForPacman();
        }

        private void MoveGhosts(int x)
        {
            // Move the ghosts
            if (Direction[x] == 0)
            {
                if (ran.Next(0, 5) == 3) { Direction[x] = 1; }
            }
            else
            {
                bool CanMove = false;
                Other_Direction(Direction[x], x);

                while (!CanMove)
                {
                    CanMove = check_direction(Direction[x], x);
                    if (!CanMove) { Change_Direction(Direction[x], x); }

                }

                if (CanMove)
                {
                    switch (Direction[x])
                    {
                        case 1: GhostImage[x].Top -= 16; yCoordinate[x]--; break;
                        case 2: GhostImage[x].Left += 16; xCoordinate[x]++; break;
                        case 3: GhostImage[x].Top += 16; yCoordinate[x]++; break;
                        case 4: GhostImage[x].Left -= 16; xCoordinate[x]--; break;
                    }
                    GhostImage[x].Image = GhostImages.Images[x * 4 + (Direction[x] - 1)];
                    
                }
            }
        }

        private bool check_direction(int direction, int ghost)
        {
            // Check if ghost can move to space
            switch (direction)
            {
                case 1: return direction_ok(xCoordinate[ghost], yCoordinate[ghost] - 1, ghost);
                case 2: return direction_ok(xCoordinate[ghost] + 1, yCoordinate[ghost], ghost);
                case 3: return direction_ok(xCoordinate[ghost], yCoordinate[ghost] + 1, ghost);
                case 4: return direction_ok(xCoordinate[ghost] - 1, yCoordinate[ghost], ghost);
                default: return false;
            }
        }

        private bool direction_ok(int x, int y, int ghost)
        {
            // Check if board space can be used
            if (x < 0) { xCoordinate[ghost] = 63; GhostImage[ghost].Left = 1008; return true; }
            if (x > 63) { xCoordinate[ghost] = 0; GhostImage[ghost].Left = 0; return true; }
            if (Form1.gameboard.Matrix[y, x] < 4 || Form1.gameboard.Matrix[y, x] > 10) { return true; } else { return false; }
        }

        private void Change_Direction(int direction, int ghost)
        {
            // Change the direction of the ghost
            int which = ran.Next(0, 2);
            switch (direction)
            {
                case 1: case 3: if (which == 1) { Direction[ghost] = 2; } else { Direction[ghost] = 4; }; break;
                case 2: case 4: if (which == 1) { Direction[ghost] = 1; } else { Direction[ghost] = 3; }; break;
            }
        }

        private void Other_Direction(int direction, int ghost)
        {
            // Check to see if the ghost can move a different direction
            if (Form1.gameboard.Matrix[yCoordinate[ghost], xCoordinate[ghost]] < 4)
            {
                bool[] directions = new bool[5];
                int x = xCoordinate[ghost];
                int y = yCoordinate[ghost];
                switch (direction)
                {
                    case 1: case 3: directions[2] = direction_ok(x + 1, y, ghost); directions[4] = direction_ok(x - 1, y, ghost); break;
                    case 2: case 4: directions[1] = direction_ok(x, y - 1, ghost); directions[3] = direction_ok(x, y + 1, ghost); break;
                }
                int which = ran.Next(0, 5);
                if (directions[which] == true) 
                { 
                    Direction[ghost] = which; 
                }
            }
        }


        /// <summary>
        /// Metoda sprawdzająca kolizję duchów z graczem, każda kolizja to strata jednego życia
        /// </summary>
        public void CheckForPacman()
        {
            for (int x = 0; x < GhostAmount; x++)
            {
                if (xCoordinate[x] == Form1.pacman.xCoordinate && yCoordinate[x] == Form1.pacman.yCoordinate)
                {                  
                    Form1.game.LoseLife();                    
                }
            }
        }
    }
}
