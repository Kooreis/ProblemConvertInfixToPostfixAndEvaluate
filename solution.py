Here is a Python console application that converts an infix expression to postfix and evaluates it:

```python
class Conversion:
    def __init__(self, capacity):
        self.top = -1
        self.capacity = capacity
        self.array = []
        self.precedence = {'+':1, '-':1, '*':2, '/':2, '^':3}
        self.result = []
        self.operators = set(['+', '-', '*', '/', '(', ')', '^'])

    def isEmpty(self):
        return True if self.top == -1 else False

    def peek(self):
        return self.array[-1]

    def pop(self):
        if not self.isEmpty():
            self.top -= 1
            return self.array.pop()
        else:
            return "$"

    def push(self, op):
        self.top += 1
        self.array.append(op)

    def isOperand(self, ch):
        return ch.isalpha()

    def notGreater(self, i):
        try:
            a = self.precedence[i]
            b = self.precedence[self.peek()]
            return True if a <= b else False
        except KeyError:
            return False

    def infixToPostfix(self, exp):
        for i in exp:
            if self.isOperand(i):
                self.result.append(i)
            elif i  == '(':
                self.push(i)
            elif i == ')':
                while self.peek() != '(':
                    self.result.append(self.pop())
                self.pop()
            else:
                while (not self.isEmpty() and self.notGreater(i)):
                    self.result.append(self.pop())
                self.push(i)
        while not self.isEmpty():
            self.result.append(self.pop())
        return "".join(self.result)

    def evaluatePostfix(self, expression):
        stack = []
        for character in expression:
            if character not in self.operators:  
                stack.append(int(character))
            else:
                val1 = stack.pop()
                val2 = stack.pop()
                stack.append(str(eval(f"{val2}{character}{val1}")))
        return int(stack.pop())

expression = "a+b*(c^d-e)^(f+g*h)-i"
ob = Conversion(len(expression))
postfix = ob.infixToPostfix(expression)
print("Postfix expression is: ", postfix)
print("Evaluated expression is: ", ob.evaluatePostfix(postfix))
```

Please note that this code assumes that the infix expression is fully parenthesized where necessary. Also, the evaluation function only works with single digit operands.