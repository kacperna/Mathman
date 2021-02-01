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
    /// <summary>
    /// Klasa odpowiedzialna za konfigurację i mechanikę Pacmana
    /// </summary>
    public class Pacman
    {
        /// <summary>
        /// Aktualna współrzędna x Pacmana
        /// </summary>
        public int xCoordinate = 0;
        /// <summary>
        /// Aktualna współrzędna y Pacmana
        /// </summary>
        public int yCoordinate = 0;
        private int xStart = 0;
        private int yStart = 0;
        /// <summary>
        /// Aktualny kierunek w którym porusza się Pacman
        /// </summary>
        public int currentDirection = 0;
        /// <summary>
        /// kolejny kierunek w którym będzie się poruszał Pacman
        /// </summary>
        public int nextDirection = 0;
        public PictureBox PacmanImage = new PictureBox();
        private ImageList PacmanImages = new ImageList();
        private Timer timer = new Timer();

        private int imageOn = 0;

        /// <summary>
        /// Konstruktor - wczytywanie obrazków Pacmana,ustalenie jego wielkości oraz ustawienie Timera
        /// </summary>
        public Pacman()
        {
            timer.Interval = 100;
            timer.Enabled = true;
            timer.Tick += new EventHandler(timer_Tick);

            PacmanImages.Images.Add(Properties.Resources.Pacman_1_0);
            PacmanImages.Images.Add(Properties.Resources.Pacman_1_1);
            PacmanImages.Images.Add(Properties.Resources.Pacman_1_2);
            PacmanImages.Images.Add(Properties.Resources.Pacman_1_3);

            PacmanImages.Images.Add(Properties.Resources.Pacman_2_0);
            PacmanImages.Images.Add(Properties.Resources.Pacman_2_1);
            PacmanImages.Images.Add(Properties.Resources.Pacman_2_2);
            PacmanImages.Images.Add(Properties.Resources.Pacman_2_3);

            PacmanImages.Images.Add(Properties.Resources.Pacman_3_0);
            PacmanImages.Images.Add(Properties.Resources.Pacman_3_1);
            PacmanImages.Images.Add(Properties.Resources.Pacman_3_2);
            PacmanImages.Images.Add(Properties.Resources.Pacman_3_3);

            PacmanImages.Images.Add(Properties.Resources.Pacman_4_0);
            PacmanImages.Images.Add(Properties.Resources.Pacman_4_1);
            PacmanImages.Images.Add(Properties.Resources.Pacman_4_2);
            PacmanImages.Images.Add(Properties.Resources.Pacman_4_3);

            PacmanImages.ImageSize = new Size(25, 26);
        }
        /// <summary>
        /// Metoda która tworzy i konfiguruje pole graficzne Pacmana
        /// </summary>
        /// <param name="formInstance">Komunikacja z formularzem wyświetlającym Pacmana</param>
        /// <param name="StartXCoordinate">Współrzędna początkowa x</param>
        /// <param name="StartYCoordinate">Współrzędna początkowa y</param>
        public void CreatePacmanImage(Form formInstance, int StartXCoordinate, int StartYCoordinate)
        {            
            xStart = StartXCoordinate;
            yStart = StartYCoordinate;
            PacmanImage.Name = "PacmanImage";
            PacmanImage.SizeMode = PictureBoxSizeMode.AutoSize;
            Set_Pacman();
            formInstance.Controls.Add(PacmanImage);
            PacmanImage.BringToFront();
        }
        /// <summary>
        /// Metoda odpowiedzialna za poruszanie się Pacmana
        /// </summary>
        /// <param name="direction">Kierunek w którym ma poruszać się Pacman</param>
        public void MovePacman(int direction)
        {
            // Move Pacman
            bool CanMove = Check_direction(nextDirection);
            if (!CanMove) 
            { 
                CanMove = Check_direction(currentDirection);
                direction = currentDirection; 
            } 
            else 
            { 
                direction = nextDirection; 
            }
            if (CanMove) 
            { 
                currentDirection = direction; 
            }

            if (CanMove)
            {
                switch (direction)
                {
                    case 1: PacmanImage.Top -= 16; yCoordinate--; break;
                    case 2: PacmanImage.Left += 16; xCoordinate++; break;
                    case 3: PacmanImage.Top += 16; yCoordinate++; break;
                    case 4: PacmanImage.Left -= 16; xCoordinate--; break;
                }
                currentDirection = direction;
                UpdatePacmanImage();              
                Form1.ghost.CheckForPacman();
            }
        }

        private void UpdatePacmanImage()
        {
            PacmanImage.Image = PacmanImages.Images[((currentDirection - 1) * 4) + imageOn];
            imageOn++;
            if (imageOn > 3) 
            { 
                imageOn = 0; 
            }
        }

        private bool Check_direction(int direction)
        {
            switch (direction)
            {
                case 1: return direction_ok(xCoordinate, yCoordinate - 1);
                case 2: return direction_ok(xCoordinate + 1, yCoordinate);
                case 3: return direction_ok(xCoordinate, yCoordinate + 1);
                case 4: return direction_ok(xCoordinate - 1, yCoordinate);
                default: return false;
            }
        }

        private bool direction_ok(int x, int y)
        {
            if (x < 0) { xCoordinate = 63; PacmanImage.Left = 1008; return true; }
            if (x > 63) { xCoordinate = 0; PacmanImage.Left = 0; return true; }
            if (Form1.gameboard.Matrix[y, x] < 5 || Form1.gameboard.Matrix[y, x] == 15) 
            { 
                return true; 
            } 
            else 
            { 
                return false; 
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            MovePacman(currentDirection);
        }
        /// <summary>
        /// Metoda ustawiająca Pacmana w pozycji startowej
        /// </summary>
        public void Set_Pacman()
        {
            PacmanImage.Image = Properties.Resources.Pacman_2_1;
            currentDirection = 0;
            nextDirection = 0;
            xCoordinate = xStart;
            yCoordinate = yStart;
            PacmanImage.Location = new Point(xStart * 16 - 3, yStart * 16 + 43);
        }
    }
}