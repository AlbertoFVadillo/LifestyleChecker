using LifestyleChecker.Framework.Constants;
using LifestyleChecker.Framework.Contracts;
using LifestyleChecker.Framework.Services;
using LifestyleChecker.WebApi.Models;
using LifestyleChecker.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LifestyleChecker.WebApp.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IAireLogger<HomeController> _logger;
        private readonly IQuestionsService _questionsService;

        public QuestionsController(IAireLogger<HomeController> logger, IQuestionsService questionsService)
        {
            _logger = logger;
            _questionsService = questionsService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(QuestionsViewModel questionsViewModel)
        {
            if (ModelState.IsValid)
            {
                var answers = new Dictionary<int, bool>
                {
                    { 1, questionsViewModel.Answer1 },
                    { 2, questionsViewModel.Answer2 },
                    { 3, questionsViewModel.Answer3 }
                };

                var finalScore = await _questionsService.CalculateScore(questionsViewModel.Age, answers);

                if (finalScore <= 3)
                    questionsViewModel.ResultMessage = AnswersStrings.Passed;
                else
                    questionsViewModel.ResultMessage = AnswersStrings.Failed;

                return View("./Views/Questions/Index.cshtml", questionsViewModel);
            }

            return View("./Views/Home/Index.cshtml");
        }
    }
}
