using DEMO.Infrastructure.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DEMO.Infrastructure.Services
{
    public class HelperService : IHelper
    {
        public string ValidateName(string name)
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

        public string ValidateNumber(string number)
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

        public string ValidateEmailAndAddress(string email, string address)
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
