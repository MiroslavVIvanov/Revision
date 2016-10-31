namespace GenericClass
{
    public class Program
    {
        public static void Main()
        {
            GenericList<string> list = new GenericList<string>();

            list.Add("Pesho");
            list.Add("Pesho");
            list.Add("Penka");

            System.Console.WriteLine("count - {0}", list.Count);
            System.Console.WriteLine("capacity - {0}", list.Capacity);

            System.Console.WriteLine(list[2]);
        }
    }
}
