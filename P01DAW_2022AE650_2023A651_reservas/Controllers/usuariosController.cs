using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P01DAW_2022AE650_2023A651_reservas.Models;
using Microsoft.EntityFrameworkCore;


namespace P01DAW_2022AE650_2023A651_reservas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usuariosController : ControllerBase
    {
        private readonly usuariosContext _usuariosContext;
        public usuariosController(usuariosContext usuariosContext)
        {
            _usuariosContext = usuariosContext;
        }
    }
}
