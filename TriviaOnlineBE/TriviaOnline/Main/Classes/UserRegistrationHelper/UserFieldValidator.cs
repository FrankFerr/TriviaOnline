using Main.Classes.UserRegistrationHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Main.Classes.UserRegistrationHelper
{
    public class UserFieldValidator
    {
        private static RequiredValidDel? _requireValidDel = null;
        private static StringLengthValidDel? _stringLengthValidDel = null;
        private static PatternMatchingValidDel? _patternMatchingValidDel = null;

        public static RequiredValidDel RequiredValidDel
        {
            get
            {
                if (_requireValidDel == null)
                    _requireValidDel = new RequiredValidDel(RequiredValid);

                return _requireValidDel;
            }
        }

        public static StringLengthValidDel StringLengthValidDel
        {
            get
            {
                if (_stringLengthValidDel == null)
                    _stringLengthValidDel = new StringLengthValidDel(StringLengthValid);

                return _stringLengthValidDel;
            }
        }

        public static PatternMatchingValidDel PatternMatchingValidDel
        {
            get
            {
                if (_patternMatchingValidDel == null)
                    _patternMatchingValidDel = new PatternMatchingValidDel(PatternMatchingValid);

                return _patternMatchingValidDel;
            }
        }

        private static bool RequiredValid(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            return true;
        }

        private static bool StringLengthValid(string value, int min, int max)
        {
            if (value.Length < min || max < value.Length)
                return false;

            return true;
        }

        private static bool PatternMatchingValid(string value, string pattern)
        {
            Regex regex = new Regex(pattern);

            if (!regex.IsMatch(value))
                return false;

            return true;
        }
    }
}
