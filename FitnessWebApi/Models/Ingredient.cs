using FitnessWebApi.Data.Enums;

namespace FitnessWebApi.Models;

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Calories { get; set; } //calories per 100 of unit
    public Unit Unit { get; set; }

}