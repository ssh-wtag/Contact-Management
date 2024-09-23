using ContactManagerClassLibrary.Domain.Models;
using ContactManagerClassLibrary.Infrastructure.Data;

namespace ContactManagerClassLibrary.Infrastructure.Interfaces
{
    public interface IContactManager
    {
        /// <summary>
        /// Adds a new contact to the database.
        /// </summary>
        /// <param name="newContact">The contact to be added.</param>
        /// <param name="_context">The database context used to interact with the contacts.</param>
        /// <returns>
        /// An empty string if the contact is added successfully; otherwise, returns the exception message.
        /// </returns>
        /// <remarks>
        /// This method attempts to add the specified contact to the database.
        /// If the operation is successful, it saves the changes.
        /// In case of an error, it catches the exception and returns the error message.
        /// </remarks>
        /// <exception cref="Exception">Thrown when there is an error during the save operation.</exception>
        public string AddContact(Contact newContact, Context _context);


        /// <summary>
        /// Deletes a contact from the database by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the contact to be deleted.</param>
        /// <returns>
        /// <c>true</c> if the contact was successfully deleted; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method retrieves the contact with the specified ID and attempts to remove it from the database.
        /// If the contact is found and successfully deleted, it saves the changes.
        /// In case of any errors during the deletion process, <c>false</c> is returned.
        /// </remarks>
        /// <exception cref="Exception">Thrown when there is an error during the delete operation.</exception>
        public bool DeleteContact(int id);


        /// <summary>
        /// Updates the details of an existing contact in the database.
        /// </summary>
        /// <param name="editedContact">The contact object containing the updated information.</param>
        /// <returns>
        /// <c>true</c> if the contact was successfully updated; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// The method updates the contact's properties such as name, number, email, and address.
        /// It also clears the existing groups and adds the groups from the edited contact.
        /// If the contact is not found or an error occurs during the update, <c>false</c> is returned.
        /// </remarks>
        /// <exception cref="Exception">Thrown when there is an error during the update operation.</exception>
        public bool EditContact(Contact editedContact);


        /// <summary>
        /// Searches for contacts in the database that match the specified search key.
        /// </summary>
        /// <param name="key">The search term used to filter contacts by name, number, or email.</param>
        /// <returns>A list of contacts that match the search criteria.</returns>
        /// <remarks>
        /// This method performs a case-insensitive search for contacts whose name, number, or email contains the specified key.
        /// The results are ordered by the contact's name.
        /// If no matches are found, an empty list is returned.
        /// </remarks>
        public List<Contact> SearchContact(string key);


        /// <summary>
        /// Retrieves a contact from the database by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the contact to retrieve.</param>
        /// <returns>
        /// The contact object if found; otherwise, <c>null</c>.
        /// </returns>
        /// <remarks>
        /// This method searches for a contact with the specified ID and includes its associated groups.
        /// If the contact does not exist, <c>null</c> is returned.
        /// </remarks>
        public Contact GetContactById(int id);


        /// <summary>
        /// Retrieves a group from the database by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the group to retrieve.</param>
        /// <param name="_context">The database context used to interact with the groups.</param>
        /// <returns>
        /// The group object if found; otherwise, <c>null</c>.
        /// </returns>
        /// <remarks>
        /// This method searches for a group with the specified ID and includes its associated contacts.
        /// If the group does not exist, <c>null</c> is returned.
        /// </remarks>
        public Group GetGroupById(int id, Context context);


        /// <summary>
        /// Retrieves all contacts from the database.
        /// </summary>
        /// <returns>A list of all contacts, ordered by name.</returns>
        /// <remarks>
        /// This method fetches all contact records from the database and orders them by the contact's name.
        /// If there are no contacts, an empty list is returned.
        /// </remarks>
        public List<Contact> ShowAll();


        /// <summary>
        /// Validates the provided contact fields for name, number, email, and address.
        /// </summary>
        /// <param name="name">The name of the contact to validate.</param>
        /// <param name="number">The phone number of the contact to validate.</param>
        /// <param name="email">The email address of the contact to validate.</param>
        /// <param name="address">The address of the contact to validate.</param>
        /// <returns>
        /// An error message if any field is invalid; otherwise, an empty string.
        /// </returns>
        /// <remarks>
        /// This method utilizes helper services to validate each field. 
        /// It checks the name, number, and combined email and address for validity.
        /// The first encountered validation error is returned; if all fields are valid, an empty string is returned.
        /// </remarks>
        public string ValidateFields(string name, string number, string email, string address);
    }
}
