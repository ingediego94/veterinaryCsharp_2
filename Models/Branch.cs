namespace practicaUno.Models;

public class Branch
{
    public int Id { get; set; }
    public string BranchName { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}