using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez.Domain.Core.Enums;
using Xadrez.Domain.Core.Models.Tabuleiro;

namespace Xadrez.Domain.Application.UseCases.Xadrez
{
    internal class Torre : Peca // KING
    {
        public Torre(Tabuleiro tab, EnumCor cor) : base(tab, cor) { }

        public override string ToString() => "T";
    }
}
