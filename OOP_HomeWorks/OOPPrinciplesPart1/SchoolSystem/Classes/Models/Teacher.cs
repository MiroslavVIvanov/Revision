namespace SchoolSystem.Classes.Models
{
    using System;
    using System.Collections.Generic;
    using Intefaces;

    public class Teacher : Person, ICommentContainer
    {
        private ICollection<Discipline> disciplines;

        public Teacher(string name) 
            : base(name)
        {
            this.disciplines = new List<Discipline>();
        }

        public string OptionalComment { get; set; }

        public ICollection<Discipline> Disciplines
        {
            get
            {
                return this.disciplines;
            }
        }

        public void AddDiscipline(Discipline disciplineToAdd)
        {
            if (disciplineToAdd == null)
            {
                throw new ArgumentException();
            }

            this.disciplines.Add(disciplineToAdd);
        }

        public void RemoveDiscipline(Discipline disciplineToRemove)
        {
            if (disciplineToRemove == null)
            {
                throw new ArgumentException();
            }

            this.disciplines.Remove(disciplineToRemove);
        }
    }
}
