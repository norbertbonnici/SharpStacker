using BitMiracle.LibTiff.Classic;
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace SharpStacker
{
    class ImageParser
    {
        private ArrayList frameArray;

        private const int pixelSize = 4;
        public int numberOfFrames;

        public enum OutputType { Indexed8, ARGB32 }

        public ImageParser()
        {
            numberOfFrames = 0;
        }

        public Bitmap getStampa(int frameNumber)
        {
            if (frameArray != null)
            {
                return BuildBitmap(frameNumber);
            }
            else return null;
        }

        public int[] PrepareColorGraph(int frameNumber)
        {
            Frame currentFrame = (Frame) frameArray[frameNumber];

            int nSamples = (int) (Math.Pow(2, currentFrame.bitsPerSample));
            int[] histogram = new int[nSamples];

            foreach (ushort[] scanline in currentFrame.imageData)
            {
                for(int x = 0; x<scanline.Length; x++)
                {
                    var val = scanline[x];
                    histogram[val]++;
                }
            }

            if (currentFrame.bitsPerSample > 8)
            {
                int binWidth = ((nSamples - 1) / 511);

                int[] hist = new int[512];
                int counter = 0;
                for (int i = 0; i < nSamples; i += binWidth)
                {
                    for (int iter = 0; iter < binWidth; iter++)
                    {
                        hist[counter] += histogram[i + iter];
                    }
                    counter++;
                }
                return hist;
            }

            else return histogram;
        }

        public void Load16bitImagesToMemory(string fileName)
        {
            using (Tiff input = Tiff.Open(fileName, "r"))
            {
                int width = input.GetField(TiffTag.IMAGEWIDTH)[0].ToInt();
                int height = input.GetField(TiffTag.IMAGELENGTH)[0].ToInt();
                int samplesPerPixel = input.GetField(TiffTag.SAMPLESPERPIXEL)[0].ToInt();
                int bitsPerSample = input.GetField(TiffTag.BITSPERSAMPLE)[0].ToInt();
                int rowPerStrip = input.GetField(TiffTag.ROWSPERSTRIP)[0].ToInt();
                var planarConfig = input.GetField(TiffTag.PLANARCONFIG)[0];
                var photo = input.GetField(TiffTag.PHOTOMETRIC)[0];
                var compression = input.GetField(TiffTag.COMPRESSION)[0];
                int scanlineSize = input.ScanlineSize();
                numberOfFrames = input.NumberOfDirectories();
                
                frameArray = new ArrayList(numberOfFrames);

                for (int p = 0; p < numberOfFrames; p++)
                {
                    Frame frame = new Frame(width, height)
                    {
                        planarConfig = (PlanarConfig)planarConfig.Value,
                        compression = (Compression)compression.Value,
                        photo = (Photometric)photo.Value,
                        rowPerStrip = rowPerStrip,
                        bitsPerSample = bitsPerSample,
                        samplesPerPixel = samplesPerPixel
                    };

                    for (int y = 0; y < height; y++)
                    {
                        byte[] buffer_i = new byte[scanlineSize];
                        input.ReadScanline(buffer_i, y);
                        if (bitsPerSample == 32)
                        {
                            uint[] buffer_32bit = new uint[width];
                            Buffer.BlockCopy(buffer_i, 0, buffer_32bit, 0, buffer_i.Length);

                            frame.imageData.Add(buffer_32bit.Clone());
                        }
                        if (bitsPerSample == 16)
                        {
                            ushort[] buffer_16bit = new ushort[width];
                            Buffer.BlockCopy(buffer_i, 0, buffer_16bit, 0, buffer_i.Length);

                            frame.imageData.Add(buffer_16bit.Clone());
                        } 
                        else if (bitsPerSample == 8)
                        {
                            frame.imageData.Add(buffer_i.Clone());
                        }
                    }

                    // Add the generated frame to the frame array
                    frameArray.Add(frame);

                    // Get the next frame
                    input.ReadDirectory();
                }
            }
        }

        public void Save16bitImagesToDisk(string fileName)
        {
            int frameNumber = 0;
            using (Tiff output = Tiff.Open(fileName, "w"))
            {
                foreach (Frame currentFrame in frameArray)
                {
                    output.SetField(TiffTag.IMAGEWIDTH, currentFrame.width);
                    output.SetField(TiffTag.IMAGELENGTH, currentFrame.height);
                    output.SetField(TiffTag.SAMPLESPERPIXEL, currentFrame.samplesPerPixel);
                    output.SetField(TiffTag.BITSPERSAMPLE, currentFrame.bitsPerSample);
                    output.SetField(TiffTag.ROWSPERSTRIP, currentFrame.rowPerStrip);
                    output.SetField(TiffTag.PLANARCONFIG, currentFrame.planarConfig);
                    output.SetField(TiffTag.PHOTOMETRIC, currentFrame.photo);
                    output.SetField(TiffTag.COMPRESSION, currentFrame.compression);

                    // specify that it's a page within the multipage file
                    output.SetField(TiffTag.SUBFILETYPE, FileType.PAGE);
                    // specify the page number
                    output.SetField(TiffTag.PAGENUMBER, frameNumber, numberOfFrames);

                    for (int y = 0; y < currentFrame.height; y++)
                    {
                        ushort[] currentScanline = new ushort[currentFrame.width];

                        if ((y + currentFrame.yDelta < currentFrame.height) && (y + currentFrame.yDelta >= 0))
                        {
                            currentScanline = (ushort[]) currentFrame.imageData[y + currentFrame.yDelta];
                        }

                        ushort[] outputBuffer = new ushort[currentFrame.width];

                        for (int x = 0; x < currentFrame.width; x++)
                        {
                            ushort Gray = 0;
                            if ((x + currentFrame.xDelta < currentFrame.width) && (x + currentFrame.xDelta > 0))
                            {
                                Gray = currentScanline[x + currentFrame.xDelta];
                            }
                            outputBuffer[x] = Gray;
                        }

                        byte[] buffer = new byte[outputBuffer.Length * (currentFrame.bitsPerSample/8)];
                        Buffer.BlockCopy(outputBuffer, 0, buffer, 0, buffer.Length);
                        output.WriteScanline(buffer, y);
                    }
                    frameNumber++;
                    output.WriteDirectory();
                }
            }
        }

        public Bitmap AdjustContrast(int frameNumber, float contrastValue)
        {
            contrastValue = (100.0f + contrastValue) / 100.0f;
            contrastValue *= contrastValue;

            Frame currentFrame = (Frame)frameArray[frameNumber];
            currentFrame.contrast = contrastValue;

            return BuildBitmap(frameNumber);
        }

        public Bitmap AdjustAlpha(int frameNumber, int Value)
        {
            Frame currentFrame = (Frame)frameArray[frameNumber];
            currentFrame.alpha = (byte)Value;

            return BuildBitmap(frameNumber);
        }

        public Bitmap MoveBitmap(int frameNumber, int xDelta, int yDelta)
        {
            Frame currentFrame = (Frame)frameArray[frameNumber];
            currentFrame.xDelta += xDelta;
            currentFrame.yDelta += yDelta;

            return BuildBitmap(frameNumber);
        }

        private Bitmap BuildBitmap(int frameNumber)
        {
            Frame currentFrame = (Frame)frameArray[frameNumber];
            int height = currentFrame.height;
            int width = currentFrame.width;

            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);

            BitmapData data = bitmap.LockBits(
                new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite,
                bitmap.PixelFormat);

            var bitmapBytes = new byte[width * height * pixelSize];

            for (int y = 0; y < height; y++)
            {

                var currentScanline = new ushort[width];

                if ((y + currentFrame.yDelta < height) && (y + currentFrame.yDelta >= 0))
                {
                    currentScanline = (ushort[])currentFrame.imageData[y + currentFrame.yDelta];
                }
                
                for (int x = 0; x < width; x++)
                {
                    float Gray = 0;
                    if ((x + currentFrame.xDelta < width) && (x + currentFrame.xDelta > 0))
                    {
                        Gray = currentScanline[x + currentFrame.xDelta] / (float)(Math.Pow(2, currentFrame.bitsPerSample) - 1);
                        Gray = (((Gray - 0.5f) * currentFrame.contrast) + 0.5f) * 255;
                    }

                    int iG = (int)Gray;

                    var i = ((y * width) + x);

                    int j1 = i * pixelSize;
                    bitmapBytes[j1] = (byte)iG;//B
                    bitmapBytes[j1 + 1] = (byte)iG;//G
                    bitmapBytes[j1 + 2] = (byte)iG;//R
                    bitmapBytes[j1 + 3] = currentFrame.alpha;//A
                }
            }

            var ptr = data.Scan0;
            Marshal.Copy(bitmapBytes, 0, ptr, bitmapBytes.Length);
            bitmap.UnlockBits(data);

            return bitmap;
        }
    }
}
