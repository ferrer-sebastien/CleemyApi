using Cleemy.Expenses.Data.Technical;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Cleemy.Expenses.Data.Expenses.Exceptions
{
    /// <summary>
    /// Exception levée lorsque le commentaire est vide.
    /// </summary>
    [Serializable]
    public sealed class EmptyCommentException : BusinessException
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="EmptyCommentException"/>.
        /// Cas d'un commentaire vide.
        /// </summary>
        public EmptyCommentException()
            : base("Aucun commentaire n'a été saisi !")
        {
        }

        private EmptyCommentException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
