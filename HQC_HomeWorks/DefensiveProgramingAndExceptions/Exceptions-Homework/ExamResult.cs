namespace Exceptions_Homework
{
    using System;

    public class ExamResult
    {
        private const int MinGradeValue = 0;

        public ExamResult(int grade, int minGrade, int maxGrade, string comments)
        {
            this.ValidateGrade(grade, minGrade);
            this.ValidateMinAndMaxGrade(minGrade, maxGrade);
            this.ValidateComments(comments);

            this.Grade = grade;
            this.MinGrade = minGrade;
            this.MaxGrade = maxGrade;
            this.Comments = comments;
        }

        public int Grade { get; private set; }

        public int MinGrade { get; private set; }

        public int MaxGrade { get; private set; }

        public string Comments { get; private set; }

        private void ValidateGrade(int grade, int minGrade)
        {
            if (grade < minGrade)
            {
                throw new ArgumentException(string.Format("Exam grade can not be less than {0}!", minGrade));
            }
        }

        private void ValidateMinAndMaxGrade(int minGrade, int maxGrade)
        {
            if (minGrade < MinGradeValue)
            {
                throw new ArgumentException(string.Format("Min grade can not be less than {0}!", MinGradeValue));
            }

            if (maxGrade <= minGrade)
            {
                throw new ArgumentException("Max grade must be greater than min grade!");
            }
        }

        private void ValidateComments(string comments)
        {
            if (comments == null)
            {
                throw new ArgumentNullException("Comment can not be null!");
            }

            if (comments == string.Empty)
            {
                throw new ArgumentNullException("Comment can not be empty!");
            }
        }
    }
}