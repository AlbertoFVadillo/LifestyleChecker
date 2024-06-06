using LifestyleChecker.Framework.Models;

namespace LifestyleChecker.Framework.Contracts
{
    public interface IPatientService
    {
        Task<PatientResponse> GetPatient(string nhsNumber, string surname, string dob);
    }
}
