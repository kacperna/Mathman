using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Windows;
using System.Diagnostics;
using System.IO;

namespace Mathmanbeta
{
    /// <summary>
    /// Klasa odpowiedzialna za stan gry, zliczająca poziom, wynik oraz liczbę pozostałych żyć
    /// </summary>
    public class Game
    {
        private const int MaxLives = 4;
        /// <summary>
        /// Wynik
        /// </summary>
        public int Score;
        /// <summary>
        /// Najlepszy wynik
        /// </summary>
        public int Highscore;
        /// <summary>
        /// Liczba żyć
        /// </summary>
        public int Lives;
        /// <summary>
        /// Etykieta zawierająca wynik
        /// </summary>
        public Label ScoreText = new Label();
        /// <summary>
        /// Etykieta zawierająca najlepszy wynik
        /// </summary>
        public Label HighScore = new Label();
        /// <summary>
        /// tablica z obrazkami dostępnych żyć
        /// </summary>
        public PictureBox[] LifeImage = new PictureBox[MaxLives];
        /// <summary>
        /// Numer poziomu
        /// </summary>
        public int Level;
        private string text;

        

        /// <summary>
        /// Metoda która ustawia grę w jej początkowej wersji oraz tworzy tablicę pól obrazów z życiami
        /// </summary>
        /// <param name="formInstance">Komunikacja z formularzem wyświetlającym liczbę żyć</param>
        public void CreateLives(Form formInstance)
        {
            Score = 0;
            Lives = 3;
            Level = 1;
            UpdateScore(0);
            for (int x = 0; x < MaxLives; x++)
            {
                LifeImage[x] = new PictureBox();
                LifeImage[x].Name = "Life" + x.ToString();
                LifeImage[x].SizeMode = PictureBoxSizeMode.AutoSize;
                LifeImage[x].Location = new Point(x * 30 + 3, 550);
                LifeImage[x].Image = Properties.Resources.Life;
                formInstance.Controls.Add(LifeImage[x]);
                LifeImage[x].BringToFront();
            }
            SetLives();
        }
        /// <summary>
        /// Metoda która zwiększa poziom i po każdej jego inkrementacji przywraca avatara i duchy do pozycji początkowej
        /// </summary>
        public void ChangeLevel()
        {
            Level += 1;
            Form1.pacman.Set_Pacman();
            Form1.ghost.ResetGhosts();

        }
        /// <summary>
        /// Metoda odpowiedzialna za stworzenie i konfigurację etykiety zawierającej wynik
        /// </summary>
        /// <param name="formInstance">Komunikacja z formularzem wyświetlającym wynik</param>
        public void CreatePlayerDetails(Form formInstance)
        {            
            ScoreText.ForeColor = System.Drawing.Color.White;
            ScoreText.Font = new System.Drawing.Font("Folio XBd BT", 14);
            ScoreText.Top = 23;
            ScoreText.Left = 30;
            ScoreText.AutoSize = true;
            formInstance.Controls.Add(ScoreText);
            ScoreText.BringToFront();
            UpdateScore(0);

            

            HighScore.ForeColor = System.Drawing.Color.White;
            HighScore.Font = new System.Drawing.Font("Folio XBd BT", 14);
            HighScore.Top = 23;
            HighScore.Left = 850;
            HighScore.AutoSize = true;
            formInstance.Controls.Add(HighScore);
            HighScore.BringToFront();
            if(!File.Exists("HighScore.txt"))
            {
                File.Create("HighScore.txt").Close();
                System.IO.File.WriteAllText("HighScore.txt", "0");
            }
            text = System.IO.File.ReadAllText("HighScore.txt");
            Int32.TryParse(text,out Highscore);
            HighScore.Text = "High Score: " + text;
        }
        /// <summary>
        /// Metoda odpowiedzialna za wyświetlanie i zliczanie zdobytego wyniku
        /// </summary>
        /// <param name="amount">Liczba zdobytych punktów</param>
        public void UpdateScore(int amount)
        {
            Score += amount;
            ScoreText.Text ="Score: "+ Score.ToString();
            if (Score > Highscore) 
            {
                HighScore.Text = "High Score: " + Score.ToString();
                System.IO.File.WriteAllText("HighScore.txt", Score.ToString());
            }
        }
        /// <summary>
        /// Metoda odpowiedzialna za wyświetlanie liczby żyć
        /// </summary>
        public void SetLives()
        {
            // Display lives in form
            for (int x = 0; x < Lives+1; x++)
            {
                LifeImage[x].Visible = true;
            }
            for (int x = Lives - 1; x < MaxLives; x++)
            {
                LifeImage[x].Visible = false;
            }
        }

        /// <summary>
        /// Metoda zmniejszająca liczbę żyć
        /// </summary>
        public void LoseLife()
        {
            
            Lives--;            
            if (Lives > 0)
            {
                Form1.pacman.Set_Pacman();
                Form1.ghost.ResetGhosts();
                SetLives();
            }
            else
            {
                try
                {
                    //run the program again and close this one
                    Process.Start(Application.StartupPath + "Mathmanbeta.exe");
                    //or you can use Application.ExecutablePath

                    //close this one
                    Process.GetCurrentProcess().Kill();
                }
                catch
                { } 
            }
        }

    }
}

