namespace MatrixWalk.InputProviders
{
    using System;

    public class ConsoleInputProvider : IInputProvider
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
