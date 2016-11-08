namespace ShapesSystem.Classes
{
    public abstract class Shape
    {
        protected Shape(double widht, double height)
        {
            this.Widht = widht;
            this.Height = height;
        }

        public double Widht { get; set; }

        public double Height { get; set; }

        public abstract double CalculateSurface();
    }
}
