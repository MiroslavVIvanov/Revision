namespace CohesionAndCoupling
{
    using System;

    public class Parallelepiped
    {
        private double width;
        private double height;
        private double depth;

        public Parallelepiped(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
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
                    throw new ArgumentException("Paralelepiped width can not be less than 0;");
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
                    throw new ArgumentException("Paralelepiped height can not be less than 0;");
                }

                this.height = value;
            }
        }

        public double Depth
        {
            get
            {
                return this.depth;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Paralelepiped depth can not be less than 0;");
                }

                this.depth = value;
            }
        }

        public double CalculateVolume()
        {
            double volume = this.Width * this.Height * this.Depth;
            return volume;
        }

        public double CalculateInnerDiagonal()
        {
            var diagonal = CalculateDiagonal(this.Width, this.Height, this.Depth);
            return diagonal;
        }

        public double CalculateFirstSideDiagonal()
        {
            var diagonal = CalculateDiagonal(this.Width, this.Height);
            return diagonal;
        }

        public double CalculateSecondSideDiagonal()
        {
            var diagonal = CalculateDiagonal(this.Width, this.Depth);
            return diagonal;
        }

        public double CalculateThirdSideDiagonal()
        {
            var diagonal = CalculateDiagonal(this.Height, this.Depth);
            return diagonal;
        }

        private double CalculateDiagonal(double firstSide, double secondSide)
        {
            double distance = DistanceUtils.CalcDistance2D(0, 0, firstSide, secondSide);
            return distance;
        }

        private double CalculateDiagonal(double firstSide, double secondSide, double thirdSide)
        {
            double distance = DistanceUtils.CalcDistance3D(0, 0, 0, firstSide, secondSide, thirdSide);
            return distance;
        }
    }
}