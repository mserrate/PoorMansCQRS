using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoorMansCQRS.Domain.Exceptions
{
    [Serializable]
    public class InvalidDeliveryDateException : Exception
    {
        public InvalidDeliveryDateException()
            : base()
        { }

        public InvalidDeliveryDateException(string message)
            : base(message)
        { }

        public InvalidDeliveryDateException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
