using System;
using System.Collections.Generic;
using System.Text;
using Pokedex.Model.Service;
using Pokedex.Model.DAO;
using Pokedex.Model.Entities;
using System.Text.RegularExpressions;

namespace Pokedex.Model.Service
{
    public static class ValidateString
    {      
        public static bool Validate(ref string validateString)
        {                 
                if (validateString != null)
                {
                    validateString = validateString.Trim().ToLower();
                }
                if (string.IsNullOrEmpty(validateString) || Regex.IsMatch(validateString, (@"[!""#$%&'()*+,./:;?@[\\\]_`{|}~]")))
                {
                    return false;
                }
                return true;                                             
        }
    }
}

