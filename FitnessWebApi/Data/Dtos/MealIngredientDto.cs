using FitnessWebApi.Data.Enums;

namespace FitnessWebApi.Data.Dtos;

public class MealIngredientDto
{
    public int IngredientId { get; set; }
    public int Amount { get; set; }
    public Unit Unit { get; set; }
}