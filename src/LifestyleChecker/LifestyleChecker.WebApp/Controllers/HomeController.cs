using LifestyleChecker.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using LifestyleChecker.Framework.Contracts;

namespace LifestyleChecker.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAireLogger<HomeController> _logger;
        private readonly IPatientService _patientService;

        public HomeController(IAireLogger<HomeController> logger, IPatientService patientService, IQuestionsService questionsService)
        {
            _logger = logger;
            _patientService = patientService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(PatientViewModel patientViewModel)
        {
            if (ModelState.IsValid)
            {
                var patient = await _patientService.GetPatient(patientViewModel.NHSNumber, patientViewModel.Surname, patientViewModel.DateOfBirth.Date.ToString("dd-MM-yyyy"));

                if (patient == null)
                {
                    return NotFound();
                }
                if (!patient.IsAuthenticated)
                {
                    ViewBag.ErrorMessage = patient?.Message;
                    return View();
                }

                return View("./Views/Questions/Index.cshtml", new QuestionsViewModel { Age = patient.Age, Name = patient.Name });
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
