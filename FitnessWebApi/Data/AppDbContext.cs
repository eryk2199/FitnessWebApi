using FitnessWebApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessWebApi.Data;

public class AppDbContext : IdentityDbContext<IdentityUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .Entity<DayMeals>()
            .Property(d => d.Time)
            .HasConversion<string>();
        
        modelBuilder
            .Entity<Ingredient>()
            .Property(i => i.Unit)
            .HasConversion<string>();
    }
    
    DbSet<Day> Days { get; set; }
    DbSet<Meal> Meals { get; set; }
    DbSet<Ingredient> Ingredients { get; set; }
    
    DbSet<MealIngredients> MealIngredients { get; set; }
    DbSet<DayMeals> DayMeals { get; set; }

}