using ContactManagerClassLibrary.Domain.Models;
using ContactManagerClassLibrary.Infrastructure.Data;

namespace ContactManagerClassLibrary.Infrastructure.Interfaces
{
    public interface IContactManager
    {
        /// <summary>
        /// Adds a new contact with the specified details to the contact list.
        /// </summary>
        /// <param name="name">The name of the contact.</param>
        /// <param name="number">The phone number of the contact.</param>
        /// <param name="email">The email address of the contact.</param>
        /// <param name="address">The physical address of the contact.</param>
        /// <param name="groups">An array of booleans indicating the groups to which the contact belongs.</param>
        /// <returns>A <see cref="Result"/> indicating the success or failure of the operation, 
        /// with an error message if applicable.</returns>
        /// <remarks>
        /// This method first validates the provided fields using the <see cref="HelperService.ValidateFields"/> method.
        /// If any field is invalid, the method returns the corresponding error result.
        /// 
        /// If the fields are valid, a new <see cref="Contact"/> is created and populated with the provided details.
        /// The method then associates the contact with any selected groups based on the <paramref name="groups"/> array.
        /// 
        /// Finally, the contact is added to the database context, and changes are saved.
        /// If an exception occurs during the database operation, the error message is returned.
        /// </remarks>
        public Result AddContact(string name, string number, string email, string address, bool[] groups);


        /// <summary>
        /// Deletes a contact from the contact list by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the contact to delete.</param>
        /// <returns>A <see cref="Result"/> indicating the success or failure of the operation, 
        /// with an error message if applicable.</returns>
        /// <remarks>
        /// This method retrieves the contact with the specified <paramref name="id"/> 
        /// from the database context, including its associated groups. 
        /// 
        /// If the contact is found, it is removed from the context, and the changes are saved to the database.
        /// If an exception occurs during the removal or save process, an error message is returned in the result.
        /// </remarks>
        public Result DeleteContact(int id);


        /// <summary>
        /// Edits an existing contact's details in the contact list.
        /// </summary>
        /// <param name="id">The identifier of the contact to edit.</param>
        /// <param name="name">The new name of the contact.</param>
        /// <param name="number">The new phone number of the contact.</param>
        /// <param name="email">The new email address of the contact.</param>
        /// <param name="address">The new physical address of the contact.</param>
        /// <param name="groups">An array of booleans indicating the groups to which the contact should belong.</param>
        /// <returns>A <see cref="Result"/> indicating the success or failure of the operation, 
        /// with an error message if applicable.</returns>
        /// <remarks>
        /// This method first validates the provided fields using the <see cref="HelperService.ValidateFields"/> method.
        /// If any field is invalid, the method returns the corresponding error result.
        /// 
        /// If the fields are valid, the method retrieves the contact with the specified <paramref name="id"/> 
        /// from the database. It updates the contact's details and clears any existing groups before adding the new ones 
        /// based on the <paramref name="groups"/> array.
        /// 
        /// Finally, the contact is updated in the database context, and changes are saved.
        /// If an exception occurs during the update or save process, an error message is returned in the result.
        /// </remarks>
        public Result EditContact(int id, string name, string number, string email, string address, bool[] groups);


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
    }
}
