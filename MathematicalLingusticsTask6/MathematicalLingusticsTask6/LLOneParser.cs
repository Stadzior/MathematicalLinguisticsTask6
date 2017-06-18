using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalLingusticsTask6
{
    public class LLOneParser : ISyntaxParser
    {
        public Grammar Grammar { get; set; }
        public List<Stack<Tuple<int, Expression>>> ExpressionStacks { get; set; }

        public bool Parse(string input)
        {
            var isValid = true;
            ExpressionStacks = new List<Stack<Tuple<int,Expression>>>();
            foreach (var expression in Grammar.HeadProduction.Expressions)
            {
                var expressionStack = new Stack<Tuple<int, Expression>>();
                expressionStack.Push(new Tuple<int, Expression>(0, expression));
                ExpressionStacks.Add(expressionStack);
            }

            for (int i = 0; i < input.Length; i++)
            { 
                var symbolCharacter = input[i];
                int j = 0;
                while (j < ExpressionStacks.Count)
                {
                    var stack = ExpressionStacks[j];
                    var expression = stack.Peek().Item2;
                    var correctedIndex = i - stack.Peek().Item1;
                    if (correctedIndex < expression.Symbols.Count)
                    {
                        if (expression.Symbols[correctedIndex] is Production)
                        {
                            var production = expression.Symbols[correctedIndex] as Production;
                            foreach (var innerExpression in production.Expressions)
                            {
                                var innerStack = new Stack<Tuple<int, Expression>>(stack.Reverse());
                                innerStack.Push(new Tuple<int, Expression>(i, innerExpression));
                                ExpressionStacks.Add(innerStack);
                            }

                            if (production.IsPrime)
                                stack.Pop();
                            else
                                ExpressionStacks.Remove(stack);
                        }
                        else
                        {
                            if (expression.Symbols[correctedIndex].Character.Equals(symbolCharacter))
                                j++;
                            else
                                ExpressionStacks.Remove(stack);
                        }
                    }
                    else
                    {
                        stack.Pop();  
                        if (!stack.Any())
                            j++;
                    }                
                }

                isValid = ExpressionStacks.Any();
                if (!isValid)
                    break;
            }
            return isValid;
        }


    }
}
