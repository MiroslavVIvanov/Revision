namespace GenericMatrix
{
    public class Startup
    {
        public static void Main()
        {
            Matrix<double> mat = new Matrix<double>(3, 3);
            mat[0, 0] = 1;
            mat[0, 1] = 1;
            mat[0, 2] = 1;
            mat[1, 0] = 1;
            mat[1, 1] = 1;
            mat[1, 2] = 1;
            mat[2, 0] = 1;
            mat[2, 1] = 1;
            mat[2, 2] = 1;

            Matrix<double> secondMat = new Matrix<double>(3, 3);
            secondMat[0, 0] = 2;
            secondMat[0, 1] = 2;
            secondMat[0, 2] = 2;
            secondMat[1, 0] = 2;
            secondMat[1, 1] = 2;
            secondMat[1, 2] = 2;
            secondMat[2, 0] = 2;
            secondMat[2, 1] = 2;
            secondMat[2, 2] = 2;

            Matrix<double> result = mat * secondMat;
            System.Console.WriteLine(result.ToString());
        }
    }
}
