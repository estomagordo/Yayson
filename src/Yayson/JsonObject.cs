using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yayson
{
    public class JsonObject : JsonToken, IJsonCollection
    {
        public bool KeyDone { get; set; }
        public bool InKey { get; set; }
        public bool InValue { get; set; }
        public string Key { get; set; }
        public Dictionary<string,JsonToken> Contents { get; set; }

        public bool IsStopper(char c)
        {
            return c == '}';
        }

        public int GetCount()
        {
            return Contents.Count;
        }

        public override JsonToken this[string name]
        {
            get
            {
                return Contents[name];
            }            
        }

        public override JsonToken this[int index]
        {
            get
            {
                return this;
            }
        }       

        public JsonObject()
        {
            KeyDone = false;
            InKey = false;
            InValue = false;
            Contents = new Dictionary<string, JsonToken>();
        }

        public JsonObject(string s)
        {
            KeyDone = false;
            InKey = false;
            InValue = false;
            Contents = new Dictionary<string, JsonToken>();
        }

        public void Add(string key, JsonToken value)
        {
            Contents[key] = value;
        }
    }
}
