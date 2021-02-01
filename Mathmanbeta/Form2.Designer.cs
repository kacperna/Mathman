
namespace Mathmanbeta
{
    /// <summary>
    /// Menu
    /// </summary>
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.Logo = new System.Windows.Forms.PictureBox();
            this.Playnow = new System.Windows.Forms.PictureBox();
            this.Help = new System.Windows.Forms.PictureBox();
            this.Exit = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Playnow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Help)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).BeginInit();
            this.SuspendLayout();
            // 
            // Logo
            // 
            this.Logo.Image = ((System.Drawing.Image)(resources.GetObject("Logo.Image")));
            this.Logo.Location = new System.Drawing.Point(130, 12);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(779, 159);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Logo.TabIndex = 0;
            this.Logo.TabStop = false;
            // 
            // Playnow
            // 
            this.Playnow.Image = ((System.Drawing.Image)(resources.GetObject("Playnow.Image")));
            this.Playnow.Location = new System.Drawing.Point(359, 200);
            this.Playnow.Name = "Playnow";
            this.Playnow.Size = new System.Drawing.Size(322, 96);
            this.Playnow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Playnow.TabIndex = 1;
            this.Playnow.TabStop = false;
            this.Playnow.Click += new System.EventHandler(this.Playnow_Click);
            this.Playnow.MouseLeave += new System.EventHandler(this.Playnow_MouseLeave);
            this.Playnow.MouseHover += new System.EventHandler(this.Playnow_MouseHover);
            // 
            // Help
            // 
            this.Help.Image = ((System.Drawing.Image)(resources.GetObject("Help.Image")));
            this.Help.Location = new System.Drawing.Point(359, 302);
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(322, 96);
            this.Help.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Help.TabIndex = 2;
            this.Help.TabStop = false;
            this.Help.Click += new System.EventHandler(this.Help_Click);
            this.Help.MouseLeave += new System.EventHandler(this.Help_MouseLeave);
            this.Help.MouseHover += new System.EventHandler(this.Help_MouseHover);
            // 
            // Exit
            // 
            this.Exit.Image = ((System.Drawing.Image)(resources.GetObject("Exit.Image")));
            this.Exit.Location = new System.Drawing.Point(359, 404);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(322, 96);
            this.Exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Exit.TabIndex = 3;
            this.Exit.TabStop = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            this.Exit.MouseLeave += new System.EventHandler(this.Exit_MouseLeave);
            this.Exit.MouseHover += new System.EventHandler(this.Exit_MouseHover);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1024, 581);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Help);
            this.Controls.Add(this.Playnow);
            this.Controls.Add(this.Logo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Mathman";
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Playnow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Help)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.PictureBox Playnow;
        private System.Windows.Forms.PictureBox Help;
        private System.Windows.Forms.PictureBox Exit;
    }
}