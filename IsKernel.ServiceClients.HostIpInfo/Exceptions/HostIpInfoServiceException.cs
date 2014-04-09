using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
