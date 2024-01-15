package com.itstep;

import java.time.LocalDateTime;

public class Client  implements Comparable<Client> {
    private int priorityId;
    private String request;

    public Client(int priorityId, String request) {
        this.priorityId = priorityId;
        this.request = request;
    }

    @Override
    public int compareTo(Client o) {
        return o.priorityId > this.priorityId ? 1 : -1;
    }

    @Override
    public String toString() {
        return "time: "+ LocalDateTime.now().getHour()+":"+LocalDateTime.now().getMinute()+":"+LocalDateTime.now().getSecond()+ " priorityId:" + this.priorityId + ", request:" + request;
    }
}
