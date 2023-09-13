using Microsoft.AspNetCore.Mvc;

namespace Calcular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalcularController : ControllerBase
    {
        [HttpPut("Somar")]
        public Double Somar([FromBody] Calcular a)
        {
            return a.valor1 + a.valor2;
        }

        [HttpPut("Subtrair")]
        public Double Subtrair([FromBody] Calcular b)
        {
            return b.valor1 - b.valor2;
        }
    }
}