using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitnessWebApi.Data;
using FitnessWebApi.Data.Dtos;
using FitnessWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace FitnessWebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DaysController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public DaysController(AppDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Day>>> GetDays()
        {
            var user  = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();    
            }
            var days = await _context.Days.Where(d => d.UserId == user.Id).ToListAsync();
            return Ok(days);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Day>> GetDay(int id)
        {
            var user  = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();    
            }
            
            var day = await _context.Days.FindAsync(id);
            if (day == null)
            {
                return NotFound();
            }

            if (day.UserId != user.Id)
            {
                return Forbid();
            }
            
            return day;
        }
        
        [HttpPost]
        public async Task<ActionResult<Day>> PostDay(CreateDayDto dayDto)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var day = new Day()
            {
                UserId = user.Id,
                Date = dayDto.Date,
            };
            _context.Days.Add(day);
            await _context.SaveChangesAsync();

            foreach (var mealDto in dayDto.Meals)
            {
                var dayMeal = new DayMeals()
                {
                    DayId = day.Id,
                    MealId = mealDto.MealId,
                    Time = mealDto.Time,
                    OrderNumber = mealDto.OrderNumber,
                };
                _context.DayMeals.Add(dayMeal);
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDay", new { id = day.Id }, day);
        }
    }
}
