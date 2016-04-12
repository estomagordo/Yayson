using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yayson
{
    public class JsonNull : JsonToken
    {
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
