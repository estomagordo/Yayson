using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yayson
{
    public class JsonList : JsonToken, IJsonCollection
    {
        public List<JsonToken> Contents { get; set; }

        public bool IsStopper(char c)
        {
            return c == ']';
        }

        public string Key { get; set; }    

        public int GetCount()
        {
            return Contents.Count;
        }

        public override JsonToken this[int index]
        {
            get
            {
                return Contents[index];
            }            
        }        

        public override JsonToken this[string key]
        {
            get
            {
                return this;
            }
        }

        public JsonList()
        {
            Contents = new List<JsonToken>();
            Key = string.Empty;
        }

        public JsonList(string s)
        {
            Contents = new List<JsonToken>();
        }

        public void Add(string key, JsonToken value)
        {
            Contents.Add(value);
        }
    }
}
