using System.ComponentModel.DataAnnotations;
namespace EmployeesManagement.Models;

public enum TipoInstrumento {
    Cordofone,
    Aerofone,
    Membranofone,
    Idiofone
}

public class Instrument : UserActivity {
    public int Id { get; set; }
    [Required] public TipoInstrumento TipoInstrumento { get; set; }
    [Required] public string Nome { get; set; } = "";
    public bool UsaCordas { get; set; }
}