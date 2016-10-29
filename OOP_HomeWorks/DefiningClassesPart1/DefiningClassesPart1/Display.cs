namespace DefiningClassesPart1
{
    using System.Text;

    public class Display
    {
        private ushort size;
        private uint colors;

        public Display() : this(0, 0)
        {
        }

        public Display(ushort size, uint colors)
        {
            this.Size = size;
            this.Colors = colors;
        }

        public ushort Size
        {
            get
            {
                return size;
            }

            set
            {
                size = value;
            }
        }

        public uint Colors
        {
            get
            {
                return colors;
            }

            set
            {
                colors = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this.Size != 0)
            {
                sb.AppendLine("Display size: " + this.Size);
            }
            else
            {
                sb.AppendLine("Display size: Unknown");
            }

            if (this.Colors != 0)
            {
                sb.AppendLine("Display number of colors: " + this.Colors);
            }
            else
            {
                sb.AppendLine("Display number of colors: Unknown");
            }

            return sb.ToString();
        }
    }
}
