namespace MatrixWalk
{
    using System.Text;

    public class Matrix
    {
        private static readonly Direction[] directions = new Direction[] {
            new Direction(1, 1),
            new Direction(1, 0),
            new Direction(1, -1),
            new Direction(0, -1),
            new Direction(-1, -1),
            new Direction(-1, 0),
            new Direction(-1, 1),
            new Direction(0, 1),
        };

        //private static readonly int[] rowDirections = new int[] { 1, 1, 1, 0, -1, -1, -1, 0 };
        //private static readonly int[] colDirections = new int[] { 1, 0, -1, -1, -1, 0, 1, 1 };

        private int[,] matrix;

        public Matrix(int matrixSize)
        {
            this.matrix = new int[matrixSize, matrixSize];
        }

        public int MatrixSize
        {
            get
            {
                return this.matrix.GetLength(0);
            }
        }

        public Direction ChangeToNextDirection(Direction currentDirection)
        {
            int currentDirectionIndex = 0;
            for (int i = 0; i < directions.Length; i++)
            {
                if (currentDirection == directions[i])
                {
                    currentDirectionIndex = i;
                    break;
                }
            }

            if (currentDirectionIndex == directions.Length - 1)
            {
                return directions[0].Clone();
            }

            return directions[currentDirectionIndex + 1].Clone();
        }

        public bool IsNextCellAvailable(Position currentPosition)
        {
            for (int i = 0; i < directions.Length; i++)
            {
                bool isNextRowInMatrix = currentPosition.Row + directions[i].RowDirection < this.matrix.GetLength(0);
                bool isNextRowMoreThanZero = currentPosition.Row + directions[i].RowDirection >= 0;

                bool isNextColInMatrix = currentPosition.Col + directions[i].ColDirection < this.matrix.GetLength(1);
                bool isNextColMoreThanZero = currentPosition.Col + directions[i].ColDirection >= 0;

                if (isNextRowMoreThanZero &&
                    isNextRowInMatrix &&
                    isNextColMoreThanZero &&
                    isNextColInMatrix &&
                    this.matrix[currentPosition.Row + directions[i].RowDirection, 
                    currentPosition.Col + directions[i].ColDirection] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public void FindAvailableCell(Position currentPosition)
        {
            currentPosition.Row = 0;
            currentPosition.Col = 0;

            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(0); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        currentPosition.Row = i;
                        currentPosition.Col = j;
                        return;
                    }
                }
            }
        }

        public void TraverseMatrix()
        {
            int cellValue = 1;

            Position currentPosition = new Position(0, 0);
            Direction direction = directions[0].Clone();

            //int currentRowDirection = 1;
            //int currentColDirection = 1;

            while (cellValue <= this.MatrixSize * this.MatrixSize)
            {
                this.matrix[currentPosition.Row, currentPosition.Col] = cellValue;
                cellValue++;

                if (!this.IsNextCellAvailable(currentPosition))
                {
                    this.FindAvailableCell(currentPosition);
                    continue;
                }


                while (true)
                {
                    bool check = currentPosition.Row + direction.RowDirection >= this.MatrixSize ||
                        currentPosition.Row + direction.RowDirection < 0 ||
                        currentPosition.Col + direction.ColDirection >= this.MatrixSize ||
                        currentPosition.Col + direction.ColDirection < 0 ||
                        matrix[currentPosition.Row + direction.RowDirection, currentPosition.Col + direction.ColDirection] != 0;

                    if (!check)
                    {
                        break;
                    }
                    direction = this.ChangeToNextDirection(direction);
                }

                currentPosition.Row += direction.RowDirection;
                currentPosition.Col += direction.ColDirection;
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

            return sb.ToString().TrimEnd();
        }
    }
}