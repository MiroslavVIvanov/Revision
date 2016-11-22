namespace Exceptions_Homework
{
    using System;

    public class SimpleMathExam : Exam
    {
        private const int MaxNumberOfProblems = 10;
        private const int MinGrade = 2;
        private const int MaxGrade = 6;

        public SimpleMathExam(int problemsSolved)
        {
            this.ValidateNumberOfProblemsSolved(problemsSolved);

            this.ProblemsSolved = problemsSolved;
        }

        public int ProblemsSolved { get; private set; }

        public override ExamResult Check()
        {
            if (this.ProblemsSolved == 0)
            {
                return new ExamResult(2, MinGrade, MaxGrade, "Bad result: nothing done.");
            }
            else if (this.ProblemsSolved == 1)
            {
                return new ExamResult(4, MinGrade, MaxGrade, "Average result: nothing done.");
            }
            else
            {
                return new ExamResult(6, MinGrade, MaxGrade, "Average result: nothing done.");
            }
        }

        private void ValidateNumberOfProblemsSolved(int problemsSolved)
        {
            if (problemsSolved < 0)
            {
                throw new ArgumentException("Problems that are solved must be greater than 0!");
            }

            if (problemsSolved > MaxNumberOfProblems)
            {
                throw new ArgumentException(string.Format(
                    "Problems that are solved can not be more than {0}",
                    MaxNumberOfProblems));
            }
        }
    }
}