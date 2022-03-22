using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PizzaCompany.Classes
{
    public static class Validation
    {
      public static bool validateEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (email == null) { return false; }
            if (email.Length == 0) { return false; }
            if(match.Success)
                return true;
            return false;
        }
      public static bool validatePassword(string password)
        {
            Regex regex = new Regex(@"(?=^.{8,20}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\s).*$");
            Match m = regex.Match(password);
            if(password == null) { return false; }
            if(password.Length == 0) { return false; }
            if(m.Success)
            return true;
            return false;
        }
      public static bool validateField(string field)
        {
            if(field == null) { return false; }
            if(field.Length==0) { return false; }
            return true;
        }
    }
}
