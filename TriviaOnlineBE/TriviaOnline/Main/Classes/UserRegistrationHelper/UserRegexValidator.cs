using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Classes.UserRegistrationHelper
{
    public static class UserRegexValidator
    {
        public const string EMAIL_PATTERN = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
        public const string PASSWORD_PATTERN = @"(?=^.{8,12}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\s).*$";
    }
}
