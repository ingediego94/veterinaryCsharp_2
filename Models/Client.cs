using System.ComponentModel.DataAnnotations;

namespace practicaUno.Models;

public class Client
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string DocNumber { get; set; }
    
    [Required]
    public string Email { get; set; }
    
    [Required]
    public string Phone { get; set; }
    
    [Required]
    public bool Active { get; set; } = true;

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}