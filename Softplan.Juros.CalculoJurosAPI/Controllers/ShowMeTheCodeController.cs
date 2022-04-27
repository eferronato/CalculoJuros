using Microsoft.AspNetCore.Mvc;
using Softplan.Utils;

namespace CalcJuros.Controllers
{
    /// <summary>
    /// Classe que define o endpoint "/showmethecode"
    /// Autor: Elton Ferronato - 25/04/2022
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ShowMeTheCodeController : ControllerBase
    {
        /// <summary>
        /// Retorna a URL do código fonte no GitHub. 
        /// Created by Elton Ferronato
        /// </summary>
        /// <returns>URL com o repositório do código fonte</returns>
        [HttpGet("")]
        public ActionResult<string> ShowMeTheCode()
        {
            return GitHubHelper.GetURL();
        }
    }
}