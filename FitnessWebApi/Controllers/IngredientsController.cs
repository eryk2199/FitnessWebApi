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
public class IngredientsController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public IngredientsController(AppDbContext context, UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ingredient>>> GetIngredients()
    {
        return await _context.Ingredients.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Ingredient>> GetIngredient(int id)
    {
        var ingredient = await _context.Ingredients.FindAsync(id);
        if (ingredient == null)
        {
            return NotFound();
        }
        return Ok(ingredient);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateIngredient(CreateIngredientDto ingredientDto)
    {
        var ingredient = new Ingredient()
        {
            Name = ingredientDto.Name,
            Calories = ingredientDto.Calories,
            Unit = ingredientDto.Unit,
        };
        
        _context.Ingredients.Add(ingredient);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction("GetIngredient", new { id = ingredient.Id }, ingredient);
    }
}