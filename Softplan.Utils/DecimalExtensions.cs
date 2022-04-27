using System;

namespace Softplan.Utils
{
    /// <summary>
    /// Classe com extension methods referentes o tipo decimal    
    /// </summary>
    public static class DecimalExtensions
    {
        /// <summary>
        /// Trunca o valor decimal conforme o número de casas
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="casas"></param>
        /// <returns></returns>
        public static decimal Truncar(this decimal valor, byte casas)
        {
            decimal result = Math.Round(valor, casas);

            if (valor > 0 && result > valor)
            {
                return result - new decimal(1, 0, 0, false, casas);
            }
            else if (valor < 0 && result < valor)
            {
                return result + new decimal(1, 0, 0, false, casas);
            }

            return result;
        }
    }
}
