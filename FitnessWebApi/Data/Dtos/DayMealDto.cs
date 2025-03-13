using FitnessWebApi.Data.Enums;

namespace FitnessWebApi.Data.Dtos;

public class DayMealDto
{
    public int MealId { get; set; }
    public MealTime Time { get; set; }
    public int OrderNumber { get; set; }
}