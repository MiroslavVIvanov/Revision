namespace CohesionAndCoupling
{
    using System;

    public class UtilsExamples
    {
        public static void Main()
        {
            // Console.WriteLine(FileNameUtils.GetFileExtension("example")); //throws exception
            Console.WriteLine(FileNameUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileNameUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileNameUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileNameUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileNameUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine(
                "Distance in the 2D space = {0:f2}",
                DistanceUtils.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine(
                "Distance in the 3D space = {0:f2}",
                DistanceUtils.CalcDistance3D(5, 2, -1, 3, -6, 4));

            Parallelepiped parallelepiped = new Parallelepiped(3, 4, 5);

            Console.WriteLine("Volume = {0:f2}", parallelepiped.CalculateVolume());
            Console.WriteLine("Inner diagonal = {0:f2}", parallelepiped.CalculateInnerDiagonal());
            Console.WriteLine("First side diagonal = {0:f2}", parallelepiped.CalculateFirstSideDiagonal());
            Console.WriteLine("Second side diagonal = {0:f2}", parallelepiped.CalculateSecondSideDiagonal());
            Console.WriteLine("Third side diagonal = {0:f2}", parallelepiped.CalculateThirdSideDiagonal());
        }
    }
}
