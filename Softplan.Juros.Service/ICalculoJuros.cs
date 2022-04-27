using System;
using System.Threading.Tasks;

namespace Softplan.Juros.Service
{
    public interface ICalculoJuros
    {
        Task<decimal> CalcularJuros(decimal valorInicial, int meses);
    }
}
