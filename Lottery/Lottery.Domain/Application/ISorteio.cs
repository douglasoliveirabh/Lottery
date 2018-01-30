using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lottery.Domain.Application
{
    /// <summary>
    /// Class that specify the contract to implement any types of lottery 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISorteio<T>
    {
        ValidationResult RegistrarNovoBilhete(int[] numerosBilhete);
        void Sortear();        
    }
}
