namespace ExceptionsTask
{
    using System;

    public class InvalidRangeException<T> : ArgumentException
    {
        public InvalidRangeException(string message, T start, T end)
           : base(message)
        {
            this.RangeStart = start;
            this.RangeEnd = end;
        }

        public T RangeStart { get; set; }

        public T RangeEnd { get; set; }
    }
}
