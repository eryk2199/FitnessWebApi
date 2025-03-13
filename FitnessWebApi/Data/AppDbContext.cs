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
    
    public DbSet<Day> Days { get; set; }
    public DbSet<Meal> Meals { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    
    public DbSet<MealIngredients> MealIngredients { get; set; }
    public DbSet<DayMeals> DayMeals { get; set; }

}