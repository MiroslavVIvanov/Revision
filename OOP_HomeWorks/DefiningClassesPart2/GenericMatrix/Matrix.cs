////Problem 8. Matrix
////Define a class Matrix<T> to hold a matrix of numbers(e.g.integers, floats, decimals).

////Problem 9. Matrix indexer
////Implement an indexer this[row, col] to access the inner matrix cells.

////Problem 10. Matrix operations
////Implement the operators + and - (addition and subtraction of matrices 
////of the same size) and * for matrix multiplication.
////Throw an exception when the operation cannot be performed.
////Implement the true operator (check for non-zero elements).

namespace GenericMatrix
{
    using System;
    using System.Text;

    public class Matrix<T> where T : struct
    {
        private T[,] storingMatrix;

        public Matrix(int with, int height)
        {
            this.StoringMatrix = new T[with, height];
        }

        public int Width
        {
            get
            {
                return this.StoringMatrix.GetLength(0);
            }
        }

        public int Height
        {
            get
            {
                return this.StoringMatrix.GetLength(1);
            }
        }

        private T[,] StoringMatrix
        {
            get
            {
                return this.storingMatrix;
            }

            set
            {
                this.storingMatrix = value;
            }
        }

        public T this[int row, int col]
        {
            get
            {
                return this.StoringMatrix[row, col];
            }

            set
            {
                double parsed;
                if (!double.TryParse(value.ToString(), out parsed))
                {
                    throw new ArgumentException("Only numbers are stored in the Matrix!");
                }

                this.StoringMatrix[row, col] = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Width != secondMatrix.Width
                || firstMatrix.Height != secondMatrix.Height)
            {
                throw new ArgumentException("Matrices must be of same size.");
            }

            Matrix<T> resultMatrix = new Matrix<T>(firstMatrix.Width, firstMatrix.Height);
            for (int row = 0; row < resultMatrix.Height; row++)
            {
                for (int col = 0; col < resultMatrix.Width; col++)
                {
                    resultMatrix[row, col] = (dynamic)firstMatrix[row, col] + (dynamic)secondMatrix[row, col];
                }
            }

            return resultMatrix;
        }

        public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Width != secondMatrix.Width
                || firstMatrix.Height != secondMatrix.Height)
            {
                throw new ArgumentException("Matrices must be of same size.");
            }

            Matrix<T> resultMatrix = new Matrix<T>(firstMatrix.Width, firstMatrix.Height);
            for (int row = 0; row < resultMatrix.Height; row++)
            {
                for (int col = 0; col < resultMatrix.Width; col++)
                {
                    resultMatrix[row, col] = (dynamic)firstMatrix[row, col] - (dynamic)secondMatrix[row, col];
                }
            }

            return resultMatrix;
        }

        public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Width != secondMatrix.Height)
            {
                throw new FormatException("Matrices unsuitable for multiplying");
            }

            int rows = firstMatrix.Height;
            int cols = secondMatrix.Width;

            Matrix<T> resultMatrix = new Matrix<T>(rows, cols);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    dynamic sum = 0;
                    for (int k = 0; k < cols; k++)
                    {
                        sum += (dynamic)firstMatrix[i, k] * (dynamic)secondMatrix[k, j];
                    }

                    resultMatrix.StoringMatrix[i, j] = sum;
                }
            }

            return resultMatrix;
        }

        public static bool operator true(Matrix<T> testedMatrix)
        {
            for (int row = 0; row < testedMatrix.Height; row++)
            {
                for (int col = 0; col < testedMatrix.Width; col++)
                {
                    if ((dynamic)testedMatrix[row, col] == default(T))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator false(Matrix<T> testedMatrix)
        {
            for (int row = 0; row < testedMatrix.Height; row++)
            {
                for (int col = 0; col < testedMatrix.Width; col++)
                {
                    if ((dynamic)testedMatrix[row, col] == default(T))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.StoringMatrix.GetLength(0); i++)
            {
                sb.Append("|");

                for (int j = 0; j < this.StoringMatrix.GetLength(1); j++)
                {
                    sb.AppendFormat("{0} ", this.StoringMatrix[i, j]);
                }

                sb.Length--;
                sb.AppendLine("|");
            }

            return sb.ToString().Trim();
        }
    }
}
