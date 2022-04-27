using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softplan.Juros.Service
{
    public class TaxaJuros : ITaxaJuros
    {
        private const double TaxaDeJuros = 0.01;

        public async Task<double> GetTaxaJuros()
        {
            //Retorna o juros de 1% ou 0,01 (fixo no código) 
            //Aqui poderia ter a busca da taxa de juros do cache, banco, etc, ou conforme regras definidas

            return await Task.FromResult(TaxaDeJuros);
        }
    }
}
