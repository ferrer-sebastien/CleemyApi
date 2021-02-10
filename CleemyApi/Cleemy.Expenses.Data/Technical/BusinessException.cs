using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Cleemy.Expenses.Data.Technical
{
    [Serializable]
    public abstract class BusinessException : Exception
    {
        protected BusinessException()
        {
        }

        protected BusinessException(string message, params object[] args)
            : base(string.Format(message, args))
        {
        }

        protected BusinessException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected BusinessException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
