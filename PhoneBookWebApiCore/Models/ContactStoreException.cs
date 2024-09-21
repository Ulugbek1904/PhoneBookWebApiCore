using System;

namespace PhoneBookWebApiCore.Models
{
    public class ContactStoreException : Exception
    {
        public ContactStoreException(string message, Exception exception) : base(message, exception)
        {

        }
        
    }
}
