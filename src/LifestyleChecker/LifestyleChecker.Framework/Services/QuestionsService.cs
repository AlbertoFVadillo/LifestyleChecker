using LifestyleChecker.DataLayer.Models;
using LifestyleChecker.Framework.Contracts;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using LifestyleChecker.Framework.Helpers;

namespace LifestyleChecker.Framework.Services
{
    public class QuestionsService : IQuestionsService
    {
        private readonly IAireLogger<QuestionsService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public QuestionsService(IAireLogger<QuestionsService> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<int?> CalculateScore(int age, Dictionary<int, bool> answers)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("ScoreApi");
                var response = await httpClient.GetAsync("scores");

                var result = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<ScoreDto>>(result);

                if (data != null)
                {
                    return ScoreHelper.Calculate(age, data, answers);
                }

                return 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(nameof(CalculateScore), ex, $"Error in calculating score: {ex.Message}");
                return null;
            }
        }
    }
}
