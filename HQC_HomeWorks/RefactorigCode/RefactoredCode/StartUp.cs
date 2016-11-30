namespace MatrixWalk
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            Console.Write("Enter a positive number: ");

            int matrixSize = 0;

            while (!int.TryParse(Console.ReadLine(), out matrixSize) || matrixSize < 0 || matrixSize > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number");
            }

            Matrix matrix = new Matrix(matrixSize);
            Console.WriteLine(matrix.ToString());
        }
    }
}
