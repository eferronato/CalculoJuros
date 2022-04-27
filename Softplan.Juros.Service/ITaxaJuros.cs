using System;
using System.Threading.Tasks;

namespace Softplan.Juros.Service
{
    public interface ITaxaJuros
    {
        Task<double> GetTaxaJuros();
    }
}
