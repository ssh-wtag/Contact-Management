using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ContactManagerClassLibrary.Infrastructure.Services
{
    public static class HelperService
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
        public static string ValidateName(string name)
        {
            if (name.IsNullOrEmpty())
            {
                return "Name Cannot Be Empty.";
            }
            if (name.Length > 100)
            {
                return "Name Too Long.";
            }

            return string.Empty;
        }

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
        public static string ValidateNumber(string number)
        {
            if (number.Length > 20)
                return "Number too Long.";

            string pattern = "^[+]?(\\d+(-\\d+)*|\\d+)$";
            Regex regex = new Regex(pattern);

            bool match = regex.IsMatch(number);

            if (!match || number.IsNullOrEmpty())
            {
                return "Phone Numbers Cannot be Empty and May Only Contain Digits, a Plus Sign (+) at the Start, and Hyphens (-).";
            }

            return string.Empty;
        }

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
        public static string ValidateEmailAndAddress(string email, string address)
        {
            if (email.Length > 150)
                return "Email Length Too Long.";
            else if (address.Length >= 1000)
                return "Address Length Too Long.";
            else
                return string.Empty;
        }
    }
}
