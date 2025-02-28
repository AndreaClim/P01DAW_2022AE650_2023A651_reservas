using System.ComponentModel.DataAnnotations;

namespace P01DAW_2022AE650_2023A651_reservas.Models
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