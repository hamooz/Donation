namespace JustGiving.Exercise.Models
{
    public interface IValidation
    {
        ValidationResult Validate(decimal amount);
    }
}