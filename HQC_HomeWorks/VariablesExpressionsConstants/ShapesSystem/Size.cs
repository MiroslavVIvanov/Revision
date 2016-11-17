namespace ShapesSystem
{
    using System;

    public class Size
    {
        private double width;
        private double height;

        public Size(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Width can not be negative!");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Height can not be negative!");
                }

                this.height = value;
            }
        }

        public static Size CalculateRotatedFigureSize(Size size, double rotationAngle)
        {
            var newWidth = (Math.Abs(Math.Cos(rotationAngle)) * size.Width) +
                    (Math.Abs(Math.Sin(rotationAngle)) * size.Height);

            var newHeight = (Math.Abs(Math.Sin(rotationAngle)) * size.Width) +
                    (Math.Abs(Math.Cos(rotationAngle)) * size.Height);

            var rotatedFigureSize = new Size(newWidth, newHeight);

            return rotatedFigureSize;
        }
    }
}
