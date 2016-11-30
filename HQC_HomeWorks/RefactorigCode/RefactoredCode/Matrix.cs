namespace MatrixWalk
{
    using System.Text;

    public class Matrix
    {
        private static readonly Direction[] Directions = new Direction[]
        {
            new Direction(1, 1),
            new Direction(1, 0),
            new Direction(1, -1),
            new Direction(0, -1),
            new Direction(-1, -1),
            new Direction(-1, 0),
            new Direction(-1, 1),
            new Direction(0, 1),
        };

        private int[,] matrix;

        public Matrix(int matrixSize)
        {
            this.matrix = new int[matrixSize, matrixSize];

            this.TraverseMatrix();
        }

        private int MatrixSize
        {
            get
            {
                return this.matrix.GetLength(0);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int row = 0; row < this.MatrixSize; row++)
            {
                for (int col = 0; col < this.MatrixSize; col++)
                {
                    sb.AppendFormat("{0,3}", this.matrix[row, col]);
                }

                sb.AppendLine();
            }

            return sb.ToString().TrimEnd();
        }

        private void TraverseMatrix()
        {
            int cellValue = 1;

            Position currentPosition = new Position(0, 0);
            Direction direction = Directions[0].Clone();

            while (cellValue <= this.MatrixSize * this.MatrixSize)
            {
                this.matrix[currentPosition.Row, currentPosition.Col] = cellValue;
                cellValue++;

                if (!this.IsNeighbouringCellAvailable(currentPosition))
                {
                    this.FindAvailableCell(currentPosition);
                    continue;
                }

                while (true)
                {
                    bool isDirectionRight = currentPosition.Row + direction.RowDirection < this.MatrixSize &&
                        currentPosition.Row + direction.RowDirection >= 0 &&
                        currentPosition.Col + direction.ColDirection < this.MatrixSize &&
                        currentPosition.Col + direction.ColDirection >= 0 &&
                        this.matrix[currentPosition.Row + direction.RowDirection,
                            currentPosition.Col + direction.ColDirection] == 0;

                    if (isDirectionRight)
                    {
                        break;
                    }

                    direction = this.ChangeToNextDirection(direction);
                }

                currentPosition.Row += direction.RowDirection;
                currentPosition.Col += direction.ColDirection;
            }
        }

        private bool IsNeighbouringCellAvailable(Position currentPosition)
        {
            for (int i = 0; i < Directions.Length; i++)
            {
                bool isNextRowInMatrix = currentPosition.Row + Directions[i].RowDirection < this.matrix.GetLength(0);
                bool isNextRowMoreThanZero = currentPosition.Row + Directions[i].RowDirection >= 0;

                bool isNextColInMatrix = currentPosition.Col + Directions[i].ColDirection < this.matrix.GetLength(1);
                bool isNextColMoreThanZero = currentPosition.Col + Directions[i].ColDirection >= 0;

                if (isNextRowMoreThanZero &&
                    isNextRowInMatrix &&
                    isNextColMoreThanZero &&
                    isNextColInMatrix &&
                    this.matrix[currentPosition.Row + Directions[i].RowDirection,
                    currentPosition.Col + Directions[i].ColDirection] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private Direction ChangeToNextDirection(Direction currentDirection)
        {
            int currentDirectionIndex = 0;
            for (int i = 0; i < Directions.Length; i++)
            {
                if (currentDirection == Directions[i])
                {
                    currentDirectionIndex = i;
                    break;
                }
            }

            if (currentDirectionIndex == Directions.Length - 1)
            {
                return Directions[0].Clone();
            }

            return Directions[currentDirectionIndex + 1].Clone();
        }

        private void FindAvailableCell(Position currentPosition)
        {
            currentPosition.Row = 0;
            currentPosition.Col = 0;

            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(0); j++)
                {
                    if (this.matrix[i, j] == 0)
                    {
                        currentPosition.Row = i;
                        currentPosition.Col = j;
                        return;
                    }
                }
            }
        }
    }
}