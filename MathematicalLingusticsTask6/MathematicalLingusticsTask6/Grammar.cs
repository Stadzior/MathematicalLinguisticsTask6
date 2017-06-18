using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalLingusticsTask6
{
    public class Grammar
    {
        public Production HeadProduction { get; set; }
        public HashSet<Production> Productions { get; set; }
    }
}
