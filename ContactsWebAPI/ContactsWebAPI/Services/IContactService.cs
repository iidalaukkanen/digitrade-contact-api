using ContactsWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsWebAPI.Services
{
    public interface IContactService
    {
        Contact Create(Contact contact);
        List<Contact> Read();
        Contact Read(int id);
        Contact Update(int id, Contact contact);
        StatusCodeResult Delete(int id);
    }
}
