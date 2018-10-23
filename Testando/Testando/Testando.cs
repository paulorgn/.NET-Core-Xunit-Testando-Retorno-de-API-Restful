using System;
using Xunit;
using Testando.DTOs;
using Testando.Servicos;

namespace Testando
{
    public class Testando
    {
        [Fact]
        public void DADO_oRetornoDaApi_QUANDO_oTituloForIgualAMeuTeste_ENTAO_oTesteTeraSucesso()
        {
            ApiDeTeste apiDeTeste = new ApiDeTeste();

            DtoRetornoDaAPI retornoDaAPI = apiDeTeste.PegarRetornoDaAPI();
            if (retornoDaAPI != null)
            {
                string titulo = retornoDaAPI.title;

                Assert.Same("MeuTeste", titulo);
            }
        }
    }
}
