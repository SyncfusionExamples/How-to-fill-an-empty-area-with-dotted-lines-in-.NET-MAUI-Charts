using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmptyAreaSample
{
    public class Model
    {
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public double Value1 { get; set; }
        public Model(DateTime date, double value) 
        { 
            Date = date;
            Value = value;
            
        }
        public Model(double value1, double value)   
        {
            Value1 = value1;
            Value = value;
        }

    }
}
