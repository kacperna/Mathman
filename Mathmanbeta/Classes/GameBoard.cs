﻿using System;
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
    /// Klasa odpowiedzialna za konfigurcje i macierzowy opis planszy gry
    /// </summary>
    public class GameBoard
    {
        /// <summary>
        /// Picture box zawierający planszę gry
        /// </summary>
        public PictureBox BoardImage = new PictureBox();
        /// <summary>
        /// Tablica dwuwymiarowa zawierająca macierz opisującą planszę gry
        /// </summary>
        public int[,] Matrix = new int[30,63];
        /// <summary>
        /// Wczytanie i konfiguracja pola graficznego gry
        /// </summary>
        /// <param name="formInstance">Komunikacja z formularzem wyświetlającym planszę gry</param>
        public void CreateBoardImage(Form formInstance)
        {
            // Create Board Image
            BoardImage.Name = "BoardImage";
            BoardImage.SizeMode = PictureBoxSizeMode.AutoSize;
            BoardImage.Location = new Point(0, 50);
            BoardImage.Image = Properties.Resources.Board01;             
            formInstance.Controls.Add(BoardImage);
        }
        /// <summary>
        /// Inicjalizacja macierzy opisującej planszę gry
        /// 01 - możliwe przejście dla duchów i pacmana
        /// 10 - ściana przejście zablokowane
        /// 02 - miejsca pojawienia się wyników
        /// 03 - miejsce startowe avatara
        /// 04 - możliwe przejście dla pacmana, nie dla duchów
        /// 11 - możliwe przejście dla duchów, nie dla pacmana
        /// 15 - miejsce startowe duchów
        /// </summary>
        /// <returns>Zwraca 2-krotkę zawierającą miejsce startowe pacmana</returns>
        public Tuple<int,int> InitialiseBoardMatrix()
        {
                    Matrix = new int[,] {
                        { 10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10, 10,10,10,10,10,10,10,10,10,10,10,10,10,10,10, 10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10, 10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10 },
                        { 10,01,01,01,01,01,01,01,01,01,01,01,01,01,10,10, 01,01,01,01,01,01,01,01,01,01,01,01,01,01,01, 10,10,01,01,01,01,01,01,01,01,01,01,01,01,01,01, 10,10,01,01,01,01,01,01,01,01,01,01,01,01,01,01,10 },                       
                        { 10,01,10,10,10,10,10,01,10,10,10,10,10,01,10,10, 01,10,10,10,10,10,10,01,10,10,10,10,10,10,01, 10,10,01,10,10,10,10,10,10,01,10,10,10,10,10,01, 10,10,01,10,10,10,10,10,10,01,10,10,10,10,10,01,10 },
                        { 10,01,10,10,10,10,10,01,10,10,10,10,10,01,10,10, 01,10,10,10,10,10,10,01,10,10,10,10,10,10,01, 10,10,01,10,10,10,10,10,10,01,10,10,10,10,10,01, 10,10,01,10,10,10,10,10,10,01,10,10,10,10,10,01,10 },
                        { 10,01,10,10,10,10,10,01,10,10,10,10,10,01,10,10, 01,10,10,10,10,10,10,01,10,10,10,10,10,10,01, 10,10,01,10,10,10,10,10,10,01,10,10,10,10,10,01, 10,10,01,10,10,10,10,10,10,01,10,10,10,10,10,01,10 },
                        { 10,01,04,01,02,01,04,01,01,01,01,01,01,01,10,10, 01,01,01,01,01,01,01,01,01,01,01,01,01,01,01, 01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01, 10,10,01,01,01,01,01,01,01,01,04,01,02,01,04,01,10 },
                        { 10,01,10,10,10,10,10,01,10,10,10,10,10,01,10,10, 01,10,10,10,10,10,10,01,10,10,01,10,10,10,10, 10,10,10,10,10,01,10,10,10,01,10,10,10,10,10,01, 10,10,01,10,10,10,10,10,10,01,10,10,10,10,10,01,10 },
                        { 10,01,10,10,10,10,10,01,10,10,10,10,10,01,10,10, 01,10,10,10,10,10,10,01,10,10,01,10,10,10,10, 10,10,10,10,10,01,10,10,10,01,10,10,10,10,10,01, 10,10,01,10,10,10,10,10,10,01,10,10,10,10,10,01,10 },
                        { 10,01,01,01,01,01,01,01,01,01,01,01,01,01,15,01, 01,01,01,01,01,01,01,01,10,10,01,01,01,01,01, 10,10,01,01,01,01,10,10,10,01,01,01,01,01,01,01, 15,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,10 },                       
                        { 10,10,10,10,10,10,10,01,10,10,10,10,10,01,10,10, 01,10,10,10,10,10,10,01,10,10,10,10,10,10,01, 10,10,01,10,10,10,10,10,10,01,10,10,10,10,10,01, 10,10,01,10,10,10,10,10,10,01,10,10,10,10,10,10,10 },
                        { 10,10,10,10,10,10,10,01,10,10,10,10,10,01,10,10, 01,10,10,10,10,10,10,01,10,10,10,10,10,10,01, 10,10,01,10,10,10,10,10,10,01,10,10,10,10,10,01, 10,10,01,10,10,10,10,10,10,01,10,10,10,10,10,10,10 },
                        { 10,10,10,10,10,10,10,01,01,01,01,01,01,01,10,10, 01,01,01,01,01,01,01,01,10,10,01,01,01,01,01, 01,01,01,01,01,01,10,10,10,01,01,01,01,01,01,01, 10,10,01,01,01,01,01,01,01,01,10,10,10,10,10,10,10 },
                        { 10,10,10,10,10,10,10,01,10,10,01,10,10,10,10,10, 10,10,10,10,01,10,10,01,10,10,01,10,10,10,11, 11,10,10,10,10,01,10,10,10,01,10,10,01,10,10,10, 10,10,10,10,10,10,01,10,10,01,10,10,10,10,10,10,10 },
                        { 10,10,10,10,10,10,10,01,10,10,01,10,10,10,10,10, 10,10,10,10,01,10,10,01,10,10,01,10,10,10,15, 15,10,10,10,10,01,10,10,10,01,10,10,01,10,10,10, 10,10,10,10,10,10,01,10,10,01,10,10,10,10,10,10,10 },
                        { 01,01,01,01,01,01,01,01,10,10,01,01,01,01,10,10, 01,01,01,01,01,10,10,01,01,01,01,10,10,10,10, 10,10,10,10,10,01,01,01,01,01,10,10,01,01,01,01, 10,10,01,01,01,01,01,10,10,01,01,01,01,01,01,01,01 },                      
                        { 10,10,10,10,10,10,10,01,10,10,10,10,10,01,10,10, 01,10,10,10,10,10,10,01,10,10,01,10,10,10,10, 10,10,10,10,10,01,10,10,10,01,10,10,10,10,10,01, 10,10,01,10,10,10,10,10,10,01,10,10,10,10,10,10,10 },
                        { 10,10,10,10,10,10,10,01,10,10,10,10,10,01,10,10, 01,10,10,10,10,10,10,01,10,10,01,10,10,10,10, 10,10,10,10,10,01,10,10,10,01,10,10,10,10,10,01, 10,10,01,10,10,10,10,10,10,01,10,10,10,10,10,10,10 },
                        { 10,10,10,10,10,10,10,01,10,10,01,01,01,01,01,01, 01,01,01,01,01,10,10,01,10,10,01,01,01,01,01, 03,01,01,01,01,01,10,10,10,01,10,10,01,01,01,01, 01,01,01,01,01,01,01,10,10,01,10,10,10,10,10,10,10 },
                        { 10,10,10,10,10,10,10,01,10,10,01,10,10,10,10,10, 10,10,10,10,01,10,10,01,10,10,01,10,10,10,10, 10,10,10,10,10,01,10,10,10,01,10,10,01,10,10,10, 10,10,10,10,10,10,01,10,10,01,10,10,10,10,10,10,10 },
                        { 10,10,10,10,10,10,10,01,10,10,01,10,10,10,10,10, 10,10,10,10,01,10,10,01,10,10,01,10,10,10,10, 10,10,10,10,10,01,10,10,10,01,10,10,01,10,10,10, 10,10,10,10,10,10,01,10,10,01,10,10,10,10,10,10,10 },
                        { 10,01,01,01,01,01,01,01,01,01,01,01,01,01,10,10, 01,01,01,01,01,01,01,01,01,01,01,01,01,01,01, 10,10,01,01,01,01,01,01,01,01,01,01,01,01,01,01, 10,10,01,01,01,01,01,01,01,01,01,01,01,01,01,01,10 },
                        { 10,01,10,10,10,10,10,01,10,10,10,10,10,01,10,10, 01,10,10,10,10,10,10,01,10,10,10,10,10,10,01, 10,10,01,10,10,10,10,10,10,01,10,10,10,10,10,01, 10,10,01,10,10,10,10,10,10,01,10,10,10,10,10,04,10 },
                        { 10,01,10,10,10,10,10,01,10,10,10,10,10,01,10,10, 01,10,10,10,10,10,10,01,10,10,10,10,10,10,01, 10,10,01,10,10,10,10,10,10,01,10,10,10,10,10,01, 10,10,01,10,10,10,10,10,10,01,10,10,10,10,10,01,10 },
                        { 10,01,01,01,01,10,10,01,01,01,01,01,01,01,15,01, 01,01,01,01,01,01,01,01,01,01,01,01,01,01,01, 01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01, 15,01,01,01,01,01,01,01,01,01,10,10,10,01,02,01,10 },
                        { 10,10,10,10,01,10,10,01,10,10,01,10,10,10,10,10, 10,10,10,10,01,10,10,01,10,10,01,10,10,10,10, 10,10,10,10,10,01,10,10,10,01,10,10,01,10,10,10, 10,10,10,10,10,10,01,10,10,01,10,10,10,01,10,10,10 },
                        { 10,10,10,10,01,10,10,01,10,10,01,10,10,10,10,10, 10,10,10,10,01,10,10,01,10,10,01,10,10,10,10, 10,10,10,10,10,01,10,10,10,01,10,10,01,10,10,10, 10,10,10,10,10,10,01,10,10,01,10,10,10,04,10,10,10 },
                        { 10,01,01,01,01,01,01,01,10,10,01,01,01,01,10,10, 01,02,01,04,01,01,01,01,10,10,01,01,01,01,01, 10,10,01,01,01,01,10,10,10,01,01,01,01,01,01,01, 10,10,01,01,01,01,01,10,10,01,01,01,01,01,01,01,10 },
                        { 10,01,10,10,10,10,10,10,10,10,10,10,10,01,10,10, 01,10,10,10,10,10,10,10,10,10,10,10,10,10,01, 10,10,01,10,10,10,10,10,10,10,10,10,10,10,10,01, 10,10,01,10,10,10,10,10,10,10,10,10,10,10,10,01,10 },
                        { 10,01,10,10,10,10,10,10,10,10,10,10,10,01,10,10, 04,10,10,10,10,10,10,10,10,10,10,10,10,10,01, 10,10,01,10,10,10,10,10,10,10,10,10,10,10,10,01, 10,10,01,10,10,10,10,10,10,10,10,10,10,10,10,01,10 },
                        { 10,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01, 01,01,01,01,01,01,01,01,01,01,01,01,01,01,01, 01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01, 01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,10 },
                        { 10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10, 10,10,10,10,10,10,10,10,10,10,10,10,10,10,10, 10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10, 10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10 } };
                    
            
            int StartX = 0;
            int StartY = 0;
            for (int y=0; y<30; y++)
            {
                for (int x=0; x<63; x++)
                {
                    if (Matrix[y, x] == 3) { StartX = x; StartY = y;}
                }
            }
            Tuple<int,int> StartLocation = new Tuple<int,int> (StartX, StartY);
            return StartLocation;
        }
    }
}
