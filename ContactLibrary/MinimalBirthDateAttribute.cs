using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask01
{
    [AttributeUsage(AttributeTargets.Property)]
    class MinimalBirthDateAttribute : System.Attribute
    {
        private int _Year;
        private int _Month;
        private int _Day;
        public MinimalBirthDateAttribute(int year, int month, int day)
        {
            _Year = year;
            _Month = month;
            _Day = day;
        }
        public int Year
        {
            get
            {
                return _Year;
            }
            set
            {
                _Year = value;
            }
        }
        public int Month
        {
            get
            {
                return _Month;
            }
            set
            {
                _Month = value;
            }
        }
        public int Day
        {
            get
            {
                return _Day;
            }
            set
            {
                _Day = value;
            }
        }
        
    }
}
