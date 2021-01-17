using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace View.Validator
{
    public class DecimalValidation : ValidationRule
    {
        public string Error { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string s = ((string)value);
            decimal d = 0.00m;
            try
            {
                d = Decimal.Parse(s, cultureInfo);
            }
            catch (Exception)
            {
                return new ValidationResult(false, $"Enter non negative decimal");
            }

            if (d >= 0.00m)
            {
                return ValidationResult.ValidResult;
            }
            else
            {
                return new ValidationResult(false, $"Enter non negative decimal");
            }
        }
    }
}
