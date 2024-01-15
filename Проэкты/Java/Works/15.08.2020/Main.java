package com.itstep;

import java.util.Scanner;

public class Main {
    public static void main(String[] args){
        Scanner in = new Scanner(System.in);

        System.out.print("First operand --> ");
        double num1 = in.nextDouble();
        System.out.print("Second operand --> ");
        double num2 = in.nextDouble();
        System.out.print("Choose operation (*,/,-,+) --> ");
        char ch = in.next().charAt(0);
        double result = 0;
        switch (ch) {
            case '+':
                result = num1 + num2;
                break;
            case '-':
                result = num1 - num2;
                break;
            case '/':
                result = num1 / num2;
                break;
            case '*':
                result = num1 * num2;
                break;
        }
        System.out.println("Your result --> "+result);
    }
}
