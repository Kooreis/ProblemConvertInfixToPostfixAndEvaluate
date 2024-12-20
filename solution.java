import java.util.Stack;

public class Main {
    public static void main(String[] args) {
        String expression = "2+3*4";
        String postfix = infixToPostfix(expression);
        System.out.println("Postfix Expression: " + postfix);
        System.out.println("Evaluation: " + evaluatePostfix(postfix));
    }