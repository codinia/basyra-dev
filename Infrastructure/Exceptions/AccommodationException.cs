using Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Infrastructure.Exceptions
{
    [Serializable]
    public class AccommodationException : Exception
    {
        public AccommodationException()
       : base() { }

        public AccommodationException(ErrorMessages message)
            : base(message.ToString()) { }

        public AccommodationException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public AccommodationException(string message, Exception innerException)
            : base(message, innerException) { }

        public AccommodationException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }

        protected AccommodationException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
