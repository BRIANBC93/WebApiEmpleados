using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebApiEmpleados.Models
{
    public class RFCValidationAttribute : ValidationAttribute
    {
        private readonly string _rfcPatternPF = "^(([A-ZÑ&]{4})([0-9]{2})([0][13578]|[1][02])(([0][1-9]|[12][0-9])|[3][01])([A-Z0-9]{3}))|" +
                                                "(([A-ZÑ&]{4})([0-9]{2})([0][13456789]|[1][012])(([0][1-9]|[12][0-9])|[3][0])([A-Z0-9]{3}))|" +
                                                "(([A-ZÑ&]{4})([02468][048]|[13579][26])[0][2]([0][1-9]|[12][0-9])([A-Z0-9]{3}))|" +
                                                "(([A-ZÑ&]{4})([0-9]{2})[0][2]([0][1-9]|[1][0-9]|[2][0-8])([A-Z0-9]{3}))$";

        private readonly string _rfcPatternPM = "^(([A-ZÑ&]{3})([0-9]{2})([0][13578]|[1][02])(([0][1-9]|[12][0-9])|[3][01])([A-Z0-9]{3}))|" +
                                                "(([A-ZÑ&]{3})([0-9]{2})([0][13456789]|[1][012])(([0][1-9]|[12][0-9])|[3][0])([A-Z0-9]{3}))|" +
                                                "(([A-ZÑ&]{3})([02468][048]|[13579][26])[0][2]([0][1-9]|[12][0-9])([A-Z0-9]{3}))|" +
                                                "(([A-ZÑ&]{3})([0-9]{2})[0][2]([0][1-9]|[1][0-9]|[2][0-8])([A-Z0-9]{3}))$";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string rfc = value.ToString().ToUpper().Trim(); // Convertir a mayúsculas y quitar espacios

                if (IsValidRFC(rfc))
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(ErrorMessage ?? "El RFC no cumple con el formato válido.");
        }

        private bool IsValidRFC(string rfc)
        {
            return Regex.IsMatch(rfc, _rfcPatternPF) || Regex.IsMatch(rfc, _rfcPatternPM);
        }
    }
}
