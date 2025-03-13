namespace FitnessWebApi.Data.Dtos;

public class CreateMealDto
{
    public string Name { get; set; }
    public int Calories { get; set; }
    public List<MealIngredientDto> Ingredients { get; set; }
}