using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathematicalLingusticsTask6
{
    public class Production : ISymbol
    {
        public List<Expression> Expressions { get; set; }
        public char Character { get; set; }
        public HashSet<char> GetFirstSet()
        {
            var firstSet = new HashSet<char>();
            foreach (var expression in Expressions)
            {
                var firstSymbol = expression.Symbols.First();
                if (firstSymbol is Production)
                {
                    firstSet.UnionWith((firstSymbol as Production).GetFirstSet());
                }
                else
                    firstSet.Add(firstSymbol.Character);
            }
            return firstSet;
        }

        public override string ToString()
        {
            var stringValueBuilder = new StringBuilder();
            if (Expressions.Any())
            {
                foreach (var expression in Expressions)
                {
                    stringValueBuilder.Append(expression.ToString());
                    stringValueBuilder.Append(" | ");
                }
                stringValueBuilder.Remove(stringValueBuilder.Length - 3, 3);
            }
            return stringValueBuilder.ToString();
        }
    }
}