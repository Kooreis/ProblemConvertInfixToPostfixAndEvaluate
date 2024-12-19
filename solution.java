Here is a Java console application that converts an infix expression to postfix and evaluates it:

```java
import java.util.Stack;

public class Main {
    public static void main(String[] args) {
        String expression = "2+3*4";
        String postfix = infixToPostfix(expression);
        System.out.println("Postfix Expression: " + postfix);
        System.out.println("Evaluation: " + evaluatePostfix(postfix));
    }

    private static int precedence(char ch) {
        switch (ch) {
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

    private static String infixToPostfix(String expression) {
        String result = "";
        Stack<Character> stack = new Stack<>();
        for (int i = 0; i < expression.length(); ++i) {
            char c = expression.charAt(i);
            if (Character.isLetterOrDigit(c)) {
                result += c;
            } else {
                while (!stack.isEmpty() && precedence(c) <= precedence(stack.peek())) {
                    result += stack.pop();
                }
                stack.push(c);
            }
        }
        while (!stack.isEmpty()) {
            result += stack.pop();
        }
        return result;
    }

    private static int evaluatePostfix(String expression) {
        Stack<Integer> stack = new Stack<>();
        for (int i = 0; i < expression.length(); i++) {
            char c = expression.charAt(i);
            if (Character.isDigit(c)) {
                stack.push(c - '0');
            } else {
                int val1 = stack.pop();
                int val2 = stack.pop();
                switch (c) {
                    case '+':
                        stack.push(val2 + val1);
                        break;
                    case '-':
                        stack.push(val2 - val1);
                        break;
                    case '/':
                        stack.push(val2 / val1);
                        break;
                    case '*':
                        stack.push(val2 * val1);
                        break;
                }
            }
        }
        return stack.pop();
    }
}
```

This program takes an infix expression as input, converts it to postfix using the `infixToPostfix` method, and then evaluates the postfix expression using the `evaluatePostfix` method. The `precedence` method is used to determine the precedence of the operators in the expression.