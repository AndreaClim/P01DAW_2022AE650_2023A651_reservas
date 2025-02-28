using System.ComponentModel.DataAnnotations;
namespace P01DAW_2022AE650_2023A651_reservas.Models
{
    public class reservas
    {
        [Key]
        public int reservas_id { get; set; }
        public int id_espacios { get; set; }
        public int id_usuario { get; set; }
        public string fecha { get; set; }
        public string horaI { get; set; }
        public string horasR { get; set; }
        public string estado { get; set; }
    }
}
