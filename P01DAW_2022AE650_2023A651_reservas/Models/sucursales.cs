using System.ComponentModel.DataAnnotations;

namespace L01_2022AE650_2023CA651.Models
{
    public class sucursales
    {
        [Key]
        public int sucursales_id { get; set; }
        public int administrador_id { get; set; }
        public int usuario_id { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string administrador { get; set; }
        public int numeroEspacios { get; set; }
    }
}