package com.company;

public class Main {



    public static void main(String[] args) {
        MyThread1 myThread1 = new MyThread1();
        myThread1.start();
        while (true){
            System.out.print("B");
        }
    }
}
