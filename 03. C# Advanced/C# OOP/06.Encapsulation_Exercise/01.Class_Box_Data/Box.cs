using System;
namespace _01.Class_Box_Data
{
    public class Box
    {
        private double length;
        private double width;
        private double height;
        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length {
            get
            {
                return this.length;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                length = value;
            }
        }
        public double Width {
            get
            {
                return this.width;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                width = value;
            }
        }
        public double Height {
            get {
                return this.height;
            }
            private set {
                if (value < 1)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                height = value;
            }
        }


        public double SurfaceArea()
        {
            return 2 * (Width * Length + Height * Length + Height * Width);
        }

        public double LateralSurfaceArea()
        {
            return 2 * Length * Height + 2 * Width * Height;
        }

        public double Volume()
        {
            return Length * Width * Height;
        }
    }
}
