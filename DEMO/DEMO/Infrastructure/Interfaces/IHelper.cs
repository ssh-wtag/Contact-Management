using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMO.Infrastructure.Interfaces
{
    public interface IHelper
    {
        /// <summary>
        /// Validates the provided name for length and emptiness.
        /// </summary>
        /// <param name="name">The name to validate.</param>
        /// <returns>
        /// An error message if the name is empty or exceeds the maximum length; otherwise, an empty string.
        /// </returns>
        /// <remarks>
        /// This method checks if the name is null or empty and ensures that it does not exceed 100 characters.
        /// If the name is valid, an empty string is returned; otherwise, a descriptive error message is provided.
        /// </remarks>
        public string ValidateName(string name);


        /// <summary>
        /// Validates the provided phone number for format and length.
        /// </summary>
        /// <param name="number">The phone number to validate.</param>
        /// <returns>
        /// An error message if the number is empty or does not match the valid format; otherwise, an empty string.
        /// </returns>
        /// <remarks>
        /// This method checks that the phone number does not exceed 20 characters in length.
        /// It uses a regular expression to ensure the number contains only digits, 
        /// an optional leading plus sign (+), and hyphens (-) for formatting.
        /// If the number is valid, an empty string is returned; otherwise, a descriptive error message is provided.
        /// </remarks>
        public string ValidateNumber(string number);

        /// <summary>
        /// Validates the provided email and address for length.
        /// </summary>
        /// <param name="email">The email address to validate.</param>
        /// <param name="address">The address to validate.</param>
        /// <returns>
        /// An error message if the email or address exceeds the maximum allowed length; otherwise, an empty string.
        /// </returns>
        /// <remarks>
        /// This method checks that the email does not exceed 150 characters and the address does not exceed 1000 characters.
        /// If both fields are valid, an empty string is returned; otherwise, a descriptive error message is provided for the field that fails validation.
        /// </remarks>
        public string ValidateEmailAndAddress(string email, string address);
    }
}
