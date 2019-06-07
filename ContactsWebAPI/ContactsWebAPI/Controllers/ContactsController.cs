using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ContactsWebAPI.Models;
using ContactsWebAPI.Repositories;
using ContactsWebAPI.Services;
using Microsoft.AspNetCore.Cors;

namespace ContactsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        private readonly IContactService _contactService;

        public ContactsController(IContactRepository contactRepository, IContactService contactService)
        {
            _contactRepository = contactRepository;
            _contactService = contactService;
        }

        [EnableCors("ContactsAppPolicy")]
        [HttpPost]
        public ActionResult<Contact> Post(Contact contact)
        {
            var newContact = _contactService.Create(contact);
            return new JsonResult(newContact);
        }

        [EnableCors("ContactsAppPolicy")]
        [HttpGet]
        public ActionResult<List<Contact>> GetContacts()
        {
            return new JsonResult(_contactService.Read());
        }

        [EnableCors("ContactsAppPolicy")]
        [HttpGet("{id}")]
        public ActionResult<Contact> Get(int id)
        {
            var contact = _contactService.Read(id);
            return new JsonResult(contact);
        }

        [EnableCors("ContactsAppPolicy")]
        [HttpPut("{id}")]
        public ActionResult<Contact> Put(int id, Contact contact)
        {
            var updateContact = _contactService.Update(id, contact);
            return new JsonResult(updateContact);
        }

        [EnableCors("ContactsAppPolicy")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return _contactService.Delete(id);
        }
    }
}