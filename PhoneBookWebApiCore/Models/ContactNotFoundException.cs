using System;

namespace PhoneBookWebApiCore.Models
{
    public class ContactNotFoundException : Exception
    {
        public ContactNotFoundException(Guid id) :
            base($"Contact with ID {id} was not found")
        {
            
        }
    }
}
