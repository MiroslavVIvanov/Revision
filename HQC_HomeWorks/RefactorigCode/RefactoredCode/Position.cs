namespace MatrixWalk
{
    using System;

    public class Position
    {
        private int row;
        private int col;

        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row
        {
            get
            {
                return this.row;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Row can't be less than 0");
                }

                this.row = value;
            }
        }

        public int Col
        {
            get
            {
                return this.col;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Column can't be less than 0");
                }

                this.col = value;
            }
        }
    }
}