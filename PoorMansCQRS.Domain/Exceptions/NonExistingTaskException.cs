using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoorMansCQRS.Domain.Exceptions
{
    [Serializable]
    public class NonExistingTaskException : Exception
    {
        public NonExistingTaskException()
            : base()
        { }

        public NonExistingTaskException(string message)
            : base(message)
        { }

        public NonExistingTaskException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
