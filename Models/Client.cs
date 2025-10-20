namespace practicaUno.Models;

public class Client
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string DocNumber { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public bool Active { get; set; }

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}