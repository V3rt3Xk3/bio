using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bio.Exceptions
{
    /// <summary>
    /// This exception is responsible to be thrown, when a piece 
    /// of data is invalid, either object or a primitive.
    /// </summary>
    public class DataInvalidationException : Exception
    {
        public DataInvalidationException() { }
        public DataInvalidationException(string message) : base(message) { }
        public DataInvalidationException(string message, Exception innerException) : base(message, innerException) { }
    }
}
