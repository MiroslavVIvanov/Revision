namespace Abstraction
{
    using System;

    public class Rectangle : Figure
    {
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width { get; set; }

        public double Height { get; set; }

        public override double CalculateSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }
    }
}
