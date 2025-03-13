using FitnessWebApi.Data.Enums;

namespace FitnessWebApi.Models;

public class MealIngredients
{
    public int Id { get; set; }
    public int MealId { get; set; }
    public Meal Meal { get; set; }
    public int IngredientId { get; set; }
    public Ingredient Ingredient { get; set; }
    public int Amount { get; set; }
    public Unit Unit { get; set; }
}