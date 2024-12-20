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