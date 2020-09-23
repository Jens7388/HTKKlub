using System;
using System.Runtime.Serialization;

namespace HTKKlub.Entities
{
    /// <summary>
    /// Exception for when an error occurs in a webservice
    /// </summary>
    [Serializable]
    public class WebServiceException : Exception
    {
        public WebServiceException()
        {
        }

        public WebServiceException(string message) : base(message)
        {
        }

        public WebServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WebServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
