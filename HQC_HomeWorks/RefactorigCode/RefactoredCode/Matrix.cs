namespace MatrixWalk
{
    using System;

    public class Matrix
    {
        private static readonly int[] rowDirections = new int[] { 1, 1, 1, 0, -1, -1, -1, 0 };
        private static readonly int[] colDirections = new int[] { 1, 0, -1, -1, -1, 0, 1, 1 };

        public static void ChangeDirection(ref int currentRowDirection, ref int currentColDirection)
        {
            int currentDirectionIndex = 0;
            for (int i = 0; i < rowDirections.Length; i++)
            {
                if (rowDirections[i] == currentRowDirection && colDirections[i] == currentColDirection)
                {
                    currentDirectionIndex = i;
                    break;
                }
            }

            if (currentDirectionIndex == rowDirections.Length)
            {
                currentRowDirection = rowDirections[0];
                currentColDirection = colDirections[0];
                return;
            }

            currentRowDirection = rowDirections[currentDirectionIndex + 1];
            currentColDirection = colDirections[currentDirectionIndex + 1];
        }

        public static bool IsNextCellAvailable(int[,] matrix, int currentRow, int currentCol)
        {
            for (int i = 0; i < 8; i++)
            {
                if (currentRow + rowDirections[i] >= matrix.GetLength(0) || currentRow + rowDirections[i] < 0)
                {
                    rowDirections[i] = 0;
                }

                if (currentCol + colDirections[i] >= matrix.GetLength(0) || currentCol + colDirections[i] < 0)
                {
                    colDirections[i] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (matrix[currentRow + rowDirections[i], currentCol + colDirections[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public static void FindAvailableCell(int[,] matrix, out int currentRow, out int currentCol)
        {
            currentRow = 0;
            currentCol = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        currentRow = i;
                        currentCol = j;
                        return;
                    }
                }
            }
        }

        public static void TraverseMatrix(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int step = n, k = 1, i = 0, j = 0, dx = 1, dy = 1;

            while (true)
            { //malko e kofti tova uslovie, no break-a raboti 100% : )
                matrix[i, j] = k;

                if (!Matrix.IsNextCellAvailable(matrix, i, j)) { break; } // prekusvame ako sme se zadunili
                if (i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrix[i + dx, j + dy] != 0)


                    while ((i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrix[i + dx, j + dy] != 0)) { Matrix.ChangeDirection(ref dx, ref dy); }
                i += dx; j += dy; k++;
            }

            Matrix.FindAvailableCell(matrix, out i, out j);
            if (i != 0 && j != 0)
            { // taka go napravih, zashtoto funkciqta ne mi davashe da ne si definiram out parametrite
                dx = 1; dy = 1;

                while (true)
                { //malko e kofti tova uslovie, no break-a raboti 100% : )
                    matrix[i, j] = k;
                    if (!Matrix.IsNextCellAvailable(matrix, i, j)) { break; }// prekusvame ako sme se zadunili
                    if (i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrix[i + dx, j + dy] != 0)


                        while ((i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrix[i + dx, j + dy] != 0)) Matrix.ChangeDirection(ref dx, ref dy);
                    i += dx; j += dy; k++;
                }
            }
        }


        public static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0,3}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
