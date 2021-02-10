using Cleemy.Expenses.Data.Technical;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Cleemy.Expenses.Data.Expenses.Exceptions
{
    /// <summary>
    /// Exception levée lorsqu'une création de dépense datée de plus de 3 mois est tentée.
    /// </summary>
    [Serializable]
    public sealed class OutdatedExpenseException : BusinessException
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="OutdatedExpenseException"/>.
        /// Cas d'une dépense datée de plus de 3 mois.
        /// </summary>
        public OutdatedExpenseException(int days)
            : base("Cette dépense est datée de plus de 3 mois ! (ancienneté de la dépense : {0} jours)", days)
        {
        }

        private OutdatedExpenseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
