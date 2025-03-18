using System;

namespace Xadrez.Domain.Core.Exceptions
{
    internal class TabuleiroException : Exception
    {
        public TabuleiroException(string msg) : base(msg) { }
    }
}
