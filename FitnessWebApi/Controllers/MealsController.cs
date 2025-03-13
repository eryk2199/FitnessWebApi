using FitnessWebApi.Data;
using FitnessWebApi.Data.Dtos;
using FitnessWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessWebApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class MealsController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public MealsController(AppDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Meal>>> GetMeals()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return Unauthorized();
        }
        var meals = await _context.Meals.Where(m => m.UserId == user.Id).ToListAsync();
        return Ok(meals);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Meal>> GetMeal(int id)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return Unauthorized();
        }
        
        var meal = await _context.Meals.FindAsync(id);
        if (meal == null)
        {
            return NotFound();
        }

        if (meal.UserId != user.Id)
        {
            return Forbid();
        }
        
        return Ok(meal);
    }

    [HttpPost]
    public async Task<ActionResult<Meal>> PostMeal(CreateMealDto mealDto)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return Unauthorized();
        }

        var meal = new Meal()
        {
            UserId = user.Id,
            Name = mealDto.Name,
            Calories = mealDto.Calories
        };
        
        _context.Meals.Add(meal);
        await _context.SaveChangesAsync();

        foreach (MealIngredientDto mealIngredientDto in mealDto.Ingredients)
        {
            var mealIngredient = new MealIngredients()
            {
                MealId = meal.Id,
                IngredientId = mealIngredientDto.IngredientId,
                Amount = mealIngredientDto.Amount,
                Unit = mealIngredientDto.Unit
            };
            _context.MealIngredients.Add(mealIngredient);
        }
        await _context.SaveChangesAsync();
        
        return CreatedAtAction("GetMeal", new { id = meal.Id }, meal);
    }
}