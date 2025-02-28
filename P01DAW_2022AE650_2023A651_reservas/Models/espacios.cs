using System.ComponentModel.DataAnnotations;
namespace P01DAW_2022AE650_2023A651_reservas.Models

{
    public class espacios
    {
        public int espacios_id { get; set; }
        public int sucursales_id { get; set; }
        public int numero { get; set; }
        public string ubicacion { get; set; }
        public double costo { get; set; }
        public string estado { get; set; }
    }
}
