using NPOI.SS.Formula.Functions;
using PhoneBookWebApiCore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBookWebApiCore.Brokers.StorageBrokers
{
    public partial interface IStorageBroker
    {
        Task<Contact> InsertContactAsync(Contact contact);
        Task<List<Contact>> SelectAllContactsAsync();
        Task<Contact> SelectContactByIdAsync(Guid id);
        Task<Contact> UpdateContactAsync(Contact contact);
        Task<Contact> DeleteContactAsync(Contact contact);
    }
}
