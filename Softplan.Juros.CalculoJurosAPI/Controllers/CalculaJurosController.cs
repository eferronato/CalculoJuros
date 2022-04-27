using Microsoft.AspNetCore.Mvc;
using Softplan.Juros.Service;
using System;
using System.Threading.Tasks;

namespace Softplan.Juros.CalculoJurosAPI.Controllers
{
    /// <summary>
    /// Classe que define o endpoint "/calculajuros"
    /// Autor: Elton Ferronato - 25/04/2022
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CalculaJurosController : ControllerBase
    {
        /// <summary>
        /// Efetua o cálculo de Juros compostos de acordo com a fórmula: Valor Final = Valor Inicial * ((1 + juros) ^ Tempo)        
        /// </summary>
        /// <param name="valorInicial">Decimal que representa o valor inicial a ser calculado</param>
        /// <param name="meses">Inteiro que representa o tempo em meses</param>
        /// <returns>O valor calculado com juros, truncado em duas casas decimais sem arredondamento.</returns>                
        [HttpGet]
        public async Task<ActionResult<string>> CalculaJuros([FromServices] ICalculoJuros calculoJuros,
            [FromQuery] decimal valorInicial,
            [FromQuery] int meses)
        {
            try
            {                
                var result = await calculoJuros.CalcularJuros(valorInicial, meses);
                return $"{result:0.00}";
            }
            catch (OverflowException)
            {
                return BadRequest("O valor informado é muito alto, por favor revise os parâmetros.");
            }
        }

        #region Outra opção, buscando a taxa de juros consumindo a outra API
        private async Task<double> GetTaxaJuros()
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var request = new System.Net.Http.HttpRequestMessage();
                request.RequestUri = new Uri("http://softplan.juros.taxajurosapi/taxaJuros"); //Nome usado no docker-compose
                var response = await client.SendAsync(request);
                return Convert.ToDouble(await response.Content.ReadAsStringAsync());
            }
        } 
        #endregion
    }
}
