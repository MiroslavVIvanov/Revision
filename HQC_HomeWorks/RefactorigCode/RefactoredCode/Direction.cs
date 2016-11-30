namespace MatrixWalk
{
    using System;

    public class Direction
    {
        private int rowDirection;
        private int colDirection;

        public Direction(int rowDirection, int columnDirection)
        {
            this.RowDirection = rowDirection;
            this.ColDirection = columnDirection;
        }

        public int RowDirection
        {
            get
            {
                return this.rowDirection;
            }

            set
            {
                if (value < -1 || value > 1)
                {
                    throw new ArgumentOutOfRangeException("Row direction step can't be less -1 and more than 1");
                }

                this.rowDirection = value;
            }
        }

        public int ColDirection
        {
            get
            {
                return this.colDirection;
            }

            set
            {
                if (value < -1 || value > 1)
                {
                    throw new ArgumentOutOfRangeException("Column direction step can't be less -1 and more than 1");
                }

                this.colDirection = value;
            }
        }

        public static bool operator ==(Direction firstDirection, Direction secondDirection)
        {
            if (firstDirection.RowDirection == secondDirection.RowDirection &&
                firstDirection.ColDirection == secondDirection.ColDirection)
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(Direction firstDirection, Direction secondDirection)
        {
            return !(firstDirection == secondDirection);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (this == obj as Direction)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Direction Clone()
        {
            return new Direction(this.RowDirection, this.ColDirection);
        }
    }
}