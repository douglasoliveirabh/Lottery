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

        private List<BilheteMegaSena> Apostas = new List<BilheteMegaSena>()
        {
            new BilheteMegaSena(1, new int[]{1, 3, 5, 7, 9, 11}),
            new BilheteMegaSena(2, new int[]{ 1, 3, 5, 7, 10, 12}),
            new BilheteMegaSena(3, new int[]{ 1, 3, 5, 7, 9, 13}),
            new BilheteMegaSena(4, new int[]{4, 6, 8, 10, 12, 14}),
        };



        [Fact]
        [Trait("SorteioMegaSenaTests", "ApplicationTests")]
        private void Deve_Testar_A_Obtencao_Dos_Vencedores_Da_Quadra()
        {
            var sorteioMegaSena = new SorteioMegaSena();
            foreach (var aposta in Apostas)
                sorteioMegaSena.RegistrarNovoBilhete(aposta);
            var vencedoresQuadra = sorteioMegaSena.ObtemVencedoresQuadra(numerosSorteados);
            Assert.True(vencedoresQuadra.Count == 1);
        }

        [Fact]
        [Trait("SorteioMegaSenaTests", "ApplicationTests")]
        private void Deve_Testar_A_Obtencao_Dos_Vencedores_Da_Quina()
        {
            var sorteioMegaSena = new SorteioMegaSena();
            foreach (var aposta in Apostas)
                sorteioMegaSena.RegistrarNovoBilhete(aposta);
            var vencedoresQuadra = sorteioMegaSena.ObtemVencedoresQuina(numerosSorteados);
            Assert.True(vencedoresQuadra.Count == 1);
        }

        [Fact]
        [Trait("SorteioMegaSenaTests", "ApplicationTests")]
        private void Deve_Testar_A_Obtencao_Dos_Vencedores_Da_Sena()
        {
            var sorteioMegaSena = new SorteioMegaSena();
            foreach (var aposta in Apostas)
                sorteioMegaSena.RegistrarNovoBilhete(aposta);
            var vencedoresQuadra = sorteioMegaSena.ObtemVencedoresSena(numerosSorteados);
            Assert.True(vencedoresQuadra.Count == 1);
        }


        [Fact]
        [Trait("SorteioMegaSenaTests", "ApplicationTests")]
        private void Deve_Testar_A_Geracao_De_Bilhetes_Aleatorios()
        {
            var sorteioMegaSena = new SorteioMegaSena();
            sorteioMegaSena.GeraBilhetesAleatorios(QUANTIDADE_BILHETES_ALEATORIOS);
            Assert.True(sorteioMegaSena.Bilhetes.Count == QUANTIDADE_BILHETES_ALEATORIOS);
        }


    }
}
