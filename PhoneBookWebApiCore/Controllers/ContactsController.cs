using Microsoft.AspNetCore.Mvc;
using PhoneBookWebApiCore.Models;
using PhoneBookWebApiCore.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookWebApiCore.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    public class ContactsController : ControllerBase
    {
        private IContactService contactService;
        public ContactsController(IContactService contactService)
        {
            this.contactService = contactService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContacts()
        {
            var contacts = await contactService.GetAllContactsAsync();
            if (contacts.Count == 0)
            {
                return NoContent();
            }

            return Ok(contacts);
        }
        [HttpGet]
        public async Task<IActionResult> GetContact(Guid id)
        {
            try
            {
                var contact = await contactService.GetContactByIdAsync(id);

                return Ok(contact);
            }
            catch (ContactNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Contact>>  CreateContact(Contact contact) =>
            Ok(await contactService.AddContactAsync(contact));
        

        [HttpPut]
        public async Task<ActionResult<Contact>> EditContact(Contact contact) => 
            Ok(await contactService.UpdateContactAsync(contact));

        [HttpDelete]
        public async Task<ActionResult<Contact>> DeleteContact(Contact contact) => 
            Ok(await contactService.DeleteContactAsync(contact));
    }
}
