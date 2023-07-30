using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleDotnetCoreService.Models;

namespace SampleDotnetCoreService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraineesController : ControllerBase
    {
        //U can create a Repository pattern class with interface and inject it in the Controller using DI feature of ASP.NET CORE. 
        private readonly TraineeDbContext _context;
        public TraineesController(TraineeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Trainee>> GetTrainees() => _context.Trainees;

        [HttpGet("{traineeId:int}")]
        public async Task<ActionResult<Trainee>> GetById(int traineeId)
        {
            return await _context.Trainees.FindAsync(traineeId);
        }

        [HttpPost]
        public async Task<ActionResult> AddNewTrainee(Trainee res)
        {
            await _context.Trainees.AddAsync(res);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateTrainee(Trainee res)
        {
            _context.Trainees.Update(res);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{traineeId:int}")]
        public async Task<ActionResult> DeleteTrainee(int traineeId)
        {
            var trainee = await _context.Trainees.FindAsync(traineeId);
            if (trainee == null)
            {
                return BadRequest("Trainee is not found");
            }
            _context.Trainees.Remove(trainee);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
