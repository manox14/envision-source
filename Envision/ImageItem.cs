/*
 *  Copyright © Benjamin Brent 2011
 * 
 *  This file is part of Envision.
 *
 *  Envision is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  Envision is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with Envision. If not, see <http://www.gnu.org/licenses/>.
 */

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
