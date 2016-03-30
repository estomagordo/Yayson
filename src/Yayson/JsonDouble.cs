using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yayson
{
    public class JsonDouble : JsonToken, IJsonNumber
    {
        public double Value {get; set;}

        public string StringValue
        {
            get
            {
                return Value.ToString();
            }
        }

        public override string ToString()
        {
            return StringValue;
        }

        public JsonDouble(string s)
        {
            Value = double.Parse(s, System.Globalization.CultureInfo.InvariantCulture);
        }

        public override JsonToken this[int index]
        {
            get
            {
                return this;
            }            
        }

        public override JsonToken this[string key]
        {
            get
            {
                return this;
            }
        }
    }
}
