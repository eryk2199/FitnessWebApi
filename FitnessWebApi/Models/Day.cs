using Microsoft.AspNetCore.Identity;

namespace FitnessWebApi.Models;

public class Day
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string UserId { get; set; }
    public IdentityUser User { get; set; }
}
