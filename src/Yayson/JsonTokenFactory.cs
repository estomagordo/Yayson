using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yayson.Exceptions;

namespace Yayson
{
    public class JsonTokenFactory
    {
        public static JsonToken MakeToken(string s)
        {
            if (s.ToUpper() == "TRUE" || s.ToUpper() == "FALSE")
            {
                if (s == "true" || s == "false")
                {
                    return new JsonBoolean(s);
                }
                throw new YaysonException("Boolean must be strictly lower case.");                
            }
            else if (s.ToUpper() == "NULL")
            {
                if (s == "null")
                {
                    return new JsonNull();
                }
                throw new YaysonException("Null must be strictly lower case.");
            }

            var c = s[0];
            if (char.IsNumber(c) || c == '-')
            {
                try
                {
                    return JsonNumberFactory.MakeNumber(s) as JsonToken;
                }
                catch(Exception e)
                {
                    throw new YaysonException("Illegal number format.", e);
                }
            }            
            else if (c == '"')
            {
                return new JsonString(s.Substring(1, s.Length - 2)) as JsonToken;
            }
            else if (c == '[')
            {
                return new JsonList(s) as JsonToken;
            }
            else if (c == '{')
            {
                return new JsonObject(s) as JsonToken;
            }
            throw new YaysonException("Unknown Json token.");
        }
    }
}
