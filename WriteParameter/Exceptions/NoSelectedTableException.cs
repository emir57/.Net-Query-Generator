using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteParameter.Exceptions
{
    public class NoSelectedTableException : Exception
    {
        public NoSelectedTableException() : this("Seçili tablo yok")
        {

        }

        public NoSelectedTableException(string? message) : base(message)
        {
        }

        public NoSelectedTableException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
