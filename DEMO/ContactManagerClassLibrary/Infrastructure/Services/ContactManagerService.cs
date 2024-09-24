using ContactManagerClassLibrary.Domain.Models;
using ContactManagerClassLibrary.Infrastructure.Data;
using ContactManagerClassLibrary.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerClassLibrary.Infrastructure.Services
{
    public class ContactManagerService : IContactManager
    {
        public Result AddContact(string name, string number, string email, string address, bool[] groups)
        {
            var fieldResult = HelperService.ValidateFields(name, number, email, address);
            if (!fieldResult.IsSuccess)
                return fieldResult;

            Contact newContact = new Contact()
            {
                Name = name,
                Number = number,
                Email = email,
                Address = address,
                Groups = new List<Group>()
            };

            using (var _context = new Context())
            {
                for (int i = 0; i < groups.Length; i++)
                {
                    if (groups[i])
                        newContact.Groups.Add(_context.Groups.Find(i+1));
                }

                try
                {
                    _context.Contacts.Add(newContact);
                    _context.SaveChanges();
                    return new Result(true);
                }
                catch (Exception ex)
                {
                    return new Result(true, ex.Message);
                }
            }
        }

        public Result DeleteContact(int id)
        {
            using (var _context = new Context())
            {
                var contact = _context.Contacts
                .Where(c => c.ContactId == id)
                .Include(c => c.Groups)
                .FirstOrDefault();

                try
                {
                    _context.Contacts.Remove(contact);
                    _context.SaveChanges();
                    return new Result(true);
                }
                catch (Exception ex)
                {
                    return new Result(false, ex.Message);
                }
            }
        }

        public Result EditContact(int id, string name, string number, string email, string address, bool[] groups)
        {
            var fieldResult = HelperService.ValidateFields(name, number, email, address);
            if (!fieldResult.IsSuccess)
                return fieldResult;

            using (var _context = new Context())
            {
                var contact = _context.Contacts.Find(id);

                try
                {
                    contact.ContactId = id;
                    contact.Name = name;
                    contact.Number = number;
                    contact.Email = email;
                    contact.Address = address;
                    contact.Groups.Clear();

                    for (int i = 0; i < groups.Length; i++)
                    {
                        if (groups[i])
                            contact.Groups.Add(_context.Groups.Find(i + 1));
                    }

                    _context.Contacts.Update(contact);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return new Result(false, ex.Message);
                }

                return new Result(true);
            }
        }

        public List<Contact> SearchContact(string key)
        {
            using (var _context = new Context())
            {
                return _context.Contacts
                .Where(c => c.Name.ToLower().Contains(key) || c.Number.Contains(key) || c.Email.Contains(key))
                .OrderBy(c => c.Name)
                .ToList();
            }
        }

        public Contact GetContactById(int id)
        {
            using (var _context = new Context())
            {
                Contact? contact = _context.Contacts
                .Where(c => c.ContactId == id)
                .Include(c => c.Groups)
                .FirstOrDefault();

                return contact;
            }
        }

        public Domain.Models.Group GetGroupById(int id, Context _context)
        {
            Domain.Models.Group? group = _context.Groups
            .Include(g => g.Contacts)
            .FirstOrDefault(g => g.GroupId == id);

            return group;
        }

        public List<Contact> ShowAll()
        {
            using (var _context = new Context())
            {
                return _context.Contacts
                .Select(c => c)
                .OrderBy(c => c.Name)
                .ToList();
            }
        }
    }
}
