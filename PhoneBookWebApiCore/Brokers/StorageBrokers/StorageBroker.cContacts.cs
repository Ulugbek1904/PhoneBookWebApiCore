using System;
using Microsoft.EntityFrameworkCore;
using PhoneBookWebApiCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBookWebApiCore.Brokers.StorageBrokers
{
    public partial class StorageBroker
    {
        public DbSet<Contact> Contacts { get; set; }
        public async Task<Contact> InsertContactAsync(Contact contact) =>
            await InsertAsync(contact);

        public async Task<List<Contact>> SelectAllContactsAsync() =>
        await SelectAllAsync<Contact>();

        public async Task<Contact> SelectContactByIdAsync(Guid id) =>
        await SelectByIdAsync<Contact>(id);
        public async Task<Contact> UpdateContactAsync(Contact contact) =>
        await UpdateAsync(contact);
        public async Task<Contact> DeleteContactAsync(Contact contact) =>
            await DeleteAsync(contact);
    }
}
