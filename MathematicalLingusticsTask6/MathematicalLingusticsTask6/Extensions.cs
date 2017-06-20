using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalLingusticsTask6
{
    public static class Extensions
    {
        public static void MoveToNextSymbol(this Stack<Tuple<int, Expression>> stack)
        {
            var temp = stack.Pop();
            stack.Push(new Tuple<int, Expression>(temp.Item1 + 1, temp.Item2));
        }

        public static void SplitToDescendantStacks(this List<Stack<Tuple<int, Expression>>> stacks, Stack<Tuple<int, Expression>> stack)
        {
            var production = stack.Peek().Item2.Symbols[stack.Peek().Item1] as Production;

            foreach (var innerExpression in production.Expressions)
            {
                var innerStack = new Stack<Tuple<int, Expression>>(stack.Reverse());
                innerStack.Push(new Tuple<int, Expression>(0, innerExpression));
                stacks.Add(innerStack);
            }
            stacks.Remove(stack);
        }
    }
}
