using System;
using System.Collections.Generic;
using System.Linq;

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
                    if (stack.Any())
                    {
                        var expression = stack.Peek().Item2;

                        if (stack.Peek().Item1 < expression.Symbols.Count)
                        {
                            var follow = expression.Symbols[stack.Peek().Item1];

                            if (follow is Production)
                                ExpressionStacks.SplitToDescendantStacks(stack);
                            else
                            {
                                if (follow.Character.Equals(symbolCharacter))
                                {
                                    j++;
                                    stack.MoveToNextSymbol();
                                }
                                else if (follow.Character.Equals(new EmptySign().Character))
                                {
                                    stack.Pop();
                                    stack.MoveToNextSymbol();
                                }
                                else
                                    ExpressionStacks.Remove(stack);
                            }
                        }
                        else
                        {
                            stack.Pop();
                            if (!stack.Any())
                                j++;
                            else
                                stack.MoveToNextSymbol();
                        }
                    }
                    else
                        ExpressionStacks.Remove(stack);
                }

                isValid = ExpressionStacks.Any();
                if (!isValid)
                    break;
            }

            return isValid;
        }
    }
}
