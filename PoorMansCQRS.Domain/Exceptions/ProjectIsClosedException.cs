using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoorMansCQRS.Domain.Exceptions
{
    [Serializable]
    public class ProjectIsClosedException : Exception
    {
        public ProjectIsClosedException()
            : base()
        { }

        public ProjectIsClosedException(string message)
            : base(message)
        { }

        public ProjectIsClosedException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
