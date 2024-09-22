using DEMO.Domain.Models;
using DEMO.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMO.Logic.Interfaces
{
    public interface IContactManager
    {
        /// <summary>
        /// Retrieves all contacts from the database, including their associated groups.
        /// </summary>
        /// <returns>
        /// A list of <see cref="Contact"/> objects, ordered by the contact's name.
        /// </returns>
        /// <remarks>
        /// This method utilizes the Entity Framework to fetch data from the database.
        /// Ensure that the database context is properly configured and available.
        /// </remarks>
        public List<Contact> ShowAll();


        /// <summary>
        /// Searches for contacts that match the specified key in their name, number, or email.
        /// </summary>
        /// <param name="key">The search key used to filter contacts.</param>
        /// <returns>
        /// A list of <see cref="Contact"/> objects that contain the specified key in their name, number, or email,
        /// ordered by the contact's name.
        /// </returns>
        /// <remarks>
        /// This method performs a case-insensitive search on the contact's name and a case-sensitive search on the number and email.
        /// Ensure that the database context is properly configured and available.
        /// </remarks>
        public List<Contact> SearchContact(string key);


        /// <summary>
        /// Retrieves a contact by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the contact to retrieve.</param>
        /// <returns>
        /// A <see cref="Contact"/> object if found; otherwise, <c>null</c>.
        /// </returns>
        /// <remarks>
        /// This method includes the associated groups for the retrieved contact.
        /// Ensure that the database context is properly configured and available.
        /// </remarks>
        public Contact GetContactById(int id);


        /// <summary>
        /// Retrieves a group by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the group to retrieve.</param>
        /// <returns>
        /// A <see cref="Domain.Models.Group"/> object if found; otherwise, <c>null</c>.
        /// </returns>
        /// <remarks>
        /// This method includes the associated contacts for the retrieved group.
        /// Ensure that the database context is properly configured and available.
        /// </remarks>
        public Group GetGroupById(int id);

        /// <summary>
        /// Validates a name to ensure it is not empty.
        /// </summary>
        /// <param name="name">The name to validate.</param>
        /// <returns>
        /// <c>true</c> if the name is valid; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// If the name is empty, a message box will display an error message indicating
        /// that the name cannot be empty.
        /// </remarks>
        public bool ValidateName(string name);


        /// <summary>
        /// Validates a phone number to ensure it is not empty and conforms to a specified format.
        /// </summary>
        /// <param name="number">The phone number to validate.</param>
        /// <returns>
        /// <c>true</c> if the phone number is valid; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// The validation checks that the phone number is not empty and matches the pattern,
        /// which allows digits, an optional leading plus sign (+), and hyphens (-).
        /// If the validation fails, a message box will display an appropriate error message.
        /// </remarks>
        public bool ValidateNumber(string number);


        /// <summary>
        /// Edits an existing contact in the database with the provided details.
        /// </summary>
        /// <param name="editedContact">The <see cref="Contact"/> object containing the updated contact information.</param>
        /// <returns>
        /// <c>true</c> if the contact was successfully edited; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method retrieves the existing contact by its identifier, updates its properties,
        /// and clears and reassigns its associated groups. If any exceptions occur during the
        /// update process, the method will return <c>false</c>. Ensure that the database context
        /// is properly configured and available.
        /// </remarks>
        public bool EditContact(Contact editedContact);


        /// <summary>
        /// Adds a new contact to the database.
        /// </summary>
        /// <param name="newContact">The <see cref="Contact"/> object to be added.</param>
        /// <param name="_context">The <see cref="Context"/> instance used to interact with the database.</param>
        /// <returns>
        /// <c>true</c> if the contact was successfully added; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method attempts to add the provided contact to the database and save the changes.
        /// If any exceptions occur during the addition process, the method will return <c>false</c>.
        /// Ensure that the provided database context is properly configured and available.
        /// </remarks>
        public bool AddContact(Contact newContact, Context _context);


        /// <summary>
        /// Deletes a contact from the database by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the contact to delete.</param>
        /// <returns>
        /// <c>true</c> if the contact was successfully deleted; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method retrieves the contact by its identifier, removes it from the database,
        /// and saves the changes. If any exceptions occur during the deletion process,
        /// the method will return <c>false</c>. Ensure that the database context is
        /// properly configured and available.
        /// </remarks>
        public bool DeleteContact(int id);
    }
}
