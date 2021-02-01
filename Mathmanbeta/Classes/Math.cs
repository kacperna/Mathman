using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mathmanbeta
{
    /// <summary>
    /// Klasa odpowiedzialna za tworzenie działań i wyników, a także stopniownie trudności
    /// </summary>
    public class Math
    {
        /// <summary>
        /// Tablica etykiet zawierających wyniki
        /// </summary>
        public Label[] Result = new Label[4];
        /// <summary>
        /// Etykieta zawierająca działanie do wykonania
        /// </summary>
        public Label Equation = new Label();
        Random rand = new Random();
        private const int LabelsAmount = 4;
        private int[] xCoordinate = new int[LabelsAmount];
        private int[] yCoordinate = new int[LabelsAmount];
        private int x,y,z;     
        private int w,o,p,r;
        private int[] result_array = new int[LabelsAmount];
        private int operation;
        /// <summary>
        /// Działanie
        /// </summary>
        public string eq;
        private Timer timer = new Timer();

        /// <summary>
        /// Konstruktor - ustawia Timer
        /// </summary>
        public Math()
        {
            timer.Interval = 5;
            timer.Enabled = true;
            timer.Tick += new EventHandler(Timer_Tick);
        }
        /// <summary>
        /// Metoda tworząca działania do rozwiązania, oraz stopniująca poziom trudności gry poprzez zwiększanie trudności działań oraz prędkości poruszania się duchów.
        /// </summary>
        public void CreateEquation()
        {

            operation = rand.Next(0, 4);
            if (Form1.game.Level<3)
            {
                x = rand.Next(1,6);
                y = rand.Next(1,6);
                z = rand.Next(1,6);
                Form1.ghost.timer.Interval = 90;
            }
            if (Form1.game.Level >= 3 && Form1.game.Level < 5)
            {
                x = rand.Next(5,11);
                y = rand.Next(5,11);
                z = rand.Next(1,6);
                Form1.ghost.timer.Interval = 85;
            }
            if (Form1.game.Level >= 5)
            {
                x = rand.Next(5, 11);
                y = rand.Next(5, 11);
                z = rand.Next(5, 11);
                Form1.ghost.timer.Interval = 80;
            }
            if (Form1.game.Level >= 7)
            {
                x = rand.Next(5, 16);
                y = rand.Next(5, 16);
                z = rand.Next(5, 11);
                Form1.ghost.timer.Interval = 75;
            }


            switch (operation)
            {
                case 0: w = x + y * z; o = (x + y) * z; p = x + y * (z - 1); r = x + y * (z + 1); ;  break;
                case 1: w = (x + y) * z; o = x + y * z; p = (x + y) * (z - 1); r = (x + y) * (z + 1); break;
                case 2: w = x - y * z; o = (x - y) * z; p = x - y * (z - 1); r = x - y * (z + 1); break;
                case 3: w = (x - y) * z; o = x - y * z; p = (x - y) * (z - 1); r = (x - y) * (z + 1); break;
            }
            switch (operation)
            {
                case 0: eq = x+" + "+y+" * "+z; break;
                case 1: eq = "("+x + " + " + y+")" + " * " + z; break;
                case 2: eq = x + " - " + y + " * " + z; break;
                case 3: eq = "(" + x + " - " + y + ")" + " * " + z; break;
            }
            result_array = new int[]{ w, o, p, r};
            
            Equation.Text = eq.ToString();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {        
            CheckForPacman();
        }

        /// <summary>
        /// Metoda losująca rozmieszczenie wyników na planszy oraz zapisująca ich współrzędne.
        /// </summary>
        public void CreateLabels()
        {
            int Amount = 0;
            int random;
            random = rand.Next(0, 4);

            for (int y = 0; y < 30; y++)
            {
                for (int x = 0; x < 63; x++)
                {
                    if (Form1.gameboard.Matrix[y, x] == 2)
                    {

                        if (random - Amount >= 0)
                        {
                            Result[Amount].Text = result_array[random - Amount].ToString();
                            xCoordinate[random - Amount] = x;
                            yCoordinate[random - Amount] = y;
                        }
                        else
                        {
                            Result[Amount].Text = result_array[Amount].ToString();
                            xCoordinate[Amount] = x;
                            yCoordinate[Amount] = y;
                        }                     
                        Amount++;                        
                    }                   
                }
            }
        }
        /// <summary>
        /// Metoda wyświetlająca działania i wyniki
        /// </summary>
        /// <param name="formInstance">Komunikacja z formularzem wyświetlającym działania oraz wyniki</param>
        public void CreateMath(Form formInstance)
        {

            CreateEquation();
            Equation.ForeColor = Color.White;
            Equation.Font = new Font("Folio XBd BT", 20);
            Equation.AutoSize = true;
            Equation.Top = 10;
            Equation.Left = (1040 - Equation.Width) / 2;
            formInstance.Controls.Add(Equation);
            Equation.BringToFront();

            int Amount = 0;

            for (int y = 0; y < 30; y++)
            {
                for (int x = 0; x < 63; x++)
                {
                    if (Form1.gameboard.Matrix[y, x] == 2)
                    {

                        Result[Amount] = new Label();
                        Result[Amount].Name = "Result" + Amount.ToString();
                        Result[Amount].ForeColor = System.Drawing.Color.White;
                        Result[Amount].Font = new System.Drawing.Font("Folio XBd BT", 14);
                        Result[Amount].AutoSize = true;
                        Result[Amount].Location = new Point(x * 16 - 7, y * 16 + 47);
                        formInstance.Controls.Add(Result[Amount]);
                        Result[Amount].BringToFront();
                        Amount++;

                    }
                }
            }
            CreateLabels();
        }

        /// <summary>
        /// Metoda sprawdzająca kolizję gracza z wynikami
        /// Wynik dobry - 300 punktów oraz zwiększenie poziomu
        /// Wynik zły - strata życia
        /// </summary>
        public void CheckForPacman()
        {
            // Check to see if a Label is on the same block as Pacman
            for (int x = 0; x < LabelsAmount; x++)
            {
                if ( (xCoordinate[x]+1 == Form1.pacman.xCoordinate || xCoordinate[x] - 1 == Form1.pacman.xCoordinate) && yCoordinate[x] == Form1.pacman.yCoordinate)
                {
                    if (result_array[x] == w)
                    { 
                        Form1.game.UpdateScore(300);
                        Form1.game.ChangeLevel();
                        
                        CreateEquation();
                        CreateLabels();                     

                    }
                    else 
                    {
                        Form1.game.LoseLife();
                        Form1.pacman.Set_Pacman();
                    }
                }
            }
        }
    }
}
