using System;
using System.Drawing;
using System.Windows.Forms;

namespace SharpStacker
{
    public partial class SharpStacker : Form
    {
        public SharpStacker()
        {
            InitializeComponent();
        }

        private void move_image(object sender, EventArgs e)
        {
            Button direction = (Button)sender;

            switch (direction.Text)
            {
                case "Up":
                    break;
                case "Down":
                    break;
                case "Right":
                    break;
                case "Left":
                    break;
                default:
                    break;
            }
        }

        private void stack_image(object sender, EventArgs e)
        {

        }

        private void open_image(object sender, EventArgs e)
        {
            openImage = new OpenFileDialog();
            openImage.ShowDialog();
            Image stampa = Image.FromFile(openImage.FileName);
            imageBox.Image = stampa;
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
