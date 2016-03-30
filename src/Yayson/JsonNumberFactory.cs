using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yayson
{
    public class JsonNumberFactory
    {
        public static IJsonNumber MakeNumber(string s)
        {
            if (s.Contains('.'))
            {
                return new JsonDouble(s);
            }
            else
            {
                return new JsonInteger(s);
            }
        }
    }
}
