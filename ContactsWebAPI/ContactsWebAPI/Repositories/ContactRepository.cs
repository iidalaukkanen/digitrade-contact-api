using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsWebAPI.Models;
using ContactsWebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactsWebAPI.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactdbContext _context;

        public ContactRepository(ContactdbContext context)
        {
            _context = context;
        }

        public Contact Create(Contact contact)
        {
            _context.Add(contact);
            _context.SaveChanges();
            return contact;
        }

        public StatusCodeResult Delete(int id)
        {
            var deletedContact = Read(id);
            _context.Remove(deletedContact);
            _context.SaveChanges();
            return new OkResult();
        }

        public List<Contact> Read()
        {
            return _context.Contact.ToList();
        }

        public Contact Read(int id)
        {
            return _context.Contact.AsNoTracking().FirstOrDefault(p => p.Id == id);
        }

        public Contact Update(Contact contact)
        {
            _context.Update(contact);
            _context.SaveChanges();
            return contact;
        }
    }
}
