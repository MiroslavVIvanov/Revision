namespace ShapesSystemConsoleClient
{
    using System.Collections.Generic;
    using ShapesSystem.Classes;

    public class Startup
    {
        public static void Main()
        {
            List<Shape> listOfShapes = new List<Shape>();
            listOfShapes.Add(new Square(5.3));
            listOfShapes.Add(new Triangle(3.8, 2.1));
            listOfShapes.Add(new Rectangle(7.4, 12));
            listOfShapes.Add(new Square(7.77));
            listOfShapes.Add(new Triangle(4.17, 17.4));

            foreach (var shape in listOfShapes)
            {
                System.Console.WriteLine(
                    "The area of shape with width: {0} and height {1} is: {2}",
                    shape.Widht, 
                    shape.Height, 
                    shape.CalculateSurface());
            }
        }
    }
}
