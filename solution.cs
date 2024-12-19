Here is a C# console application that converts an infix expression to postfix and evaluates it:

```C#
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter infix expression");
        string infix = Console.ReadLine();
        string postfix = InfixToPostfix(infix);
        Console.WriteLine("Postfix expression: " + postfix);
        Console.WriteLine("Evaluation: " + EvaluatePostfix(postfix));
    }

    static int Precedence(char ch)
    {
        switch (ch)
        {
            case '+':
            case '-':
                return 1;

            case '*':
            case '/':
                return 2;

            case '^':
                return 3;
        }
        return -1;
    }

    static string InfixToPostfix(string infix)
    {
        Stack<char> stack = new Stack<char>();
        string postfix = string.Empty;

        for (int i = 0; i < infix.Length; i++)
        {
            char ch = infix[i];

            if (char.IsLetterOrDigit(ch))
                postfix += ch;

            else if (ch == '(')
                stack.Push(ch);

            else if (ch == ')')
            {
                while (stack.Count != 0 && stack.Peek() != '(')
                    postfix += stack.Pop();

                if (stack.Count != 0 && stack.Peek() != '(')
                    return "Invalid Expression";
                else
                    stack.Pop();
            }
            else
            {
                while (stack.Count != 0 && Precedence(ch) <= Precedence(stack.Peek()))
                    postfix += stack.Pop();
                stack.Push(ch);
            }
        }

        while (stack.Count != 0)
            postfix += stack.Pop();

        return postfix;
    }

    static int EvaluatePostfix(string postfix)
    {
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < postfix.Length; i++)
        {
            char ch = postfix[i];

            if (char.IsDigit(ch))
                stack.Push(ch - '0');

            else
            {
                int val1 = stack.Pop();
                int val2 = stack.Pop();

                switch (ch)
                {
                    case '+':
                        stack.Push(val2 + val1);
                        break;

                    case '-':
                        stack.Push(val2 - val1);
                        break;

                    case '*':
                        stack.Push(val2 * val1);
                        break;

                    case '/':
                        stack.Push(val2 / val1);
                        break;
                }
            }
        }
        return stack.Pop();
    }
}
```
This program reads an infix expression from the console, converts it to postfix using the `InfixToPostfix` method, and then evaluates the postfix expression using the `EvaluatePostfix` method. The `Precedence` method is used to determine the precedence of the operators in the infix expression.