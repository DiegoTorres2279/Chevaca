using System;
using System.ComponentModel.DataAnnotations;

namespace Services.Validations
{
    public class ValidDate:ValidationAttribute
    {
        public override bool IsValid(object? obj)
        {
            bool valid = true;
            DateTime fecha = (DateTime) obj;
            if (fecha == null)
            {
                return false;
            }else if (fecha > DateTime.Today)
            {
                return false;
            }else if (fecha.AddYears(18)> DateTime.Today)
            {
                return false;
            }

            return valid;
        }
    }
}