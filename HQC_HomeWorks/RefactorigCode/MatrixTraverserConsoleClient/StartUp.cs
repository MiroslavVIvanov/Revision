namespace MatrixWalk
{
    using System;
    using InputProviders;

    public class StartUp
    {
        public static void Main()
        {
            Console.WriteLine("Enter a positive number: ");

            int matrixSize = 0;

            IIOProvider inputProvider = new ConsoleIOProvider();

            while (!int.TryParse(inputProvider.Read(), out matrixSize) || matrixSize < 0 || matrixSize > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number");
            }

            Matrix matrix = new Matrix(matrixSize);
            Console.WriteLine(matrix.ToString());
        }
    }
}
