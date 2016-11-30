namespace MatrixWalk.InputProviders
{
    using System;

    public class ConsoleIOProvider : IIOProvider
    {
        public void Display(string stringToDisplay)
        {
            Console.WriteLine(stringToDisplay);
        }

        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
