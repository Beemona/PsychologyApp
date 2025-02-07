using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PsychologyApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PsychologyApp.Controllers
{
    public class PsychologyAppContext : DbContext
    {
        public PsychologyAppContext(DbContextOptions<PsychologyAppContext> options)
            : base(options)
        {
        }

        public DbSet<QuestionnaireQuestion> QuestionnaireQuestions { get; set; }
        public DbSet<QuestionnaireAnswer> QuestionnaireAnswers { get; set; }
        public DbSet<PsychologyType> PsychologyTypes { get; set; }       
        public DbSet<PsychotherapyType> PsychotherapyTypes { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<MentalDisorder> MentalDisorders { get; set; }
    }

    public class QuestionnaireController : Controller
    {
        private readonly PsychologyAppContext _context;

        public QuestionnaireController(PsychologyAppContext context)
        {
            _context = context;
        }

        // Display the quiz
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Load all questions with their answers from the database
            var questions = await _context.QuestionnaireQuestions
                              .Include(q => q.Answers)
                              .ToListAsync();

            return View(questions);
        }

        [HttpPost]
        public async Task<IActionResult> Submit(IFormCollection form)
        {
            var selectedAnswers = form.Keys
                .Where(k => k.StartsWith("question_"))
                .Select(k => int.Parse(form[k]))
                .ToArray();

            if (selectedAnswers.Length == 0)
            {
                ModelState.AddModelError("", "Please answer all the questions.");
                return RedirectToAction("Index");
            }

            var answerDetails = await _context.QuestionnaireAnswers
                                              .Include(a => a.PsychologyType)
                                              .Include(a => a.PsychotherapyType)
                                              .Where(a => selectedAnswers.Contains(a.Id))
                                              .ToListAsync();

            var psychologyScores = answerDetails
                .Where(a => a.PsychologyTypeId != null)
                .GroupBy(a => a.PsychologyTypeId)
                .Select(g => new { TypeId = g.Key, AnswerCount = g.Count() })
                .OrderByDescending(g => g.AnswerCount)
                .FirstOrDefault();

            var psychotherapyScores = answerDetails
                .Where(a => a.PsychotherapyTypeId != null)
                .GroupBy(a => a.PsychotherapyTypeId)
                .Select(g => new { TypeId = g.Key, AnswerCount = g.Count() })
                .OrderByDescending(g => g.AnswerCount)
                .FirstOrDefault();

            var psychologyType = psychologyScores != null ? await _context.PsychologyTypes.FindAsync(psychologyScores.TypeId) : null;
            var psychotherapyType = psychotherapyScores != null ? await _context.PsychotherapyTypes.FindAsync(psychotherapyScores.TypeId) : null;

            string recommendation = "Your personalized recommendation:\n";
            if (psychologyType != null)
                recommendation += $"- Psychology Type: {psychologyType.Name}\n";
            if (psychotherapyType != null)
                recommendation += $"- Psychotherapy Type: {psychotherapyType.Name}\n";

            var viewModel = new QuizResultViewModel
            {
                Recommendation = $"Your personalized recommendation:\n- Psychology Type: {psychologyType?.Name}\n- Psychotherapy Type: {psychotherapyType?.Name}",
                PsychologyTypeId = psychologyType?.Id,
                PsychotherapyTypeId = psychotherapyType?.Id
            };

            return View("Result", viewModel);

        }

    }



    // Logic for generating recommendations based on score

}
