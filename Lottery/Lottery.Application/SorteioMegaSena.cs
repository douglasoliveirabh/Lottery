using FluentValidation.Results;
using Lottery.Domain.Application;
using Lottery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Application
{
    public class SorteioMegaSena : ISorteioMegaSena
    {
        public int[] NumerosSorteados { get; private set; }
        public IReadOnlyCollection<BilheteMegaSena> Bilhetes { get; private set; }

        public SorteioMegaSena()
        {
            Bilhetes = new List<BilheteMegaSena>();
            NumerosSorteados = new int[] { };
        }

        public void Clear()
        {
            ((List<BilheteMegaSena>)Bilhetes).Clear();
            Array.Clear(NumerosSorteados, 0, NumerosSorteados.Length);
        }

        //Construtor criado para efeito de testes
        // Eu poderia usar um MOQ mas o tempo estava apertado para essa implementação
        public SorteioMegaSena(int[] numerosSorteados)
        {
            Bilhetes = new List<BilheteMegaSena>();
            NumerosSorteados = numerosSorteados;
        }

        public ValidationResult RegistrarNovoBilhete(int[] numerosDoBilhete)
        {
            var newId = Bilhetes.Count > 0 ? Bilhetes.Max(x => x.Id) + 1 : 1;
            var novoBilhete = new BilheteMegaSena(newId, numerosDoBilhete);

            if (novoBilhete.IsValid)
                ((List<BilheteMegaSena>)this.Bilhetes).Add(novoBilhete);

            return novoBilhete.ValidationResult;
        }

        public void Sortear()
        {
            NumerosSorteados = GeraSequenciaNumeros();
        }

        private int[] GeraSequenciaNumeros()
        {

            var numeros = new List<int>();
            var rand = new Random();

            do
            {
                var proximo = rand.Next(1, 60);

                if (!numeros.Contains(proximo))
                    numeros.Add(proximo);
            }
            while (numeros.Count() < 6);

            return numeros.ToArray();
        }



        public List<BilheteMegaSena> ObtemBilhetesSemAcerto()
        {
            return Bilhetes.Where(b => b.NaoPossuiAcertos(this.NumerosSorteados)).ToList();
        }

        public List<BilheteMegaSena> ObtemBilhetesComUmAcerto()
        {
            return Bilhetes.Where(b => b.PossuiUmAcerto(this.NumerosSorteados)).ToList();
        }

        public List<BilheteMegaSena> ObtemBilhetesComDoisAcertos()
        {
            return Bilhetes.Where(b => b.PossuiDoisAcertos(this.NumerosSorteados)).ToList();
        }

        public List<BilheteMegaSena> ObtemBilhetesComTresAcertos()
        {
            return Bilhetes.Where(b => b.PossuiTresAcertos(this.NumerosSorteados)).ToList();
        }

        public List<BilheteMegaSena> ObtemVencedoresQuadra()
        {
            return Bilhetes.Where(b => b.EhVencedorQuadra(this.NumerosSorteados)).ToList();
        }

        public List<BilheteMegaSena> ObtemVencedoresQuina()
        {
            return Bilhetes.Where(b => b.EhVencedorQuina(this.NumerosSorteados)).ToList();
        }

        public List<BilheteMegaSena> ObtemVencedoresSena()
        {
            return Bilhetes.Where(b => b.EhVencedorSena(this.NumerosSorteados)).ToList();
        }

        public void GeraBilhetesAleatorios(int quantidadeBilhetes)
        {
            ((List<BilheteMegaSena>)this.Bilhetes).Clear();

            for (int i = 0; i < quantidadeBilhetes; i++)
                this.RegistrarNovoBilhete(GeraSequenciaNumeros());
        }
    }
}
