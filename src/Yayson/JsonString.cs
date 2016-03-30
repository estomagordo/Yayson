using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yayson
{
    public class JsonString : JsonToken
    {
        public string Value { get; set; }

        public JsonString(string s)
        {
            Value = s;
        }

        public override string ToString()
        {
            return Value;
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
