using System.Collections;

namespace SharpStacker
{
    class Frame
    {
        public Frame(int _width, int _height)
        {
            xDelta = 0;
            yDelta = 0;
            contrast = 1;
            alpha = 255;
            width = _width;
            height = _height;
            imageData = new ArrayList(height);
            isDeleted = false;
        }

        public int xDelta;
        public int yDelta;
        public float contrast;
        public byte alpha;
        public ArrayList imageData;
        public int width;
        public int height;
        public bool isDeleted;

        public BitMiracle.LibTiff.Classic.PlanarConfig planarConfig;
        public BitMiracle.LibTiff.Classic.Photometric photo;
        public BitMiracle.LibTiff.Classic.Compression compression;

        public int rowPerStrip;
        public int bitsPerSample;
        public int samplesPerPixel;
    }
}
