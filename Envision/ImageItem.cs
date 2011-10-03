using System;
using System.Collections.Generic;
using System.Text;

namespace Envision
{
    public class ImageItem
    {
        public string filename;
        public string filepath;

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
