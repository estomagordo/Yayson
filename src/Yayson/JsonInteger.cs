using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yayson
{
    public class JsonInteger : JsonToken, IJsonNumber
    {
        public int Value { get; set; }

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

        public JsonInteger(string s)
        {
            Value = int.Parse(s);
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