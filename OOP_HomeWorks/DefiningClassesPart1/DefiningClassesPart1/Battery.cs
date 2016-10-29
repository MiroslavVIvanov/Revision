namespace DefiningClassesPart1
{
    public class Battery
    {
        private string model;
        private ushort hoursIdle;
        private ushort hoursTalk;
        public BatteryType batteryType;

        public Battery(): this("Unknown model", 0, 0)
        {
        }

        public Battery(string model, ushort hoursIdle, ushort hoursTalk)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.batteryType = BatteryType.Unknown;
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
    }
}
