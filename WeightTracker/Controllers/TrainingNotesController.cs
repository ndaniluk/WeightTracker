using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeightTracker.Models;

namespace WeightTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainingNotesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TrainingNotesController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> AddNote([FromForm] TrainingNote trainingNote)
        {
            // var trainingRecord = new TrainingRecord {TimeStamp = DateTime.Now, TrainingNote = trainingNote};
            // await _context.TrainingRecords.AddAsync(trainingRecord);
            // await _context.TrainingNotes.AddAsync(trainingNote);
            // await _context.SaveChangesAsync();
            return Ok(trainingNote);
        }
    }
}