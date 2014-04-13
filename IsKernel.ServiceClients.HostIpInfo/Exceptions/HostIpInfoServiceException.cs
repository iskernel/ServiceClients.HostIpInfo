using System;
using System.Linq;
using System.Runtime.Serialization;

namespace IsKernel.ServiceClients.HostIpInfo.Exceptions
{
    public class HostIpInfoServiceException : Exception, ISerializable
    {
        public HostIpInfoServiceException() : this(string.Empty, null)
        {
            
        }
        public HostIpInfoServiceException(string message) : this(message, null)
        {

        }
        public HostIpInfoServiceException(string message, Exception inner)
            : base(message, inner)
        {
            
        }

        protected HostIpInfoServiceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}
