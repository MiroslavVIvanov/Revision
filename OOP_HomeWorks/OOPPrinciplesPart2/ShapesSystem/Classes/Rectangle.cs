namespace ShapesSystem.Classes
{
    public class Rectangle : Shape
    {
        public Rectangle(double widht, double height) 
            : base(widht, height)
        {
        }

        public override double CalculateSurface()
        {
            return this.Widht * this.Height;
        }
    }
}
