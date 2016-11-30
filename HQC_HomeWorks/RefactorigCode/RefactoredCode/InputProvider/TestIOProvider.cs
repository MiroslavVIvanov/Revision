namespace MatrixWalk.InputProviders
{
    using System;

    public class TestIOProvider : IIOProvider
    {
        public TestIOProvider(string inputToProvide)
        {
            this.StringToProvide = inputToProvide;
        }

        public string StringToProvide { get; set; }

        public void Display(string stringToDisplay)
        {
            throw new NotImplementedException();
        }

        public string Read()
        {
            return this.StringToProvide;
        }
    }
}
