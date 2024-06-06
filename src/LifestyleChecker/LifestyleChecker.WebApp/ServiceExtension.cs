using CorrelationId.Abstractions;
using CorrelationId;
using LifestyleChecker.Framework.Contracts;
using LifestyleChecker.Framework.Logger;
using LifestyleChecker.Framework.Services;
using System.Diagnostics.CodeAnalysis;
using LifestyleChecker.WebApi.Clients;
using Refit;
using Microsoft.Net.Http.Headers;

namespace LifestyleChecker.WebApp
{
    [ExcludeFromCodeCoverage]
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ICorrelationContextAccessor, CorrelationContextAccessor>();
            services.AddTransient(typeof(IAireLogger<>), typeof(AireLogger<>));
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IQuestionsService, QuestionsService>();

            services.AddHttpClient("ScoreApi", httpClient =>
            {
                httpClient.BaseAddress = new Uri("http://localhost:5062/api/");

                // using Microsoft.Net.Http.Headers;
                // The GitHub API requires two headers.
                httpClient.DefaultRequestHeaders.Add(
                    HeaderNames.Accept, "text/plain");
            });

            // Refit
            services.AddRefitClient<IPatientClient>()
                          .ConfigureHttpClient(c =>
                          {
                              c.Timeout = TimeSpan.FromSeconds(configuration.GetValue<int>("PatientApiSettings:Timeout"));
                              c.BaseAddress = new Uri(configuration.GetValue<string>("PatientApiSettings:Endpoint"));
                          });
        }
    }
}
