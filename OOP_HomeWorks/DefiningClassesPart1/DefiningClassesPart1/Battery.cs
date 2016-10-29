using System;
using System.Text;

namespace DefiningClassesPart1
{
    public class Battery
    {
        private string model;
        private ushort hoursIdle;
        private ushort hoursTalk;
        private BatteryType batteryType;

        public Battery(): this("Unknown model", 0, 0)
        {
        }

        public Battery(string model, ushort hoursIdle, ushort hoursTalk)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.BatteryType = BatteryType.Unknown;
        }

        public Battery(string model, ushort hoursIdle, ushort hoursTalk, BatteryType type)
            : this(model, hoursIdle, hoursTalk)
        {
            this.BatteryType = type;
        }

        public string Model
        {
            get
            {
                return model;
            }

            set
            {
                model = value;
            }
        }

        public ushort HoursIdle
        {
            get
            {
                return hoursIdle;
            }

            set
            {
                hoursIdle = value;
            }
        }

        public ushort HoursTalk
        {
            get
            {
                return hoursTalk;
            }

            set
            {
                hoursTalk = value;
            }
        }

        public BatteryType BatteryType
        {
            get
            {
                return batteryType;
            }

            set
            {
                batteryType = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Battery model: {0}" + Environment.NewLine, this.Model);

            if (this.HoursIdle != 0)
            {
                sb.AppendFormat("Battery hours idle: {0}" + Environment.NewLine, this.HoursIdle);
            }
            else
            {
                sb.AppendLine("Battery hours idle: Unknown");
            }

            if (this.HoursTalk!= 0)
            {
                sb.AppendFormat("Battery hours talk: {0}" + Environment.NewLine, this.HoursTalk);
            }
            else
            {
                sb.AppendLine("Battery hours talk: Unknown");
            }

            return sb.ToString();
        }
    }
}
