using LifestyleChecker.DataLayer;
using LifestyleChecker.DataLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace LifestyleChecker.WebApi.Controllers
{
    [Route("api/scores")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private readonly ScoreContext? _scoreContext;
        public ScoreController(ScoreContext? scoreContext)
        {
            _scoreContext = scoreContext;
        }
        [HttpGet]
        public async Task<ActionResult<List<ScoreDto>>> Get()
        {
            IEnumerable<ScoreDto> scores = _scoreContext.Scores.Select(s =>
                new ScoreDto
                {
                    From = s.From,
                    To = s.To,
                    Q1 = s.Q1,
                    Q2 = s.Q2,
                    Q3 = s.Q3
                }
                );
            return Ok(scores);
        }
    }
}
