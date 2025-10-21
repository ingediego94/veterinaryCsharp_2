using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace practicaUno.Models;

public class Appointment
{
    public int Id { get; set; }
    
    [ForeignKey("Client"), Required]
    public int ClientId { get; set; }
    
    [ForeignKey("Pet"), Required]
    public int PetId { get; set; }
    
    [ForeignKey("Branch"), Required]
    public int BranchId { get; set; }
    
    [Required]
    public DateTime DayHour { get; set; }
    
    
    // relations 1:N
    [ValidateNever]
    public Client Client { get; set; }
    
    [ValidateNever]
    public Pet Pet { get; set; }
    
    [ValidateNever]
    public Branch Branch { get; set; }
    
}