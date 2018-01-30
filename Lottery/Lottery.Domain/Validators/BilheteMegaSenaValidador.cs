using FluentValidation;
using Lottery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lottery.Domain.Validators
{
    public class BilheteMegaSenaValidador : AbstractValidator<BilheteMegaSena>
    {

        public BilheteMegaSenaValidador()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("O Id deve ser maior que 0");

            RuleFor(x => x.Numeros)
                .Must(NumbersWithPermitedLenght)
                .WithMessage("Seu bilhete deve conter 6 números.")
                .Must(NumbersInTheRange)
                .WithMessage("Os numeros do seu bilhete deve estar entre 1 e 60.")
                .Must(NumbersWithRepeat)
                .WithMessage("A sequência não pode conter números repetidos.");

        }

        private bool NumbersWithRepeat(int[] numbers)
        {
            return !numbers.ToList().Where(n => numbers.Count(x => x == n) > 1).Any();            
        }

        private bool NumbersWithPermitedLenght(int[] numbers)
        {
            return numbers.Length == 6;
        }

        private bool NumbersInTheRange(int[] numbers)
        {
            return !numbers.ToList().Where(x => x < 1 || x > 60).Any();
        }

    }
}
