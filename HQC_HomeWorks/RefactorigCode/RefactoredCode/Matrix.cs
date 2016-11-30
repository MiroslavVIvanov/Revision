namespace MatrixWalk
{
    using System.Text;

    public class Matrix
    {
        private static readonly int[] rowDirections = new int[] { 1, 1, 1, 0, -1, -1, -1, 0 };
        private static readonly int[] colDirections = new int[] { 1, 0, -1, -1, -1, 0, 1, 1 };

        private int[,] matrix;

        public Matrix(int matrixSize)
        {
            this.matrix = new int[matrixSize, matrixSize];
        }

        public void ChangeToNextDirection(ref int currentRowDirection, ref int currentColDirection)
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

            if (currentDirectionIndex == rowDirections.Length - 1)
            {
                currentRowDirection = rowDirections[0];
                currentColDirection = colDirections[0];
                return;
            }

            currentRowDirection = rowDirections[currentDirectionIndex + 1];
            currentColDirection = colDirections[currentDirectionIndex + 1];
        }

        public bool IsNextCellAvailable(int currentRow, int currentCol)
        {
            for (int i = 0; i < rowDirections.Length; i++)
            {
                bool isNextRowInMatrix = currentRow + rowDirections[i] < this.matrix.GetLength(0);
                bool isNextRowMoreThanZero = currentRow + rowDirections[i] >= 0;

                bool isNextColInMatrix = currentCol + colDirections[i] < this.matrix.GetLength(1);
                bool isNextColMoreThanZero = currentCol + colDirections[i] >= 0;

                if (isNextRowMoreThanZero &&
                    isNextRowInMatrix &&
                    isNextColMoreThanZero &&
                    isNextColInMatrix &&
                    this.matrix[currentRow + rowDirections[i], currentCol + colDirections[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public void FindAvailableCell(out int currentRow, out int currentCol)
        {
            currentRow = 0;
            currentCol = 0;

            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(0); j++)
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

        public void TraverseMatrix()
        {
            int n = this.matrix.GetLength(0);
            int cellValue = 1;
            int currentRow = 0;
            int currentCol = 0;
            int currentRowDirection = 1;
            int currentColDirection = 1;

            while (true)
            {
                this.matrix[currentRow, currentCol] = cellValue;

                // check if there is free neighbour
                if (!this.IsNextCellAvailable(currentRow, currentCol))
                {
                    break;
                }

                // check if change direction is needed
                //if (currentRow + currentRowDirection >= n || 
                //    currentRow + currentRowDirection < 0 || 
                //    currentCol + currentColDirection >= n || 
                //    currentCol + currentColDirection < 0 || 
                //    matrix[currentRow + currentRowDirection, currentCol + currentColDirection] != 0)
                //{

                while ((currentRow + currentRowDirection >= n ||
                    currentRow + currentRowDirection < 0 ||
                    currentCol + currentColDirection >= n ||
                    currentCol + currentColDirection < 0 ||
                    matrix[currentRow + currentRowDirection, currentCol + currentColDirection] != 0))
                {
                    this.ChangeToNextDirection(ref currentRowDirection, ref currentColDirection);
                }
                //}

                currentRow += currentRowDirection;
                currentCol += currentColDirection;
                cellValue++;
            }

            this.FindAvailableCell(out currentRow, out currentCol);

            if (currentRow != 0 && currentCol != 0)
            {
                currentRowDirection = 1; currentColDirection = 1;

                while (true)
                {
                    matrix[currentRow, currentCol] = cellValue;

                    if (!this.IsNextCellAvailable(currentRow, currentCol))
                    {
                        break;
                    }

                    if (currentRow + currentRowDirection >= n || currentRow + currentRowDirection < 0 || currentCol + currentColDirection >= n || currentCol + currentColDirection < 0 || matrix[currentRow + currentRowDirection, currentCol + currentColDirection] != 0)
                    {
                        while ((currentRow + currentRowDirection >= n || currentRow + currentRowDirection < 0 || currentCol + currentColDirection >= n || currentCol + currentColDirection < 0 || matrix[currentRow + currentRowDirection, currentCol + currentColDirection] != 0))
                        {
                            this.ChangeToNextDirection(ref currentRowDirection, ref currentColDirection);
                        }
                    }

                    currentRow += currentRowDirection; currentCol += currentColDirection; cellValue++;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sb.AppendFormat("{0,3}", matrix[row, col]);
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}