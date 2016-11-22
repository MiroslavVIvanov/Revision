namespace Exceptions_Homework
{
    using System;

    public class CSharpExam : Exam
    {
        private const int MinExamScore = 0;
        private const int MaxExamScore = 100;

        public CSharpExam(int score)
        {
            if (score < MinExamScore)
            {
                throw new ArgumentException(string.Format("Exam score can not be less than {0}!", MinExamScore));
            }

            if (score > MaxExamScore)
            {
                throw new ArgumentException(string.Format("Exam score can not be more than {0}!", MaxExamScore));
            }

            this.Score = score;
        }

        public int Score { get; private set; }

        public override ExamResult Check()
        {
            return new ExamResult(this.Score, MinExamScore, MaxExamScore, "Exam results calculated by score.");
        }
    }
}