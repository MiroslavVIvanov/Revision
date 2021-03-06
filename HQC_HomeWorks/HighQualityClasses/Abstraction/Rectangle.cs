﻿namespace Abstraction
{
    using System;

    public class Rectangle : Figure
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
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
                    throw new ArgumentException("Rectangle width can not be less than 0;");
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
                    throw new ArgumentException("Rectangle height can not be less than 0;");
                }

                this.height = value;
            }
        }

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
