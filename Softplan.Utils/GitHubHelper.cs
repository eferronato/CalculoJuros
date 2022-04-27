namespace Softplan.Utils
{
    /// <summary>
    /// Classe utilizada para buscar a URL do GitHub    
    /// </summary>
    public static class GitHubHelper
    {
        /// <summary>
        /// Constante que representa a URL do código fonte no github
        /// </summary>
        public static readonly string GitHubUrl = "https://github.com/eferronato/CalculoJuros";

        /// <summary>
        /// Retorna a URL do código fonte. 
        /// Created by Elton Ferronato
        /// </summary>
        /// <returns>URL com o repositório do código fonte</returns>
        public static string GetURL()
        {
            return GitHubUrl;
        }
    }
}
