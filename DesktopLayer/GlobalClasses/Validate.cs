using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DesktopLayer.GlobalClasses
{
    public class clsValidate
    {
        public static bool ValidateEmail(string Email)
        {
            var pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";

            var regex = new Regex(pattern);

            return regex.IsMatch(Email);
        }

        public static bool ValidatePassword(string Password , int Length = 7)
            => Password.Length >= Length;

        public static bool IsNumber(string Input)
        {
            string decimalPattern = @"^[+-]?(\d+\.?\d*|\.\d+)([eE][+-]?\d+)?$";

            return Regex.IsMatch(Input, decimalPattern);
        }

        public static bool AllowNumbersOnly(char c)
            => !char.IsDigit(c) && !char.IsControl(c);
    }
}
