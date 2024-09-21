using Microsoft.EntityFrameworkCore;
using PhoneBookWebApiCore.Brokers.StorageBrokers;
using PhoneBookWebApiCore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBookWebApiCore.Services
{
    public class ContactService : IContactService
    {
        private IStorageBroker storageBroker;
        public ContactService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }
        public async Task<Contact> AddContactAsync(Contact contact)
        {
            try
            {
                if (contact == null)
                {
                    throw new NullContactException("Contact does not be null");
                }

                return await storageBroker.InsertContactAsync(contact);
            }
            catch (DbUpdateException ex)
            {
                throw new ContactStoreException("error has occured with database", ex);
            }   
        }

        public async Task<List<Contact>> GetAllContactsAsync()
        {
            return await storageBroker.SelectAllContactsAsync();
        }

        public async Task<Contact> GetContactByIdAsync(Guid id)
        {
            var contact = await storageBroker.SelectContactByIdAsync(id);
            if(contact == null)
            {
                throw new ContactNotFoundException(id);
            }

            return contact;
        }

        public async Task<Contact> UpdateContactAsync(Contact contact)
        {
            try
            {
                if(contact == null)
                {
                    throw new NullContactException("Contact does not be null");
                }

                return await storageBroker.UpdateContactAsync(contact);
            }
            catch (DbUpdateException ex)
            {
                throw new ContactStoreException("error has occured with database", ex);
            }
        }
        
        public async Task<Contact> DeleteContactAsync(Contact contact)
        {
            try
            {
                if (contact == null)
                {
                    throw new NullContactException("Contact does not be null");
                }

                return await storageBroker.DeleteContactAsync(contact);
            }
            catch(DbUpdateException ex) 
            {
                throw new ContactStoreException("error has occured with database", ex);
            }
        }
    }
}
