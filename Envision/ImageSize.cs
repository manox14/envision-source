using System;
using System.Collections.Generic;
using System.Text;

namespace Envision
{
    class ImageSize
    {
        private int width;

        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        private int height;

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public ImageSize(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
    }
}
