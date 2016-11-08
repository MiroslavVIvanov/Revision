namespace SchoolSystem.Classes.Models
{
    using System.Collections.Generic;

    public class School
    {
        private ICollection<Class> classes;

        public School()
        {
            this.classes = new List<Class>();
        }

        public ICollection<Class> Classes
        {
            get
            {
                return this.classes;
            }
        }
    }
}
