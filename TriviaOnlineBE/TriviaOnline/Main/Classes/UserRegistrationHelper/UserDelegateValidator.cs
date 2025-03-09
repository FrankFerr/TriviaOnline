using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Classes.UserRegistrationHelper
{
    public delegate bool RequiredValidDel(string value);
    public delegate bool StringLengthValidDel(string value, int min, int max);
    public delegate bool PatternMatchingValidDel(string value, string pattern);
    
}
