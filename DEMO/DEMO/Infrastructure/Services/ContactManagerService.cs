using DEMO.Domain.Models;
using DEMO.Infrastructure.Data;
using DEMO.Infrastructure.Services;
using DEMO.Logic.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DEMO.Logic.Services
{
    public class ContactManagerService : IContactManager
    {
        public string AddContact(Contact newContact, Context _context)
        {
            try
            {
                _context.Contacts.Add(newContact);
                _context.SaveChanges();
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public bool DeleteContact(int id)
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
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }

        public bool EditContact(Contact editedContact)
        {
            int id = editedContact.ContactId;

            using (var _context = new Context())
            {
                var contact = _context.Contacts.Find(id);

                try
                {
                    contact.ContactId = editedContact.ContactId;
                    contact.Name = editedContact.Name;
                    contact.Number = editedContact.Number;
                    contact.Email = editedContact.Email;
                    contact.Address = editedContact.Address;

                    contact.Groups.Clear();

                    foreach (var group in editedContact.Groups)
                    {
                        var existingGroup = _context.Groups.Find(group.GroupId);
                        if (existingGroup != null)
                        {
                            contact.Groups.Add(existingGroup);
                        }
                    }

                    _context.Contacts.Update(contact);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return false;
                }

                return true;
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

        public string ValidateFields(string name, string number, string email, string address)
        {
            var nameError = HelperService.ValidateName(name);
            if (nameError != string.Empty)
            {
                return nameError;
            }

            var numberError = HelperService.ValidateNumber(number);
            if (numberError != string.Empty)
            {
                return numberError;
            }

            var emailAddressError = HelperService.ValidateEmailAndAddress(email, address);
            if (emailAddressError != string.Empty)
            {
                return emailAddressError;
            }

            return string.Empty;
        }
    }
}
