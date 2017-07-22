using System;
using System.Runtime.Serialization;

namespace Model
{
    [Serializable]
    public class SenhaInvalidaException : Exception
    {
        public SenhaInvalidaException()
        {
        }

        public SenhaInvalidaException(string message) : base(message)
        {
        }

        public SenhaInvalidaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SenhaInvalidaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}