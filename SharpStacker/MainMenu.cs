using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace SharpStacker
{
    public partial class SharpStacker : Form
    {
        private bool imageLoaded;
        private Form form;
        private PictureBox imageBox;
        //private ArrayList imageBoxArray;
        private int currentFrame;
        private int moveBy = 10;
        private ImageParser parser;
        private int contrastValue;
        private AdvancedColor c;

        public SharpStacker()
        {
            InitializeComponent();
            parser = new ImageParser();
            imageLoaded = false;
        }

        private void enableImageControls()
        {
            contrastSlider.Enabled = true;
            alphaSlider.Enabled = true;
            btnBack.Enabled = true;
            btnNext.Enabled = true;
            btnUp.Enabled = true;
            btnDown.Enabled = true;
            btnLeft.Enabled = true;
            btnRight.Enabled = true;
            btnStack.Enabled = true;
            rbCoarse.Checked = true;
        }

        private void MoveImage(object sender, EventArgs e)
        {
            Button direction = (Button)sender;
            int xDelta = 0;
            int yDelta = 0;

            switch (direction.Text)
            {
                case "Up":
                    yDelta += moveBy;
                    break;
                case "Down":
                    yDelta -= moveBy;
                    break;
                case "Right":
                    xDelta -= moveBy;
                    break;
                case "Left":
                    xDelta += moveBy;
                    break;
                default:
                    break;
            }

            imageBox.Image = parser.MoveBitmap(currentFrame, xDelta, yDelta);
            form.Refresh();
        }

        private void StackImage(object sender, EventArgs e)
        {
            if (currentFrame < parser.numberOfFrames - 1)
            {
                currentFrame++;
                imageBox.Image = parser.AdjustContrast(currentFrame, contrastValue);
                lblFrameNumber.Text = (currentFrame + 1).ToString();
                alphaSlider.Value = 255;
                form.Refresh();
                c.UpdateChart(parser.PrepareColorGraph(currentFrame), currentFrame);
                c.Refresh();
            }
        }

        private void OpenImage(object sender, EventArgs e)
        {
            openDialog = new OpenFileDialog();
            openDialog.ShowDialog();
            string filename = openDialog.FileName;
            openDialog.Dispose();
            if (filename != "")
            {
                parser.Load16bitImagesToMemory(filename);
                currentFrame = 0;
                lblTotalNoF.Text = parser.numberOfFrames.ToString();
                lblFrameNumber.Text = (currentFrame + 1).ToString();

                Bitmap stampa = parser.getStampa(currentFrame);

                form = new Form
                {
                    Size = new Size(stampa.Width, stampa.Height),
                    Text = filename
                };

                imageBox = new PictureBox
                {
                    Location = new Point(0, 0),
                    Size = new Size(stampa.Width, stampa.Height),
                    Image = stampa
                };

                form.Controls.Add(imageBox);
                enableImageControls();
                form.KeyDown += Form_KeyDown;
                form.Show();
                imageLoaded = true;

                c = new AdvancedColor();
                c.UpdateChart(parser.PrepareColorGraph(currentFrame), currentFrame);
                c.Show();
            }
            
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            int xDelta = 0;
            int yDelta = 0;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    yDelta += moveBy;
                    break;
                case Keys.Down:
                    yDelta -= moveBy;
                    break;
                case Keys.Right:
                    xDelta -= moveBy;
                    break;
                case Keys.Left:
                    xDelta += moveBy;
                    break;
                case Keys.PageUp:
                    MoveFrame(true, false);
                    break;
                case Keys.PageDown:
                    MoveFrame(false, true);
                    break;
                default:
                    break;
            }

            imageBox.Image = parser.MoveBitmap(currentFrame, xDelta, yDelta);
            form.Refresh();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form.Dispose();
            Application.Exit();
        }
        
        private void MoveFrame(object sender, EventArgs e)
        {
            if (imageLoaded)
            {
                if (sender is Button changeFrame)
                {
                    if (changeFrame.Text.Equals("Next"))
                    {
                        MoveFrame(true, false);
                    }
                    if (changeFrame.Text.Equals("Back"))
                    {
                        MoveFrame(false, true);
                    }
                }
            }
            else
            {
                MessageBox.Show("TIFF not loaded");            
            }
        }

        private void MoveFrame(bool moveNext, bool moveBack)
        {
            if (moveNext)
            {
                if (currentFrame < parser.numberOfFrames - 1)
                {
                    currentFrame++;
                }
            }
            else if (moveBack)
            {
                if (currentFrame > 0)
                {
                    currentFrame--;
                }
            }
            else
            {
                return;
            }

            lblFrameNumber.Text = (currentFrame + 1).ToString();
            imageBox.Image = parser.AdjustContrast(currentFrame, contrastValue);
            form.Refresh();
            c.UpdateChart(parser.PrepareColorGraph(currentFrame), currentFrame);
            c.Refresh();
        }

        private void contrastSlider_Scroll(object sender, EventArgs e)
        {
            if (imageLoaded)
            {
                TrackBar contrast = (TrackBar)sender;
                contrastValue = contrast.Value;

                imageBox.Image = parser.AdjustContrast(currentFrame, contrastValue);     
                form.Refresh();
            }
            else
            {
                MessageBox.Show("TIFF not loaded");
            }
        }

        private void alphaSlider_Scroll(object sender, EventArgs e)
        {
            if (imageLoaded)
            {
                TrackBar alpha = (TrackBar)sender;
                int alphaValue = alpha.Value;
                imageBox.Image = parser.AdjustAlpha(currentFrame, alphaValue);
                form.Refresh();
            }
        }

        private void fineCoarse_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCoarse.Checked) moveBy = 10;
            else if (rbFine.Checked) moveBy = 1;
        }

        private void SaveToDisk(object sender, EventArgs e)
        {
            if (imageLoaded)
            {
                saveImage = new SaveFileDialog();
                saveImage.ShowDialog();
                string fileName = saveImage.FileName;
                saveImage.Dispose();
                if (fileName != "") parser.Save16bitImagesToDisk(fileName);
            }
            else
            {
                MessageBox.Show("TIFF not loaded");
            }
        }

        private void settingsMenu_Click(object sender, EventArgs e)
        {

        }

        private void aboutMenu_Click(object sender, EventArgs e)
        {
            About form = new About();
            form.Show();
        }
    }
}
