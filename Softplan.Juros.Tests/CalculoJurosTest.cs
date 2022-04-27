using Softplan.Juros.Service;
using Xunit;

namespace Softplan.Juros.Tests
{
    /// <summary>
    /// Classe de teste para o ICalculoJuros    
    /// </summary>
    public class CalculoJurosTest
    {
        private ICalculoJuros _juros;

        public CalculoJurosTest(ICalculoJuros calculoJuros)
        {
            _juros = calculoJuros;
        }

        /// <summary>
        /// Resultado esperado: 105,10
        /// </summary>
        [Fact]
        public void CalcularJuros_Deve_Retornar_Valor_Correto()
        {
            Assert.Equal(105.10M, _juros.CalcularJuros(100, 5).Result);
            Assert.Equal(72256.96M, _juros.CalcularJuros(9876.543M, 200).Result);
            Assert.Equal(471941364.91M, _juros.CalcularJuros(3259876.543M, 500).Result);
        }

        /// <summary>
        /// Testa se está truncando corretamente em 2 casas sem arredondar
        /// </summary>
        [Fact]
        public void CalcularJuros_Deve_Truncar_Sem_Arredondar()
        {
            Assert.Equal(109.36M, _juros.CalcularJuros(100, 9).Result);
            Assert.Equal(111.56M, _juros.CalcularJuros(100, 11).Result);
        }

        /// <summary>
        /// Testa se possui exatamente 2 casas decimais
        /// </summary>
        [Fact]
        public void CalcularJuros_Deve_Retornar_Duas_Casas_Decimais()
        {
            const string DecimalSeparator = ",";
            var value = _juros.CalcularJuros(100, 5).Result.ToString();

            Assert.Contains(DecimalSeparator, value);
            Assert.Equal(2, value.Substring(value.LastIndexOf(DecimalSeparator) + 1).Length);
        }
    }
}
