using BitMiracle.LibTiff.Classic;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SharpStacker
{
    public partial class SharpStacker : Form
    {
        private Bitmap stampa;

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
            stampa = (Bitmap) Image.FromFile(openImage.FileName, true);
            imageBox.Image = stampa;
            imageBox.Height = stampa.Height;
            imageBox.Width = stampa.Width;

            /*openImage = new OpenFileDialog();
            openImage.ShowDialog();

            /*using (var inputImage = Tiff.Open(openImage.FileName, "r"))
            {
                int width = inputImage.GetField(TiffTag.IMAGEWIDTH)[0].ToInt();
                int height = inputImage.GetField(TiffTag.IMAGELENGTH)[0].ToInt();
                byte[] inputImageData = new byte[width * height * 2];
                var offset = 0;
                for (int i = 0; i < inputImage.NumberOfStrips(); i++)
                {
                    offset += inputImage.ReadRawStrip(i, inputImageData, offset, (int)inputImage.RawStripSize(i));
                }

                /*var output = new Bitmap(width, height, PixelFormat.Format16bppGrayScale);
                var rect = new Rectangle(0, 0, width, height);
                var bmpData = output.LockBits(rect, ImageLockMode.ReadWrite, output.PixelFormat);

                // Row-by-row copy
                var arrRowLength = width * Image.GetPixelFormatSize(output.PixelFormat) / 8;
                var ptr = bmpData.Scan0;
                for (var i = 0; i < height; i++)
                {
                    Marshal.Copy(inputImageData, i * arrRowLength, ptr, arrRowLength);
                    ptr += bmpData.Stride;
                }

                output.UnlockBits(bmpData);

                //var stream = new System.IO.MemoryStream(inputImageData);
                //stampa = (Bitmap)Image.FromStream(stream);

                imageBox.Image = stampa;
            } */


        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void moveFrame(object sender, EventArgs e)
        {
            //int frames = imageBox.Image.GetFrameCount();
        }

        private void contrastSlider_Scroll(object sender, EventArgs e)
        {
            TrackBar contrast = (TrackBar)sender;
            float contrastValue = contrast.Value;

            imageBox.Image = AdjustContrast(stampa, contrastValue);       
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
    }
}
