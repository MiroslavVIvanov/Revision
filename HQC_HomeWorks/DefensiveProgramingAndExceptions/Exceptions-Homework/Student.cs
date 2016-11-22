namespace Exceptions_Homework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        public Student(string firstName, string lastName, IList<Exam> exams)
        {
            this.ValidateFirstName(firstName);
            this.ValidateLastName(lastName);
            this.ValidateExams(exams);

            this.FirstName = firstName;
            this.LastName = lastName;
            this.Exams = exams;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IList<Exam> Exams { get; set; }

        public IList<ExamResult> CheckExams()
        {
            IList<ExamResult> results = new List<ExamResult>();
            for (int i = 0; i < this.Exams.Count; i++)
            {
                results.Add(this.Exams[i].Check());
            }

            return results;
        }

        public double CalcAverageExamResultInPercents()
        {
            double[] examScore = new double[this.Exams.Count];
            IList<ExamResult> examResults = this.CheckExams();
            for (int i = 0; i < examResults.Count; i++)
            {
                examScore[i] =
                    ((double)examResults[i].Grade - examResults[i].MinGrade) /
                    (examResults[i].MaxGrade - examResults[i].MinGrade);
            }

            return examScore.Average();
        }

        private void ValidateFirstName(string firstName)
        {
            if (firstName == null)
            {
                throw new ArgumentNullException("Students first name can not be null!");
            }
        }

        private void ValidateLastName(string lastName)
        {
            if (lastName == null)
            {
                throw new ArgumentNullException("Students last name can not be null!");
            }
        }

        private void ValidateExams(IList<Exam> exams)
        {
            if (exams == null)
            {
                throw new ArgumentNullException("Students exams can not be null!");
            }

            if (exams.Count == 0)
            {
                throw new ArgumentException("Students exams can not be empty!");
            }
        }
    }
}