using Cleemy.Expenses.Data.Technical;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Cleemy.Expenses.Data.Expenses.Exceptions
{
    /// <summary>
    /// Exception levée lorsqu'une création de dépense ayant une date dans le futur est tentée.
    /// </summary>
    [Serializable]
    public sealed class ExpenseInTheFutureException : BusinessException
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="ExpenseInTheFutureException"/>.
        /// Cas d'une dépense datée dans le futur.
        /// </summary>
        public ExpenseInTheFutureException()
            : base("Cette dépense est datée dans le futur !")
        {
        }

        private ExpenseInTheFutureException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
