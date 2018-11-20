using BitMiracle.LibTiff.Classic;
using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SharpStacker
{
    public partial class SharpStacker : Form
    {
        private Form form;
        private PictureBox imageBox;
        private ArrayList stampi;
        private int numberOfFrames, currentFrame;
        private int moveBy = 1;

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
                    moveBy += moveBy;
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
            string imageName = openImage.FileName;

            Load16bitImagesToMemory(imageName);
            currentFrame = 0;
            numberOfFrames = stampi.Capacity;
            lblTotalNoF.Text = numberOfFrames.ToString();
            lblFrameNumber.Text = (currentFrame + 1).ToString();

            Bitmap stampa = (Bitmap)stampi[currentFrame];

            form = new Form
            {
                Size = new Size(stampa.Width, stampa.Height),
                Text = openImage.FileName.ToString()
            };

            imageBox = new PictureBox
            {
                Location = new Point(0, 0),
                Size = new Size(stampa.Width, stampa.Height),
                Image = stampa
            };

            form.Controls.Add(imageBox);

            form.Show();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void MoveFrame(object sender, EventArgs e)
        {
            if (stampi != null)
            {
                if (sender is Button changeFrame)
                {
                    if (changeFrame.Text.Equals("Next"))
                    {
                        if (currentFrame < numberOfFrames - 1)
                        {
                            currentFrame++;
                        }
                    }
                    if (changeFrame.Text.Equals("Back"))
                    {
                        if (currentFrame > 0)
                        {
                            currentFrame--;
                        }
                    }
                }

                Bitmap stampa = (Bitmap)stampi[currentFrame];

                imageBox.Image = stampa;
                lblFrameNumber.Text = (currentFrame + 1).ToString();

                form.Refresh();
            }
            else
            {
                MessageBox.Show("TIFF not loaded");            
            }
        }

        private void contrastSlider_Scroll(object sender, EventArgs e)
        {
            if (stampi != null)
            {
                TrackBar contrast = (TrackBar)sender;
                float contrastValue = contrast.Value;

                imageBox.Image = AdjustContrast((Bitmap)stampi[currentFrame], contrastValue);
                form.Refresh();
            }
            else
            {
                MessageBox.Show("TIFF not loaded");
            }
        }

        public static Bitmap AdjustContrast(Bitmap Image, float Value)
        {
            Value = (100.0f + Value) / 100.0f;
            Value *= Value;
            Bitmap NewBitmap = (Bitmap)Image.Clone();
            BitmapData data = NewBitmap.LockBits(
                new Rectangle(0, 0, NewBitmap.Width, NewBitmap.Height),
                ImageLockMode.ReadWrite,
                NewBitmap.PixelFormat);
            int Height = NewBitmap.Height;
            int Width = NewBitmap.Width;

            for (int y = 0; y < Height; ++y)
            {
                unsafe
                {
                    byte* row = (byte*)data.Scan0 + (y * data.Stride);
                    int columnOffset = 0;
                    for (int x = 0; x < Width; ++x)
                    {
                        byte B = row[columnOffset];
                        byte G = row[columnOffset + 1];
                        byte R = row[columnOffset + 2]; 

                        float Red = R / 255.0f;
                        float Green = G / 255.0f;
                        float Blue = B / 255.0f;
                        Red = (((Red - 0.5f) * Value) + 0.5f) * 255.0f;
                        Green = (((Green - 0.5f) * Value) + 0.5f) * 255.0f;
                        Blue = (((Blue - 0.5f) * Value) + 0.5f) * 255.0f;

                        int iR = (int)Red;
                        iR = iR > 255 ? 255 : iR;
                        iR = iR < 0 ? 0 : iR;
                        int iG = (int)Green;
                        iG = iG > 255 ? 255 : iG;
                        iG = iG < 0 ? 0 : iG;
                        int iB = (int)Blue;
                        iB = iB > 255 ? 255 : iB;
                        iB = iB < 0 ? 0 : iB;

                        row[columnOffset] = (byte)iB;
                        row[columnOffset + 1] = (byte)iG;
                        row[columnOffset + 2] = (byte)iR;

                        columnOffset += 4;
                    }
                }
                
            }

            NewBitmap.UnlockBits(data);

            return NewBitmap;
        }

        private void alphaSlider_Scroll(object sender, EventArgs e)
        {
            if (stampi != null)
            {
                TrackBar alpha = (TrackBar)sender;
                float alphaValue = alpha.Value;
                Bitmap stampa = (Bitmap)stampi[currentFrame];
                Bitmap NewBitmap = (Bitmap)stampa.Clone();
                BitmapData data = NewBitmap.LockBits(
                    new Rectangle(0, 0, NewBitmap.Width, NewBitmap.Height),
                    ImageLockMode.ReadWrite,
                    NewBitmap.PixelFormat);
                int Height = NewBitmap.Height;
                int Width = NewBitmap.Width;
            }
        }

        private void fineCoarse_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCoarse.Checked)
            {
                moveBy = 10;
            }
            else if (rbFine.Checked)
            {
                moveBy = 1;
            }
        }

        private void Load16bitImagesToMemory(string fileName)
        {
            Bitmap stampa16;
            using (Tiff input = Tiff.Open(fileName, "r"))
            {
                var pages = input.NumberOfDirectories();
                stampi = new ArrayList(pages);

                for (int p = 0; p < pages; p++)
                {
                    int width = input.GetField(TiffTag.IMAGEWIDTH)[0].ToInt();
                    int height = input.GetField(TiffTag.IMAGELENGTH)[0].ToInt();
                    int samplesPerPixel = input.GetField(TiffTag.SAMPLESPERPIXEL)[0].ToInt();
                    int bitsPerSample = input.GetField(TiffTag.BITSPERSAMPLE)[0].ToInt();
                    int photo = input.GetField(TiffTag.PHOTOMETRIC)[0].ToInt();

                    int scanlineSize = input.ScanlineSize();

                    stampa16 = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
                    int pixelSize = 1;
                    var rect = new Rectangle(0, 0, width, height);
                    var bitmapData = stampa16.LockBits(rect, ImageLockMode.WriteOnly, stampa16.PixelFormat);
                    var bitmapBytes = new byte[width * height * pixelSize];

                    for (int y = 0; y < height; y++)
                    {
                        byte[] buffer_i = new byte[scanlineSize];
                        input.ReadScanline(buffer_i, y);

                        for (int x = 0; x < width * 2; x++)
                        {
                            var value = (byte)(BitConverter.ToUInt16(new byte[2] { buffer_i[x], buffer_i[x + 1] }, 0) / 255);
                            var i = ((y * width) + (x / 2));
                            bitmapBytes[i] = value;
                            x++;
                        }

                        /*for (int x = 0; x < width * 2; x++)
                        {
                            var i = ((y * width) + (x / 2));
                            var value = (byte) (BitConverter.ToUInt16(new byte[2] { buffer_i[x+1], buffer_i[x] }, 0) / 255);

                            int j1 = i * 3;
                            bitmapBytes[j1] = value;//B
                            bitmapBytes[j1+1] = value;//G
                            bitmapBytes[j1+2] = value;//R
                            x++;
                        }*/
                    }

                    // Copy the randomized bits to the bitmap pointer.
                    var ptr = bitmapData.Scan0;
                    Marshal.Copy(bitmapBytes, 0, ptr, bitmapBytes.Length);

                    // Unlock the bitmap, we're all done.
                    stampa16.UnlockBits(bitmapData);
                    stampi.Add(stampa16);

                    input.ReadDirectory();
                }
            }
        }
    }
}
