using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yayson
{
    public interface IJsonCollection
    {
        bool IsStopper(char c);
        int GetCount();
        void Add(string key, JsonToken value);
        string Key { get; set; }
    }
}
