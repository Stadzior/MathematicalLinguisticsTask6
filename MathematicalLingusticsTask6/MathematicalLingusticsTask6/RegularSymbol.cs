using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalLingusticsTask6
{
    public class RegularSymbol : ISymbol
    {
        public char Character { get; set; }

        public RegularSymbol(char character)
        {
            Character = character;
        }
    }
}
