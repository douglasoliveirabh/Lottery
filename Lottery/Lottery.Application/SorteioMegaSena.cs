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

        public ValidationResult RegistrarNovoBilhete(BilheteMegaSena bilhete)
        {
            if(bilhete.IsValid)
               ((List<BilheteMegaSena>)this.Bilhetes).Add(bilhete);
            
            return bilhete.ValidationResult;
        }

        public void Sortear()
        {                       
            NumerosSorteados = GeraSequenciaNumeros();
        }

        private int[] GeraSequenciaNumeros() {

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

        public List<BilheteMegaSena> ObtemVencedoresQuadra(int[] numerosSorteados)
        {
            return Bilhetes.Where(b => b.EhVencedorQuadra(numerosSorteados)).ToList();
        }

        public List<BilheteMegaSena> ObtemVencedoresQuina(int[] numerosSorteados)
        {
            return Bilhetes.Where(b => b.EhVencedorQuina(numerosSorteados)).ToList();
        }

        public List<BilheteMegaSena> ObtemVencedoresSena(int[] numerosSorteados)
        {
            return Bilhetes.Where(b => b.EhVencedorSena(numerosSorteados)).ToList();
        }

        public void GeraBilhetesAleatorios(int quantidadeBilhetes)
        {
            ((List<BilheteMegaSena>)this.Bilhetes).Clear();

            for (int i = 0; i < quantidadeBilhetes; i++)            
                this.RegistrarNovoBilhete(new BilheteMegaSena(i + 1, GeraSequenciaNumeros()));            
        }
    }
}
