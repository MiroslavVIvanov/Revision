namespace DefiningClassesPart1
{
    using System.Text;
    using System.Collections.Generic;
    using System;

    public class GSM
    {
        private string model;
        private string manufacturer;
        private double? price;
        private string owner;
        private Battery battery;
        private Display display;
        private IList<Call> callHistory;

        public GSM(string model, string manufacturer)
        {
            this.callHistory = new List<Call>();
            this.Model = model;
            this.Manufacturer = manufacturer;
        }

        public GSM(string model,
            string manufacturer,
            double? price = null,
            string owner = null,
            Battery battery = null,
            Display display = null)
                : this(model, manufacturer)
        {
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                this.model = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            set
            {
                this.manufacturer = value;
            }
        }

        public double? Price
        {
            get
            {
                return this.price;
            }

            set
            {
                this.price = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }

            set
            {
                this.owner = value;
            }
        }

        public Battery Battery
        {
            get
            {
                return this.battery;
            }

            set
            {
                this.battery = value;
            }
        }

        public Display Display
        {
            get
            {
                return this.display;
            }

            set
            {
                this.display = value;
            }
        }

        public static string IPhone4S
        {
            get
            {
                GSM iPhone = new GSM("IPhone 4S", "Apple", 1300, "Pesho", new Battery("iPhone battery model", 30, 8), new Display(4, 16000000));
                return iPhone.ToString();
            }
        }

        public IList<Call> CallHistory
        {
            get
            {
                return this.callHistory;
            }

            set
            {
                this.callHistory = value;
            }
        }

        public void AddCall(Call newCall)
        {
            this.callHistory.Add(newCall);
        }

        public void AddCall(DateTime dateAndTimeOfCall,
            string dialedPhoneNumber,
            ushort durationOfCallInSeconds)
        {
            this.callHistory.Add(new Call(dateAndTimeOfCall, dialedPhoneNumber, durationOfCallInSeconds));
        }

        public void RemoveCall(Call callToBeRemoved)
        {
            this.CallHistory.Remove(callToBeRemoved);
        }

        public void ClearCallHistory()
        {
            this.callHistory = new List<Call>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("GSM manufacturer: " + this.Manufacturer);
            sb.AppendLine("GSM model: " + this.Model);

            if (this.Price != null)
            {
                sb.AppendLine("GSM price: " + this.Price);
            }
            else
            {
                sb.AppendLine("GSM price: Unknown");
            }

            if (this.Owner != null)
            {
                sb.AppendLine("GSM owner: " + this.Owner);
            }
            else
            {
                sb.AppendLine("GSM owner: Unknown");
            }

            if (this.Display != null)
            {
                sb.Append(this.Display.ToString());
            }
            else
            {
                sb.AppendLine("GSM display characteristics: Unknown");
            }

            if (this.Battery != null)
            {
                sb.Append(this.Battery.ToString());
            }
            else
            {
                sb.AppendLine("GSM battery characteristics: Unknown");
            }

            return sb.ToString().Trim();
        }
    }
}
