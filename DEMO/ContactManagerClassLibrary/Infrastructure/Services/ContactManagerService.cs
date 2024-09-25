using ContactManagerClassLibrary.Domain.Models;
using ContactManagerClassLibrary.Infrastructure.Data;
using ContactManagerClassLibrary.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerClassLibrary.Infrastructure.Services
{
    public class ContactManagerService : IContactManager
    {
        #region New Asynchronous Methods

        public async Task<Result> AddContactAsync(string name, string number, string email, string address, bool[] groups)
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
                    {
                        Group? group = await _context.Groups.FindAsync(i + 1);
                        if(group != null)
                            newContact.Groups.Add(group);
                    }
                }

                try
                {
                    _context.Contacts.Add(newContact);
                    await _context.SaveChangesAsync();
                    return new Result(true);
                }
                catch (Exception ex)
                {
                    return new Result(true, ex.Message);
                }
            }
        }

        public async Task<Result> DeleteContactAsync(int id)
        {
            using (var _context = new Context())
            {
                var contact = await _context.Contacts
                .Where(c => c.ContactId == id)
                .Include(c => c.Groups)
                .FirstOrDefaultAsync();

                try
                {
                    _context.Contacts.Remove(contact);
                    await _context.SaveChangesAsync();
                    return new Result(true);
                }
                catch (Exception ex)
                {
                    return new Result(false, ex.Message);
                }
            }
        }

        public async Task<Result> EditContactAsync(int id, string name, string number, string email, string address, bool[] groups)
        {
            var fieldResult = HelperService.ValidateFields(name, number, email, address);
            if (!fieldResult.IsSuccess)
                return fieldResult;

            using (var _context = new Context())
            {
                var contact =  await _context.Contacts.FindAsync(id);

                try
                {
                    contact.ContactId = id;
                    contact.Name = name;
                    contact.Number = number;
                    contact.Email = email;
                    contact.Address = address;
                    contact.Groups = new List<Group>();

                    for (int i = 0; i < groups.Length; i++)
                    {
                        if (groups[i])
                        {
                            Group? group = await _context.Groups.FindAsync(i + 1);
                            if (group != null)
                                contact.Groups.Add(group);
                        }
                    }

                    _context.Contacts.Update(contact);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return new Result(false, ex.Message);
                }

                return new Result(true);
            }
        }

        public async Task<List<Contact>> SearchContactAsync(string key)
        {
            using (var _context = new Context())
            {
                return await _context.Contacts
                .Where(c => c.Name.ToLower().Contains(key) || c.Number.Contains(key) || c.Email.Contains(key))
                .OrderBy(c => c.Name)
                .ToListAsync();
            }
        }

        public async Task<Contact> GetContactByIdAsync(int id)
        {
            using (var _context = new Context())
            {
                Contact? contact = await _context.Contacts
                .Where(c => c.ContactId == id)
                .Include(c => c.Groups)
                .FirstOrDefaultAsync();

                return contact;
            }
        }

        public async Task<List<Contact>> ShowAllAsync()
        {
            using (var _context = new Context())
            {
                return await _context.Contacts
                .Select(c => c)
                .OrderBy(c => c.Name)
                .ToListAsync();
            }
        }

        #endregion


        #region Old Synchronous Methods

        //public Result AddContact(string name, string number, string email, string address, bool[] groups)
        //{
        //    var fieldResult = HelperService.ValidateFields(name, number, email, address);
        //    if (!fieldResult.IsSuccess)
        //        return fieldResult;

        //    Contact newContact = new Contact()
        //    {
        //        Name = name,
        //        Number = number,
        //        Email = email,
        //        Address = address,
        //        Groups = new List<Group>()
        //    };

        //    using (var _context = new Context())
        //    {
        //        for (int i = 0; i < groups.Length; i++)
        //        {
        //            if (groups[i])
        //                newContact.Groups.Add(_context.Groups.Find(i+1));
        //        }

        //        try
        //        {
        //            _context.Contacts.Add(newContact);
        //            _context.SaveChanges();
        //            return new Result(true);
        //        }
        //        catch (Exception ex)
        //        {
        //            return new Result(true, ex.Message);
        //        }
        //    }
        //}

        //public Result DeleteContact(int id)
        //{
        //    using (var _context = new Context())
        //    {
        //        var contact = _context.Contacts
        //        .Where(c => c.ContactId == id)
        //        .Include(c => c.Groups)
        //        .FirstOrDefault();

        //        try
        //        {
        //            _context.Contacts.Remove(contact);
        //            _context.SaveChanges();
        //            return new Result(true);
        //        }
        //        catch (Exception ex)
        //        {
        //            return new Result(false, ex.Message);
        //        }
        //    }
        //}

        //public Result EditContact(int id, string name, string number, string email, string address, bool[] groups)
        //{
        //    var fieldResult = HelperService.ValidateFields(name, number, email, address);
        //    if (!fieldResult.IsSuccess)
        //        return fieldResult;

        //    using (var _context = new Context())
        //    {
        //        var contact = _context.Contacts.Find(id);

        //        try
        //        {
        //            contact.ContactId = id;
        //            contact.Name = name;
        //            contact.Number = number;
        //            contact.Email = email;
        //            contact.Address = address;
        //            contact.Groups.Clear();

        //            for (int i = 0; i < groups.Length; i++)
        //            {
        //                if (groups[i])
        //                    contact.Groups.Add(_context.Groups.Find(i + 1));
        //            }

        //            _context.Contacts.Update(contact);
        //            _context.SaveChanges();
        //        }
        //        catch (Exception ex)
        //        {
        //            return new Result(false, ex.Message);
        //        }

        //        return new Result(true);
        //    }
        //}

        //public List<Contact> SearchContact(string key)
        //{
        //    using (var _context = new Context())
        //    {
        //        return _context.Contacts
        //        .Where(c => c.Name.ToLower().Contains(key) || c.Number.Contains(key) || c.Email.Contains(key))
        //        .OrderBy(c => c.Name)
        //        .ToList();
        //    }
        //}

        //public Contact GetContactById(int id)
        //{
        //    using (var _context = new Context())
        //    {
        //        Contact? contact = _context.Contacts
        //        .Where(c => c.ContactId == id)
        //        .Include(c => c.Groups)
        //        .FirstOrDefault();

        //        return contact;
        //    }
        //}

        //public List<Contact> ShowAll()
        //{
        //    using (var _context = new Context())
        //    {
        //        return _context.Contacts
        //        .Select(c => c)
        //        .OrderBy(c => c.Name)
        //        .ToList();
        //    }
        //}

        #endregion
    }
}
