using System;
using System.IO;

namespace Problem_2.Class_Box_Data_Validation
{
    class Box
    {
        private double _length;
        private double _width;
        private double _height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        private double Length
        {
            get { return this._length; }
            set
            {
                if (value <= 0)
                {
                    throw new InvalidDataException("Length cannot be zero or negative. ");
                }
                this._length = value;
            }
        }

        private double Width
        {
            get { return this._width; }
            set
            {
                if (value <= 0)
                {
                    throw new InvalidDataException("Width cannot be zero or negative. ");
                }
                this._width = value;
            }
        }

        private double Height
        {
            get { return this._height; }
            set
            {
                if (value <= 0)
                {
                    throw new InvalidDataException("Height cannot be zero or negative. ");
                }
                this._height = value;
            }
        }

        public double SurfaceArea()
        {
            // 2lw + 2lh + 2wh
            var surfaceArea = 2 * this.Length * this.Width + 2 * this.Length * this.Height +
                              2 * this.Width * this.Height;
            return surfaceArea;
        }

        public double LateralSurfaceArea()
        {
            // 2lh + 2wh
            var lateralSurfArea = 2 * this.Length * this.Height + 2 * this.Width * this.Height;
            return lateralSurfArea;
        }

        public double Volume()
        {
            //  lwh
            var volume = this.Length * this.Width * this.Height;
            return volume;
        }
    }
}
