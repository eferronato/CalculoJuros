using Microsoft.Extensions.DependencyInjection;
using Softplan.Juros.Service;

namespace Softplan.Juros.Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ITaxaJuros, TaxaJuros>();
            services.AddTransient<ICalculoJuros, CalculoJuros>();
        }
    }
}
