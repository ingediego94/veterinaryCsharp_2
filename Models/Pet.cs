using System.ComponentModel.DataAnnotations;

namespace practicaUno.Models;

public class Pet
{
    public int Id { get; set; }
    public string Specie { get; set; }
    public string Breed { get; set; }
    public string Name { get; set; }
    [Range(0, 80, ErrorMessage = "Ages only between 0 and 80.")]
    public int Age { get; set; }
    //[AllowedValues("Male","Female", ErrorMessage = "Gender it can be 'Male' or 'Female'.")]
    [RegularExpression("Male|Female", ErrorMessage = "Gender it can be 'Male' or 'Female'.")]
    public string Gender { get; set; }
    public string Condition { get; set; }

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}