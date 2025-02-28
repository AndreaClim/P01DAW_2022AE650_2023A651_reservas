using System.ComponentModel.DataAnnotations;

namespace L01_2022AE650_2023CA651.Models
{
    public class usuarios
    {
        [Key]
        public int usuario_id { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public string contrasena { get; set; }
        public string rol { get; set; } // "Cliente" o "Empleado"
    }
}