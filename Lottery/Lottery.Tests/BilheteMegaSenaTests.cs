using Lottery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Lottery.Tests
{

    public class BilheteMegaSenaTests
    {
        private const int IdBilheteValido = 5;
        private const int IdBilheteInValido = 0;
        private int[] TamanhoArrayNumerosValido = { 2, 22, 33, 5, 10, 11 };
        private int[] TamanhoArrayNumerosInValido = { 2, 22, 33, 5, 10 };

        private int[] ArrayNumerosComRangeValido = { 2, 22, 33, 5, 10, 11 };
        private int[] ArrayNumerosComRangeInValido = { 0, 22, 33, 5, 10, 61 };

        private int[] SequenciaAcertosParaQuadra = { 2, 22, 33, 5, 55, 60 };
        private int[] SequenciaAcertosParaQuina = { 2, 22, 33, 5, 10, 60 };
        private int[] SequenciaAcertosParaSena = { 2, 22, 33, 5, 10, 11 };
        private int[] SequenciaSemAcertos = { 1, 21, 32, 4, 9, 8 };


        [Fact]
        [Trait("BilheteMegaSena", "DomainTests")]
        private void Deve_Testar_BilheteMegaSena_Com_Id_Valido()
        {            
            var bilheteMegaSena = new BilheteMegaSena(IdBilheteValido, TamanhoArrayNumerosValido);
            var valid = bilheteMegaSena.IsValid;
            Assert.True(valid);
        }

        [Fact]
        [Trait("BilheteMegaSena", "DomainTests")]
        private void Deve_Testar_BilheteMegaSena_Com_Id_InValido()
        {         
            var bilheteMegaSena = new BilheteMegaSena(IdBilheteInValido, TamanhoArrayNumerosValido);
            var valid = bilheteMegaSena.IsValid;
            Assert.False(valid);
        }

        [Fact]
        [Trait("BilheteMegaSena", "DomainTests")]
        private void Deve_Testar_BilheteMegaSena_Com_Quantidade_Numeros_Correta()
        {            
            var bilheteMegaSena = new BilheteMegaSena(IdBilheteValido, TamanhoArrayNumerosValido);
            var valid = bilheteMegaSena.IsValid;
            Assert.True(valid);
        }

        [Fact]
        [Trait("BilheteMegaSena", "DomainTests")]
        private void Deve_Testar_BilheteMegaSena_Com_Quantidade_Numeros_InCorreta()
        {            
            var bilheteMegaSena = new BilheteMegaSena(IdBilheteValido, TamanhoArrayNumerosInValido);
            var valid = bilheteMegaSena.IsValid;
            Assert.False(valid);
        }

        [Fact]
        [Trait("BilheteMegaSena", "DomainTests")]
        private void Deve_Testar_BilheteMegaSena_Com_Range_Numeros_InCorreta()
        {            
            var bilheteMegaSena = new BilheteMegaSena(IdBilheteValido, ArrayNumerosComRangeValido);
            var valid = bilheteMegaSena.IsValid;
            Assert.True(valid);
        }

        [Fact]
        [Trait("BilheteMegaSena", "DomainTests")]
        private void Deve_Testar_BilheteMegaSena_Com_Range_Numeros_Correta()
        {            
            var bilheteMegaSena = new BilheteMegaSena(IdBilheteValido, ArrayNumerosComRangeInValido);
            var valid = bilheteMegaSena.IsValid;
            Assert.False(valid);
        }

        [Fact]
        [Trait("BilheteMegaSena", "DomainTests")]
        private void Deve_Testar_Sequencia_Sem_Acertos()
        {
            var bilheteMegaSena = new BilheteMegaSena(IdBilheteValido, ArrayNumerosComRangeValido);

            var valid = !bilheteMegaSena.EhVencedorQuadra(SequenciaSemAcertos) &&
                        !bilheteMegaSena.EhVencedorQuina(SequenciaSemAcertos) &&
                        !bilheteMegaSena.EhVencedorSena(SequenciaSemAcertos);

            Assert.True(valid);
        }

        [Fact]
        [Trait("BilheteMegaSena", "DomainTests")]
        private void Deve_Testar_Sequencia_Com_Acerto_Na_Quadra()
        {
            var bilheteMegaSena = new BilheteMegaSena(IdBilheteValido, ArrayNumerosComRangeValido);

            var valid = bilheteMegaSena.EhVencedorQuadra(SequenciaAcertosParaQuadra) &&
                        !bilheteMegaSena.EhVencedorQuina(SequenciaAcertosParaQuadra) &&
                        !bilheteMegaSena.EhVencedorSena(SequenciaAcertosParaQuadra);

            Assert.True(valid);
        }

        [Fact]
        [Trait("BilheteMegaSena", "DomainTests")]
        private void Deve_Testar_Sequencia_Com_Acerto_Na_Quina()
        {
            var bilheteMegaSena = new BilheteMegaSena(IdBilheteValido, ArrayNumerosComRangeValido);

            var valid = !bilheteMegaSena.EhVencedorQuadra(SequenciaAcertosParaQuina) &&
                        bilheteMegaSena.EhVencedorQuina(SequenciaAcertosParaQuina) &&
                        !bilheteMegaSena.EhVencedorSena(SequenciaAcertosParaQuina);

            Assert.True(valid);
        }

        [Fact]
        [Trait("BilheteMegaSena", "DomainTests")]
        private void Deve_Testar_Sequencia_Com_Acerto_Na_Sena()
        {
            var bilheteMegaSena = new BilheteMegaSena(IdBilheteValido, ArrayNumerosComRangeValido);

            var valid = !bilheteMegaSena.EhVencedorQuadra(SequenciaAcertosParaSena) &&
                        !bilheteMegaSena.EhVencedorQuina(SequenciaAcertosParaSena) &&
                        bilheteMegaSena.EhVencedorSena(SequenciaAcertosParaSena);

            Assert.True(valid);
        }



    }
}
