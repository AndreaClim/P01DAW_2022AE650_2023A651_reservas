using P01DAW_2022AE650_2023A651_reservas.Models;
using Microsoft.EntityFrameworkCore;

namespace P01DAW_2022AE650_2023A651_reservas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class reservasController : ControllerBase
    {
        private readonly espaciosContext _reservasContexto;

        public reservasController(espaciosContext reservasContexto)
        {
            _reservasContexto = reservasContexto;
        }
    }
}
