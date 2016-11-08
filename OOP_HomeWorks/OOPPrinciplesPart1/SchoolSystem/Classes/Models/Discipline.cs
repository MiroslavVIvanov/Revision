namespace SchoolSystem.Classes.Models
{
    using SchoolSystem.Intefaces;

    public class Discipline : ICommentContainer
    {
        public Discipline(string name, int numberOfLectures = 15, int numberOfExcersises = 15)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.NumberOfExcersises = numberOfExcersises;
        }

        public string Name { get; set; }

        public int NumberOfLectures { get; set; }

        public int NumberOfExcersises { get; set; }

        public string OptionalComment { get; set; }
    }
}
