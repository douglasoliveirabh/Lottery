using Lottery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Lottery.Application;

namespace Lottery.Tests
{
    public class SorteioMegaSenaTests
    {
        private int[] numerosSorteados = new int[] { 1, 3, 5, 7, 9, 13};
        private const int QUANTIDADE_BILHETES_ALEATORIOS = 10;
        private SorteioMegaSena sorteio;

        private List<int[]> Apostas = new List<int[]>
        {
            new int[]{1, 3, 5, 7, 9, 11},
            new int[]{ 1, 3, 5, 7, 10, 12},
            new int[]{ 1, 3, 5, 7, 9, 13},
            new int[]{4, 6, 8, 10, 12, 14},
        };

        public SorteioMegaSenaTests()
        {
            sorteio = PreparaApostas();
        }

        private SorteioMegaSena PreparaApostas() {
            var sorteioMegaSena = new SorteioMegaSena(numerosSorteados);
            foreach (var aposta in Apostas)
                sorteioMegaSena.RegistrarNovoBilhete(aposta);

            return sorteioMegaSena;
        }

        [Fact]
        [Trait("SorteioMegaSenaTests", "ApplicationTests")]
        private void Deve_Testar_A_Obtencao_Dos_Vencedores_Da_Quadra()
        {                       
            Assert.True(sorteio.ObtemVencedoresQuadra().Count == 1);
        }

        [Fact]
        [Trait("SorteioMegaSenaTests", "ApplicationTests")]
        private void Deve_Testar_A_Obtencao_Dos_Vencedores_Da_Quina()
        {            
            Assert.True(sorteio.ObtemVencedoresQuina().Count == 1);
        }

        [Fact]
        [Trait("SorteioMegaSenaTests", "ApplicationTests")]
        private void Deve_Testar_A_Obtencao_Dos_Vencedores_Da_Sena()
        {            
            Assert.True(sorteio.ObtemVencedoresSena().Count == 1);
        }

        [Fact]
        [Trait("SorteioMegaSenaTests", "ApplicationTests")]
        private void Deve_Testar_A_Geracao_De_Bilhetes_Aleatorios()
        {            
            sorteio.GeraBilhetesAleatorios(QUANTIDADE_BILHETES_ALEATORIOS);
            Assert.True(sorteio.Bilhetes.Count == QUANTIDADE_BILHETES_ALEATORIOS);
        }


    }
}
