using FluentValidation.Results;

namespace Lottery.Domain.Entities
{
    public abstract class Entidade
    {        
        protected ValidationResult _validationResult;
        public virtual ValidationResult ValidationResult { get => _validationResult; protected set => _validationResult = value; }
        public abstract bool IsValid { get; }
    }

}
