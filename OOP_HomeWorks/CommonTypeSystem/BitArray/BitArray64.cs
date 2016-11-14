namespace BitArray
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// BitArray64 stores 64 bit values.
    /// </summary>
    public class BitArray64 : IEnumerable, IEnumerable<int>
    {
        private ulong arrayValueAsUlong;

        public BitArray64()
        {
            this.arrayValueAsUlong = 0;
        }

        /// <summary>
        /// Gets or sets bit (0 or 1) at given position.
        /// </summary>
        /// <param name="index">Zero based position (between 0 and 63)</param>
        /// <returns></returns>
        public int this[int index]
        {
            get
            {
                if (index < 0 || index > 63)
                {
                    throw new ArgumentException("Index can be between 0 and 63");
                }

                ulong bit = (this.arrayValueAsUlong & ((ulong)1 << index)) >> index;
                return Convert.ToInt32(bit);
            }

            set
            {
                if (index < 0 || index > 63)
                {
                    throw new ArgumentException("Index can be between 0 and 63");
                }

                if (value == 0)
                {
                    this.arrayValueAsUlong &= ~((ulong)1 << index);
                }
                else if (value == 1)
                {
                    this.arrayValueAsUlong |= (ulong)1 << index;
                }
                else
                {
                    throw new ArgumentException("Bit must be 0 or 1");
                }
            }
        }

        /// <summary>
        /// Implementation of equals operator
        /// </summary>
        /// <param name="firstArray">First BitArray64 parametar</param>
        /// <param name="secondArray">Second BitArray64 parametar</param>
        /// <returns>True if all bits match, false if at least one bit does not match</returns>
        public static bool operator ==(BitArray64 firstArray, BitArray64 secondArray)
        {
            return firstArray.Equals(secondArray);
        }

        /// <summary>
        /// Implementation of not equals operator
        /// </summary>
        /// <param name="firstArray">First BitArray64 parametar</param>
        /// <param name="secondArray">Second BitArray64 parametar</param>
        /// <returns>False if all bits match, true if at least one bit does not match</returns>
        public static bool operator !=(BitArray64 firstArray, BitArray64 secondArray)
        {
            return !firstArray.Equals(secondArray);
        }

        /// <summary>
        /// Left to right string representation of the BitArray64
        /// </summary>
        /// <returns>String of all 64 bits (most left bit has index 0)</returns>
        public override string ToString()
        {
            ulong value = this.arrayValueAsUlong;

            if (value == 0)
            {
                return new string('0', 64);
            }

            StringBuilder sb = new StringBuilder();
            while (value != 0)
            {
                sb.Append(((value & 1) == 1) ? '1' : '0');
                value >>= 1;
            }

            sb.Append(new string('0', 64 - sb.Length));
            return sb.ToString().Trim();
        }

        /// <summary>
        /// Check if all the bits in the two BitArray64 variables match.
        /// </summary>
        /// <param name="obj">Object convetible to BitArray64</param>
        /// <returns>True if all bits match, false if at least one bit does not match</returns>
        public override bool Equals(object obj)
        {
            if (obj is BitArray64)
            {
                BitArray64 temp = obj as BitArray64;
                if (this.arrayValueAsUlong == temp.arrayValueAsUlong)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Generation of pseudo unique hash code
        /// </summary>
        /// <returns>Pseudo unique hash code for the current instance of BitArray64 object</returns>
        public override int GetHashCode()
        {
            int result = 1;

            var bytes = BitConverter.GetBytes(this.arrayValueAsUlong);
            for (int i = 0; i < bytes.Length; i++)
            {
                result ^= bytes[i];
            }

            return base.GetHashCode() ^ result;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < 64; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < 64; i++)
            {
                yield return this[i];
            }
        }
    }
}
