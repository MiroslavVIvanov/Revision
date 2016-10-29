namespace DefiningClassesPart1
{
    using System;
    using System.Text;

    public class Call
    {
        private DateTime dateTime;
        private string dialedPhoneNumber;
        private ushort durationInSec;

        public Call(DateTime dateAndTimeOfCall, 
                    string dialedPhoneNumber, 
                    ushort durationOfCallInSeconds)
        {
            this.DateAndTime = dateAndTimeOfCall;
            this.DialedPhoneNumber = dialedPhoneNumber;
            this.DurationInSec = durationOfCallInSeconds;
        }

        public DateTime DateAndTime
        {
            get
            {
                return this.dateTime;
            }

            set
            {
                this.dateTime = value;
            }
        }

        public string DialedPhoneNumber
        {
            get
            {
                return dialedPhoneNumber;
            }

            set
            {
                dialedPhoneNumber = value;
            }
        }

        public ushort DurationInSec
        {
            get
            {
                return durationInSec;
            }

            set
            {
                durationInSec = value;
            }
        }

        public static bool operator ==(Call call1, Call call2)
        {
            if (call1.DateAndTime == call2.DateAndTime
                && call1.DurationInSec== call2.DurationInSec
                && call1.DialedPhoneNumber == call2.DialedPhoneNumber)
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(Call call1, Call call2)
        {
            if (call1.DateAndTime != call2.DateAndTime
                || call1.DurationInSec != call2.DurationInSec
                || call1.DialedPhoneNumber != call2.DialedPhoneNumber)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Call made on {0:dd/MM/yy}, at {0:H/mm/ss}, to {1}, with duration of {2} seconds.",
                this.DateAndTime,
                this.DialedPhoneNumber,
                this.DurationInSec);

            return sb.ToString();
        }
    }
}
