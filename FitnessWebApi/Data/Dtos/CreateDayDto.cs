using FitnessWebApi.Models;

namespace FitnessWebApi.Data.Dtos;

public class CreateDayDto
{
    public DateTime Date { get; set; }
    public List<DayMealDto> Meals { get; set; }
}