namespace BitArrayTestApplication
{
    using System;
    using BitArray;

    public class Startup
    {
        public static void Main()
        {
            BitArray64 bitArray = new BitArray64();
            BitArray64 anotherBitArr = new BitArray64();

            Console.WriteLine(bitArray == anotherBitArr);

            bitArray[13] = 1;
            bitArray[23] = 1;
            bitArray[33] = 1;
            bitArray[43] = 1;
            bitArray[53] = 1;
            bitArray[63] = 1;

            Console.WriteLine(bitArray == anotherBitArr);

            Console.WriteLine(bitArray.ToString());

            foreach (var bit in bitArray)
            {
                Console.WriteLine(bit);
            }
        }
    }
}
