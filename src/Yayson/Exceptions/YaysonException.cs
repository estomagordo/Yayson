using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yayson.Exceptions
{ 
    public class YaysonException : Exception
    {
        public YaysonException()
        {

        }

        public YaysonException(string message)
        : base(message)
        {

        }

        public YaysonException(string message, Exception inner)
        : base(message, inner)
        {

        }
    }
}
