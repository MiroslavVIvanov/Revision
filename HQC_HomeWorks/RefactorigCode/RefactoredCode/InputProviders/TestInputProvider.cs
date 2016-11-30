namespace MatrixWalk.InputProviders
{
    public class TestInputProvider : IInputProvider
    {

        public TestInputProvider(string inputToProvide)
        {
            this.StringToProvide = inputToProvide;
        }

        public string StringToProvide { get; set; }

        public string Read()
        {
            return this.StringToProvide;
        }
    }
}
