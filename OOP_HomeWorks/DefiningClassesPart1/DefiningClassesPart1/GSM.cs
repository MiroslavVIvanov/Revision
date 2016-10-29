//Problem 1. Define class
//Define a class that holds information about a mobile phone device: model, manufacturer, price, 
//owner, battery characteristics(model, hours idle and hours talk) and display 
//characteristics(size and number of colors).
//Define 3 separate classes(class GSM holding instances of the classes Battery and Display).

//Problem 2. Constructors
//Define several constructors for the defined classes that take different 
//sets of arguments(the full information for the class or part of it).
//Assume that model and manufacturer are mandatory(the others are optional). 
//All unknown data fill with null.

//Problem 3. Enumeration
//Add an enumeration BatteryType(Li-Ion, NiMH, NiCd, …) and use it as a new field for the batteries.

//Problem 4. ToString
//Add a method in the GSM class for displaying all information about it.
//Try to override ToString().

//Problem 5. Properties
//Use properties to encapsulate the data fields inside the GSM, Battery and Display classes.
//Ensure all fields hold correct data at any given time.

//Problem 6. Static field
//Add a static field and a property IPhone4S in the GSM class to hold the information about iPhone 4S.

//Problem 8. Calls
//Create a class Call to hold a call performed through a GSM.
//It should contain date, time, dialled phone number and duration (in seconds).

//Problem 9. Call history
//Add a property CallHistory in the GSM class to hold a list of the performed calls.
//Try to use the system class List<Call>.

//Problem 10. Add/Delete calls
//Add methods in the GSM class for adding and deleting calls from the calls history.
//Add a method to clear the call history.

//Problem 11. Call price
//Add a method that calculates the total price of the calls in the call history.
//Assume the price per minute is fixed and is provided as a parameter.

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

            private set
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

        public double CallHistoryTotalPrice(double callPricePerMinute)
        {
            int totalSeconds = 0;

            foreach (Call call in this.CallHistory)
            {
                totalSeconds += call.DurationInSec;
            }

            double totalMinutes = Math.Floor(totalSeconds / 60d) + 1;

            return totalMinutes * callPricePerMinute;
        }

        public string CallHistoryToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("------------------------------");
            foreach (var call in this.CallHistory)
            {
                sb.AppendLine(call.ToString());
            }
            sb.AppendLine("------------------------------");
            return sb.ToString().Trim();
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
