using Cleemy.Expenses.Data.Technical;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Cleemy.Expenses.Data.Expenses.Exceptions
{
    /// <summary>
    /// Exception levée lorsqu'une création de dépense déjà déclarée est tentée.
    /// </summary>
    [Serializable]
    public sealed class DuplicateExpenseException : BusinessException
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="DuplicateExpenseException"/>.
        /// Cas d'une dépense déjà déclarée.
        /// </summary>
        public DuplicateExpenseException()
            : base("Cette dépense a déjà été déclarée !")
        {
        }

        private DuplicateExpenseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
