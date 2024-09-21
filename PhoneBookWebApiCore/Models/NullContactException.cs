using System;

namespace PhoneBookWebApiCore.Models
{
    public class NullContactException : Exception
    {
        public NullContactException(string message) : base(message)
        {

        }
        
    }
}
