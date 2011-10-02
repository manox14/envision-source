using System;
using System.Collections.Generic;
using System.Text;

namespace Envision
{
    class ImageItem
    {
        private string filename;
        private string filepath;

        public ImageItem(string filename, string filepath)
        {
            this.filename = filename;
            this.filepath = filepath;
        }

        public override string ToString()
        {
            return this.filename;
        }
    }
}
