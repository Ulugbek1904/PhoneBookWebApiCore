using PhoneBookWebApiCore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBookWebApiCore.Services
{
    public interface IContactService
    {
        Task<Contact> AddContactAsync(Contact contact);
        Task<List<Contact>> GetAllContactsAsync();
        Task<Contact> GetContactByIdAsync(Guid id);
        Task<Contact> UpdateContactAsync(Contact contact);
        Task<Contact> DeleteContactAsync(Contact contact);

    }
}