using System.ComponentModel.DataAnnotations;
namespace EmployeesManagement.Models;

public class Instrument : UserActivity {
    public int Id { get; set; }
    [Required] public string TipoInstrumento { get; set; } = "";
    [Required] public string Nome { get; set; } = "";
    public bool UsaCordas { get; set; }
}