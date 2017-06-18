using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalLingusticsTask6
{
    public class EmptySign : ISymbol
    {
        public char Character { get; private set; }
        public EmptySign()
        {
            Character = 'ɛ';
        }
    }
}
