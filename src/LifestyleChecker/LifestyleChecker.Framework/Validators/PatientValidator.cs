using LifestyleChecker.WebApi.Models;
using System.Globalization;

namespace LifestyleChecker.Framework.Validators
{
    public static class PatientValidator
    {
        private const int MinAge = 16;

        public static string IsValid(Patient patient, string name, string nhsnumber, DateTime dob)
        {
            var patientName = patient.Name.Split(',')[0];

            if (patient == null || !patientName.Equals(name, StringComparison.InvariantCultureIgnoreCase)
                || !patient.NhsNumber.Equals(nhsnumber)
                || dob != DateTime.ParseExact(patient.Born, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                return "Your details could not be found";

            if(patient.Age < MinAge)
                    return "You are not eligble for this service";

            return string.Empty;
        }
    }
}
