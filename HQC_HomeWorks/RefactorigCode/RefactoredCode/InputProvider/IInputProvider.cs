namespace MatrixWalk.InputProviders
{
    public interface IIOProvider
    {
        string Read();
        void Display(string stringToDisplay);
    }
}
