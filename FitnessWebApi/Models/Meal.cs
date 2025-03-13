using Microsoft.AspNetCore.Identity;

namespace FitnessWebApi.Models;

public class Meal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Calories { get; set; }
    public string UserId { get; set; }
    public IdentityUser User { get; set; }
}