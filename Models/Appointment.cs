using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace practicaUno.Models;

public class Appointment
{
    public int Id { get; set; }
    [ForeignKey("Client")]
    public int ClientId { get; set; }
    [ForeignKey("Pet")]
    public int PetId { get; set; }
    [ForeignKey("Branch")]
    public int BranchId { get; set; }
    public DateTime DayHour { get; set; }
    
    
    // relations 1:N
    [ValidateNever]
    public Client Client { get; set; }
    [ValidateNever]
    public Pet Pet { get; set; }
    [ValidateNever]
    public Branch Branch { get; set; }
    
}