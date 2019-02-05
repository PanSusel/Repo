using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ćwiczenie
{
    public struct Time : IEquatable<Time>, IComparable<Time>
    {
        private readonly byte _hours;
        private readonly byte _minutes;
        private readonly byte _seconds;
        private readonly long _miliseconds;

        public byte Hours { get { return _hours; } } 
        public byte Minutes { get { return _minutes; } } 
        public byte Seconds { get { return _seconds; } } 
        public long Miliseconds { get { return _miliseconds; } } 
        
        public Time (byte hours , byte minutes , byte seconds , long miliseconds) : this()
        {
            _hours = hours;
            _minutes = minutes;
            _seconds = seconds;
            _miliseconds = miliseconds;
        }
        public Time (byte hours, byte minutes, byte seconds) : this()
        {
            _hours = hours;
            _minutes = minutes;
            _seconds = seconds;
            _miliseconds = 0;
        }

        public Time(byte hours, byte minutes) : this()
        {
            _hours = hours;
            _minutes = minutes;
            _seconds = 0;
            _miliseconds = 0;
        }

        public Time(byte hours) : this()
        {
            _hours = hours;
            _minutes = 0;
            _seconds = 0;
            _miliseconds = 0;
        }

        public Time(string tekst) :this()
        {
           string[] tabTime = tekst.Split(':');
            if(tabTime.Length != 4)
            {
                throw new ArgumentException(message:"Zły format");
            }

            _hours = byte.Parse(tabTime[0]);
            _minutes = Convert.ToByte(tabTime[1]);
            _seconds = Convert.ToByte(tabTime[2]);
            _miliseconds = Convert.ToUInt16(tabTime[3]);
            TestValues();

        }

        private void TestValues()
        {
            if (Hours > 23)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (Minutes > 59)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (Seconds > 59)
            {
                throw new ArgumentOutOfRangeException();
            }
            if(Miliseconds > 999)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public bool Equals(Time other) //czy zmienne struktury są sobie równe
        {
            return this.Zwrócenie_Milisekund() == other.Zwrócenie_Milisekund();
        }

        public int CompareTo(Time other)
        {
            var timeThis = this.Zwrócenie_Milisekund();
            var timeOther = other.Zwrócenie_Milisekund();
            return timeThis.CompareTo(timeOther);
        }

        private long Zwrócenie_Milisekund()
        {
            return ((((Hours * 60) + Minutes) * 60 + Seconds) * 1000 + Miliseconds); //Przelicza czas na milisekundy
        }

        public override string ToString()
        {
            return Hours + ":" + Minutes + ":" + Seconds + ":" + Miliseconds;
        }

        private static Time SetTimeFromMilis(long milis)
        {
            var miliseconds = milis % 1000;
            var tempSeconds = milis / 1000;
            var seconds = (byte)(tempSeconds % 60);
            var tempMinutes = tempSeconds / 60;
            var minutes = (byte)(tempMinutes % 60);
            var tempHours = tempMinutes / 60;
            var hours = (byte)(tempHours % 24);
            return new Time(hours, minutes, seconds, miliseconds);

        }
        public Time Plus(Time time)
        {
            return Plus(time.Hours, time.Minutes, time.Seconds, time.Miliseconds);
            
        }

        public Time Plus(byte hour, byte minute, byte second, long miliseconds)
        {
            
        }
    }
}
