using LifestyleChecker.WebApi.Models;
using Refit;

namespace LifestyleChecker.WebApi.Clients
{
    public interface IPatientClient
    {
        [Get("/patients/{nhsNumber}")]
        Task<Patient> GetPatient(string nhsNumber, [HeaderCollection] IDictionary<string, string> headers);
    }
}
