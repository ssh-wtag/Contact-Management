using ContactManagerClassLibrary.Domain.Models;
using ContactManagerClassLibrary.Infrastructure.Data;

namespace ContactManagerClassLibrary.Infrastructure.Interfaces
{
    public interface IContactManager
    {
        /// <summary>
        /// Asynchronously adds a new contact to the database.
        /// </summary>
        /// <param name="name">The name of the contact.</param>
        /// <param name="number">The phone number of the contact.</param>
        /// <param name="email">The email address of the contact.</param>
        /// <param name="address">The physical address of the contact.</param>
        /// <param name="groups">An array of boolean values indicating which groups the contact belongs to.</param>
        /// <returns>A <see cref="Task{Result}"/> that represents the asynchronous operation. 
        /// The result contains information about the success or failure of the operation.</returns>
        /// <remarks>
        /// This method validates the input fields before adding the contact to the database.
        /// If validation fails, the method returns the validation result without attempting to save the contact.
        /// If successful, it adds the contact to the database and associates it with the specified groups.
        /// </remarks>
        public Task<Result> AddContactAsync(string name, string number, string email, string address, bool[] groups);


        /// <summary>
        /// Asynchronously deletes a contact from the database by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the contact to be deleted.</param>
        /// <returns>A <see cref="Task{Result}"/> indicating the success of the operation.</returns>
        /// <remarks>
        /// Retrieves the contact and attempts to delete it. Returns a failure result if the contact 
        /// does not exist or an error occurs.
        /// </remarks>
        public Task<Result> DeleteContactAsync(int id);


        /// <summary>
        /// Asynchronously updates an existing contact in the database.
        /// </summary>
        /// <param name="id">The unique identifier of the contact to be edited.</param>
        /// <param name="name">The new name of the contact.</param>
        /// <param name="number">The new phone number of the contact.</param>
        /// <param name="email">The new email address of the contact.</param>
        /// <param name="address">The new physical address of the contact.</param>
        /// <param name="groups">An array of boolean values indicating the groups for the contact.</param>
        /// <returns>A <see cref="Task{Result}"/> indicating the success of the operation.</returns>
        /// <remarks>
        /// Validates input fields before updating. If the contact is not found or an error occurs, 
        /// it returns a failure result.
        /// </remarks>
        public Task<Result> EditContactAsync(int id, string name, string number, string email, string address, bool[] groups);


        /// <summary>
        /// Asynchronously searches for contacts based on a search key.
        /// </summary>
        /// <param name="key">The search term used to filter contacts by name, number, or email.</param>
        /// <returns>A <see cref="Task{List{Contact}}"/> containing the list of matching contacts.</returns>
        /// <remarks>
        /// Performs a case-insensitive search for contacts whose name, number, or email contains the specified key.
        /// Results are ordered by contact name. Returns an empty list if no matches are found.
        /// </remarks>
        public Task<List<Contact>> SearchContactAsync(string key);


        /// <summary>
        /// Asynchronously retrieves a contact by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the contact to retrieve.</param>
        /// <returns>A <see cref="Task{Contact}"/> containing the requested contact, or null if not found.</returns>
        /// <remarks>
        /// Includes associated groups in the retrieval. Returns null if no contact with the specified ID exists.
        /// </remarks>
        public Task<Contact> GetContactByIdAsync(int id);


        /// <summary>
        /// Asynchronously retrieves all contacts from the database.
        /// </summary>
        /// <returns>A <see cref="Task{List{Contact}}"/> containing all contacts, ordered by name.</returns>
        /// <remarks>
        /// This method fetches all contacts without filtering. Returns an empty list if no contacts are found.
        /// </remarks>
        public Task<List<Contact>> ShowAllAsync();
    }
}
