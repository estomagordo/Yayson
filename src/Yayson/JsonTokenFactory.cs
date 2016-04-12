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
            if (s.ToUpper() == "TRUE" || s.ToUpper() == "FALSE")
            {
                return new JsonBoolean(s);
            }
            else if (s.ToUpper() == "NULL")
            {
                return new JsonNull();
            }

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
