using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yayson
{
    public class JsonBoolean : JsonToken
    {
        public bool Value { get; set; }

        public JsonBoolean(string s)
        {
            Value = bool.Parse(s);
        }

        public override string ToString()
        {
            return Value.ToString();
        }    

        public override JsonToken this[string key]
        {
            get
            {
                return this;
            }
        }

        public override JsonToken this[int index]
        {
            get
            {
                return this;
            }
        }
    }
}
