using Microsoft.AspNetCore.Mvc;

namespace Calcular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalcularController : ControllerBase
    {
        [HttpPut("Somar")]
        public Double Somar(int valor1, int valor2)
        {
            return valor1 + valor2;
        }

        [HttpPut("Subtrair")]
        public Double Subtrair([FromBody] Calcular b)
        {
            return b.valor1 - b.valor2;
        }
    }
}