using Microsoft.AspNetCore.Mvc;
using MVCEventosExamen.Services;

namespace MVCEventosExamen.Controllers
{
    public class AIController : Controller
    {
        private readonly AiService _ai;

        public AIController(AiService ai)
        {
            _ai = ai;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string question)
        {
            var answer = await _ai.AskAsync(question);

            ViewData["answer"] = answer;

            return View();
        }
    }
}
