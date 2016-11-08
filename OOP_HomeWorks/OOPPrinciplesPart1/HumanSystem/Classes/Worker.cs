namespace HumanSystem.Classes
{
    using System.Globalization;

    public class Worker : Human
    {
        private const byte TypicalWorkHoursPerDay = 8;
        private const byte TypicalWorkingDaysPerWeek = 5;

        public Worker(
            string firstName,
            string lastName,
            double weekSalary,
            byte workHoursPerDay = TypicalWorkHoursPerDay,
            byte workingDaysInWeek = TypicalWorkingDaysPerWeek)
                : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
            this.WorkingDaysInWeek = workingDaysInWeek;
        }

        public double WeekSalary { get; set; }

        public byte WorkHoursPerDay { get; set; }

        public byte WorkingDaysInWeek { get; set; }

        public double MoneyPerHour()
        {
            return this.WeekSalary / (this.WorkHoursPerDay * this.WorkingDaysInWeek);
        }

        public override string ToStringWithAdditionalInfo()
        {
            return this.ToString() + string.Format(new CultureInfo("en-US"), " - {0:C2}", this.MoneyPerHour());
        }
    }
}
