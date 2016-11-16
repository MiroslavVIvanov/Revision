// class Hauptklasse
// {
//     enum Пол { ултра_Батка, Яка_Мацка };
//     class чуек
//     {
//         public Пол пол { get; set; }
//         public string име_на_Чуека { get; set; }
//         public int Възраст { get; set; }
//     }
//     public void Make_Чуек(int магическия_НомерНаЕДИНЧОВЕК)
//     {
//         чуек new_Чуек = new чуек();
//         new_Чуек.Възраст = магическия_НомерНаЕДИНЧОВЕК;
//         if (магическия_НомерНаЕДИНЧОВЕК % 2 == 0)
//         {
//             new_Чуек.име_на_Чуека = "Батката";
//             new_Чуек.пол = Пол.ултра_Батка;
//         }
//         else
//         {
//             new_Чуек.име_на_Чуека = "Мацето";
//             new_Чуек.пол = Пол.Яка_Мацка;
//         }
//     }
// } 

namespace PersonClass
{
    public class Person
    {
        public Person(int age, string name)
        {
            this.Age = age;
            if (age % 2 == 0)
            {
                this.Name = name;
                this.Gender = Gender.Male;
            }
            else
            {
                this.Name = name;
                this.Gender = Gender.Female;
            }
        }

        public Gender Gender { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
