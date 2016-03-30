using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yayson
{
    public class JsonTokenFactory
    {
        public static JsonToken MakeToken(string s)
        {
            var c = s[0];
            if (char.IsNumber(c))
            {
                return JsonNumberFactory.MakeNumber(s) as JsonToken;
            }
            else if (c == '"')
            {
                return new JsonString(s.Substring(1, s.Length - 2)) as JsonToken;
            }
            else if (c == '[')
            {
                return new JsonList(s) as JsonToken;
            }
            else
            {
                return new JsonObject(s) as JsonToken;
            }
        }
    }
}
