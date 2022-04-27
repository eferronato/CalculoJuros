using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Softplan.Juros.CalculoJurosAPI;
using System.Net.Http;

namespace Softplan.CalculoJuros.IntegrationTests
{
    /// <summary>
    /// Classe que cria um client para realizar os testes de integração
    /// </summary>
    public class ClientContext
    {
        public HttpClient Client { get; set; }
        private TestServer _server;
        
        public ClientContext()
        {
            SetupClient();
        }

        private void SetupClient()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = _server.CreateClient();
        }
    }
}
