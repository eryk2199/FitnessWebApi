using FitnessWebApi.Data.Enums;

namespace FitnessWebApi.Data.Dtos;

public class CreateIngredientDto
{
    public string Name { get; set; }
    public int Calories { get; set; } //calories per 100 of unit
    public Unit Unit { get; set; }
}