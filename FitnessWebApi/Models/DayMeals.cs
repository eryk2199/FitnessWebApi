using FitnessWebApi.Data.Enums;

namespace FitnessWebApi.Models;

public class DayMeals
{
    public int Id { get; set; }
    public int MealId { get; set; }
    public Meal Meal { get; set; }
    public int DayId { get; set; }
    public Day Day { get; set; }
    public int OrderNumber { get; set; }
    public MealTime Time { get; set; }
}