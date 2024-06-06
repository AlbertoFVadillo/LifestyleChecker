using LifestyleChecker.Framework.Contracts;
using LifestyleChecker.Framework.Models;
using LifestyleChecker.Framework.Validators;
using LifestyleChecker.WebApi.Clients;
using LifestyleChecker.WebApi.Models;
using Microsoft.Extensions.Configuration;
using System.Globalization;

namespace LifestyleChecker.Framework.Services
{
    public class PatientService : IPatientService
    {
        private readonly IAireLogger<PatientService> _logger;
        private readonly IPatientClient _patientClient;
        private readonly IConfiguration _configuration;

        public PatientService(IAireLogger<PatientService> logger, IPatientClient patientClient, IConfiguration configuration)
        {
            _logger = logger;
            _patientClient = patientClient;
            _configuration = configuration;
        }

        public async Task<PatientResponse> GetPatient(string nhsNumber, string surname, string dob)
        {
            try
            {
                Dictionary<string, string> headers = GetApiHeaders();

                var response = await _patientClient.GetPatient(nhsNumber, headers);

                var formattedDob = DateTime.ParseExact(dob, "dd-MM-yyyy", null);

                var result = PatientValidator.IsValid(response, surname, nhsNumber, formattedDob);

                if (!string.IsNullOrEmpty(result))
                {
                    return new PatientResponse
                    {
                        IsAuthenticated = false,
                        Message = result
                    };
                }

                return new PatientResponse
                {
                    IsAuthenticated = true,
                    Name = response.Name.Contains(',') ? response.Name.Split(',')[1] : response.Name,
                    Age = response.Age
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(nameof(GetPatient), ex, $"Error in getting patient data: {ex.Message}");
                return null;
            }
        }

        private Dictionary<string, string> GetApiHeaders()
        {
            return new Dictionary<string, string> {
                { "Ocp-Apim-Subscription-Key", _configuration.GetValue<string>("PatientApiSettings:ApiKey") } };
        }
    }
}
