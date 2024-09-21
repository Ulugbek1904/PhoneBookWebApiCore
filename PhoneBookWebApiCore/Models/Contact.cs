using System;

namespace PhoneBookWebApiCore.Models
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
