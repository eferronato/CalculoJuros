using Softplan.Utils;
using System;
using Xunit;

namespace Softplan.Juros.Tests
{
    /// <summary>
    /// Classe de teste para o GitHubHelper    
    /// </summary>
    public class GitHubHelperTest
    {
        [Fact]
        public void GetURL_Deve_Retornar_URL_Correta()
        {            
            Assert.Equal(GitHubHelper.GitHubUrl, GitHubHelper.GetURL());
        }

        [Fact]
        public void GetURL_Deve_Retornar_URL_Valida()
        {            
            Assert.True(Uri.IsWellFormedUriString(GitHubHelper.GetURL(), UriKind.Absolute));
        }
    }
}
