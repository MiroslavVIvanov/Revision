namespace ShapesSystem.Classes
{
    public class Triangle : Shape
    {
        public Triangle(double widht, double height) 
            : base(widht, height)
        {
        }

        public override double CalculateSurface()
        {
            return (this.Height * this.Widht) / 2d;
        }
    }
}
