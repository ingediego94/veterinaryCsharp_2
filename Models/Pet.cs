using System.ComponentModel.DataAnnotations;

namespace practicaUno.Models;

public class Pet
{
    public int Id { get; set; }
    [Required]
    public string Specie { get; set; }
    
    [Required]
    public string Breed { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required, Range(0, 80, ErrorMessage = "Ages only between 0 and 80.")]
    public int Age { get; set; }
    
    [Required,RegularExpression("Male|Female", ErrorMessage = "Gender it can be 'Male' or 'Female'.")]
    public string Gender { get; set; }
    
    [Required] 
    public string Condition { get; set; } = "Not specified";

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}