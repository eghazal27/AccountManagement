using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Service.Excpetions
{
    public class AccountManagementException : Exception
    {
        public AccountManagementException() { }
        public AccountManagementException(string message) : base(message) { }
        public AccountManagementException(string message, Exception inner) : base(message, inner) { }
        protected AccountManagementException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
