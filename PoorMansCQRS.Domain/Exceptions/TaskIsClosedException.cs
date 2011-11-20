using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoorMansCQRS.Domain.Exceptions
{
    [Serializable]
    public class TaskIsClosedException : Exception
    {
        public TaskIsClosedException()
            : base()
        { }

        public TaskIsClosedException(string message)
            : base(message)
        { }

        public TaskIsClosedException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
