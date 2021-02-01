using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mathmanbeta
{
    /// <summary>
    /// Okno Help
    /// </summary>
    public partial class Form3 : Form
    {
        /// <summary>
        /// Konstruktor okna Help
        /// </summary>
        public Form3()
        {
            InitializeComponent();
            CenterToScreen();
        }
        private void Menu_MouseHover(object sender, EventArgs e)
        {
            Menu.Image = Properties.Resources.Menu_green;
        }
        private void Menu_MouseLeave(object sender, EventArgs e)
        {
            Menu.Image = Properties.Resources.Menu_red;
        }
        private void Menu_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new Form2();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }


    }
}
