using ContactManagerClassLibrary.Domain.Models;
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
        /// Validates the provided fields: name, number, email, and address.
        /// </summary>
        /// <param name="name">The name to validate.</param>
        /// <param name="number">The number to validate.</param>
        /// <param name="email">The email address to validate.</param>
        /// <param name="address">The address to validate.</param>
        /// <returns>A <see cref="Result"/> indicating the success or failure of the validation.</returns>
        /// <remarks>
        /// This method performs sequential validation on the provided fields. If any field is invalid, 
        /// the validation process stops, and an appropriate result is returned. 
        /// The validation is performed in the following order:
        /// 1. Name
        /// 2. Number
        /// 3. Email and Address (Validated together).
        /// </remarks>
        public static Result ValidateFields(string name, string number, string email, string address)
        {
            var nameResult = ValidateName(name);
            if (!nameResult.IsSuccess)
                return nameResult;

            var numberResult = ValidateNumber(number);
            if (!numberResult.IsSuccess)
                return numberResult;

            var emailAddressResult = ValidateEmailAndAddress(email, address);
            if (!emailAddressResult.IsSuccess)
            {
                return emailAddressResult;
            }

            return new Result(true);
        }


        /// <summary>
        /// Validates the provided name for non-emptiness and length constraints.
        /// </summary>
        /// <param name="name">The name to validate.</param>
        /// <returns>A <see cref="Result"/> indicating the success or failure of the validation.</returns>
        /// <remarks>
        /// This method checks the following criteria for the name:
        /// 1. The name must not be empty or null.
        /// 2. The length of the name must not exceed 100 characters.
        /// 
        /// If the name does not meet these criteria, a descriptive error message is included in the result.
        /// </remarks>
        private static Result ValidateName(string name)
        {
            if (name.IsNullOrEmpty())
            {
                return new Result(false, "Name Cannot Be Empty.");
            }
            if (name.Length > 100)
            {
                return new Result(false, "Name Too Long.");
            }

            return new Result(true);
        }


        /// <summary>
        /// Validates the provided phone number for format and length.
        /// </summary>
        /// <param name="number">The phone number to validate.</param>
        /// <returns>
        /// A <see cref="Result"/> indicating the success or failure of the validation, 
        /// with an error message if the number is invalid.
        /// </returns>
        /// <remarks>
        /// This method checks that the phone number:
        /// 1. Does not exceed 20 characters in length.
        /// 2. Matches the valid format, allowing only digits, 
        ///    an optional leading plus sign (+), and hyphens (-) for formatting.
        /// 
        /// If the number is valid, the result indicates success; otherwise, 
        /// a descriptive error message is provided.
        /// </remarks>
        private static Result ValidateNumber(string number)
        {
            if (number.Length > 20)
                return new Result(false, "Number too Long.");

            string pattern = "^[+]?(\\d+(-\\d+)*|\\d+)$";
            Regex regex = new Regex(pattern);

            bool match = regex.IsMatch(number);

            if (!match || number.IsNullOrEmpty())
            {
                return new Result(false, "Phone Numbers Cannot be Empty and May Only Contain Digits, a Plus Sign (+) at the Start, and Singular Hyphens (-) Between Digits.");
            }

            return new Result(true);
        }


        /// <summary>
        /// Validates the provided email and address for length constraints.
        /// </summary>
        /// <param name="email">The email address to validate.</param>
        /// <param name="address">The address to validate.</param>
        /// <returns>
        /// A <see cref="Result"/> indicating the success or failure of the validation, 
        /// with an error message if either field is invalid.
        /// </returns>
        /// <remarks>
        /// This method checks the following criteria:
        /// 1. The email must not exceed 150 characters in length.
        /// 2. The address must not be 1000 characters or longer.
        /// 
        /// If either field is invalid, a descriptive error message is included in the result.
        /// If both fields are valid, the method returns a successful result.
        /// </remarks>
        private static Result ValidateEmailAndAddress(string email, string address)
        {
            if (email.Length > 150)
                return new Result(false, "Email Length Too Long.");
            else if (address.Length >= 1000)
                return new Result(false, "Address Length Too Long.");
            else
                return new Result(true);
        }
    }
}
