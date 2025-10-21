using System.ComponentModel.DataAnnotations;

namespace practicaUno.Models;

public class Branch
{
    public int Id { get; set; }
    [Required]
    public string BranchCode { get; set; }
    [Required]
    public string BranchName { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public string Phone { get; set; }

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}