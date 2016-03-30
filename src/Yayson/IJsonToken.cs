using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yayson
{
    public abstract class JsonToken
    {
        public abstract JsonToken this[int index] { get; }
        
        public abstract JsonToken this[string key] { get; }
    }
}
