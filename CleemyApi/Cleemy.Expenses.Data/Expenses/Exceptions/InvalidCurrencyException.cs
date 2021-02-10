using Cleemy.Expenses.Data.Technical;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Cleemy.Expenses.Data.Expenses.Exceptions
{
    /// <summary>
    /// Exception levée lorsqu'une création de dépense dont la devise n'est pas identique à celle de l'utilisateur lié est tentée.
    /// </summary>
    [Serializable]
    public sealed class InvalidCurrencyException : BusinessException
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="InvalidCurrencyException"/>.
        /// Cas d'une dépense dont la devise n'est pas identique à la devise de l'utilisateur associé.
        /// </summary>
        public InvalidCurrencyException(string expenseCurrency, string userCurrency)
            : base("La devise de la dépense doit être identique à celle de l'utilisateur associé. Devise de la dépense : {0}; Devise de l'utilisateur : {1}", expenseCurrency, userCurrency)
        {
        }

        private InvalidCurrencyException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
