using Softplan.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softplan.Juros.Service
{
    public class CalculoJuros : ICalculoJuros
    {
        private readonly ITaxaJuros _taxaJurosProvider;

        /// <summary>
        /// Utiliza o serviço de busca da taxa de juros através de injeção de dependência. 
        /// Caso fosse buscado diretamente consumindo a outra API (outra opção), esta parte não seria necessária
        /// </summary>
        /// <param name="taxaJurosProvider"></param>
        public CalculoJuros(ITaxaJuros taxaJurosProvider)
        {
            _taxaJurosProvider = taxaJurosProvider;
        }

        /// <summary>
        /// Efetua o cálculo de Juros compostos de acordo com a fórmula: Valor Final = Valor Inicial * ((1 + juros) ^ Tempo)
        /// A taxa de juros é 1% (fixo conforme solicitado)        
        /// </summary>
        /// <param name="valorInicial">Decimal que representa o valor inicial a ser calculado</param>
        /// <param name="meses">Inteiro que representa o tempo em meses</param>
        /// <returns>O valor calculado com juros, truncado em duas casas decimais sem arredondamento.</returns>
        public async Task<decimal> CalcularJuros(decimal valorInicial, int meses)
        {
            var taxaJuros = await _taxaJurosProvider.GetTaxaJuros();

            double juros = Math.Pow(1 + taxaJuros, meses);
            decimal valorFinal = valorInicial * Convert.ToDecimal(juros);

            //Trunca o valor para 2 casas decimais sem arredondar
            return valorFinal.Truncar(2);
        }
    }
}
