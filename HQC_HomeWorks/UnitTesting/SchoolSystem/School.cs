namespace StudentSystem
{
    using System;

    public class School
    {
        private const int InitialStudentNumber = 10000;
        private const int MaxStudentNumber = 99999;

        private int studentUniqueNumber = InitialStudentNumber;

        public int GenerateStudenUniquetNumber()
        {
            this.studentUniqueNumber++;

            if (this.studentUniqueNumber > MaxStudentNumber)
            {
                throw new ArgumentOutOfRangeException("Unique number generator overflowed");
            }

            return this.studentUniqueNumber;
        }
    }
}
