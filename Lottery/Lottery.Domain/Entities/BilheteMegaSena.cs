using FluentValidation.Results;
using Lottery.Domain.Validators;
using System;
using System.Linq;


namespace Lottery.Domain.Entities
{

    //Bilhete mega sena
    public class BilheteMegaSena : Entidade
    {

        public int Id { get; private set; }
        public DateTime DataHoraAposta { get; private set; }
        public int[] Numeros { get; private set; }

        public BilheteMegaSena(int id, int[] numeros)
        {
            this.Id = id;
            this.DataHoraAposta = DateTime.Now;
            this.Numeros = numeros;
        }

        public override bool IsValid
        {
            get
            {
                var validator = new BilheteMegaSenaValidador();
                ValidationResult = validator.Validate(this);

                return ValidationResult.IsValid;
            }
        }

        public bool EhVencedorQuadra(int[] numerosSorteados)
        {
            return PossuiNumeroAcertos(4, numerosSorteados);
        }

        public bool EhVencedorQuina(int[] numerosSorteados)
        {
            return PossuiNumeroAcertos(5, numerosSorteados);
        }

        public bool EhVencedorSena(int[] numerosSorteados)
        {
            return PossuiNumeroAcertos(6, numerosSorteados);
        }

        private bool PossuiNumeroAcertos(int numeroAcertos, int[] numerosSorteados)
        {          
            var acertos = numerosSorteados.ToList().Where(x => Numeros.Contains(x)).ToList();
            return acertos.Count() == numeroAcertos;
        }

    }
}
