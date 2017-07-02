using System;

namespace Problem_1.Class_Box
{
    class Box
    {
        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        private double Length { get; set; }

        private double Width { get; set; }

        private double Height { get; set; }

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
