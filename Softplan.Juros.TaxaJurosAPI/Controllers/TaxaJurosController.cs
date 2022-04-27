using Microsoft.AspNetCore.Mvc;
using Softplan.Juros.Service;
using System.Threading.Tasks;

namespace Softplan.Juros.TaxaJurosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxaJurosController : ControllerBase
    {
        /// <summary>
        /// Retorna a taxa de juros atual
        /// </summary>
        /// <param name="taxaJurosProvider"></param>
        /// <returns>A taxa de juros com duas casas decimais. Exemplo: 0,01</returns>
        [HttpGet]
        public async Task<string> Get([FromServices] ITaxaJuros taxaJurosProvider)
        {
            var result = await taxaJurosProvider.GetTaxaJuros();

            //Retorna como string para obter o resultado no formato esperado: 0,01 (vírgula como separador de casas decimais) 
            return $"{result:0.00}";
        }
    }
}
