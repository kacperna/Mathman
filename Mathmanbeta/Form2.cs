using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mathmanbeta
{
    public partial class Form2 : Form
    {
        private List<Form> openForms = new List<Form>();
        /// <summary>
        /// Konstruktor - inicjalizuje menu gry
        /// </summary>

        public Form2()
        {
            InitializeComponent();
            CenterToScreen();
            BringToFront();

        }

        private void Playnow_MouseHover(object sender, EventArgs e)
        {
            Playnow.Image = Properties.Resources.Playnow_green;
            /*foreach (Form f in Application.OpenForms)
            {
                openForms.Add(f);
            }
            foreach (Form f in openForms)
            {
                if (f.Name == "Form1")
                    f.Close();
            }*/
        }
        private void Playnow_MouseLeave(object sender, EventArgs e)
        {
            Playnow.Image = Properties.Resources.Playnow_red;
        }
        private void Help_MouseHover(object sender, EventArgs e)
        {
            Help.Image = Properties.Resources.Help_green;
        }
        private void Help_MouseLeave(object sender, EventArgs e)
        {
            Help.Image = Properties.Resources.HELP_red;
        }
        private void Exit_MouseHover(object sender, EventArgs e)
        {
            Exit.Image = Properties.Resources.Exit_green;
        }
        private void Exit_MouseLeave(object sender, EventArgs e)
        {
            Exit.Image = Properties.Resources.EXIT_red;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Playnow_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new Form1();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }

        private void Help_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new Form3();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }
    }
}
