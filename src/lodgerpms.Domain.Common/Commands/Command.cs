
using System;
using FluentValidation.Results;

namespace lodgerpms.Domain.Common.Commands
{
    public abstract class Command : lodgerpms.Domain.Common.Events.Message
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}
