package com.itstep;

import java.util.PriorityQueue;
import java.util.Queue;

public class DZZ {

    public static void main(String[] args) throws InterruptedException {
        Client c1 = new Client(1, "request1");
        Client c2 = new Client(3,"request2");
        Client c3 = new Client(2, "request3");
        Client c4 = new Client(500, "request4");
        Client c5 = new Client(23, "request5");
        Client c6 = new Client(90, "request6");
        Client c7 = new Client(67, "request7");
        Client c8 = new Client(9, "request8");
        Client c9 = new Client(503, "request9");
        Client c10 = new Client(5, "request10");
        Client c11 = new Client(8, "request11");

        Queue<Client> clients = new PriorityQueue<>();
        clients.add(c1);
        clients.add(c2);
        clients.add(c3);
        clients.add(c4);
        clients.add(c5);
        clients.add(c6);
        clients.add(c7);
        clients.add(c8);
        clients.add(c9);
        clients.add(c10);
        clients.add(c11);
        while (!clients.isEmpty()) {
            Thread.sleep(700);
            System.out.println(clients.poll());
        }
    }
}