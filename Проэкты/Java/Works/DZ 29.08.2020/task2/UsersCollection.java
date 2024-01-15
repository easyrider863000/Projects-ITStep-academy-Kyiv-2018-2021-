package com.itstep;

import java.util.HashSet;
import java.util.Scanner;

public class UsersCollection {
    private HashSet<User> users;
    private Scanner scanner;

    public UsersCollection() {
        users = new HashSet<>();
        scanner = new Scanner(System.in);
    }

    public void run() {
        int i = 0;
        while (i != 7) {
            System.out.print("1.Add new user\n" +
                    "2.Delete user\n" +
                    "3.Check existing user\n" +
                    "4.Change login user\n" +
                    "5.Change password user\n" +
                    "6.Print all users\n" +
                    "7.Exit\n" +
                    "Choose something --> ");
            i = scanner.nextInt();
            System.out.println("\n\n\n\n\n\n\n\n\n\n\n\n");
            if (i != 7&& i!=6) {
                System.out.print("Enter login --> ");
                String login = scanner.next();
                System.out.print("Enter password --> ");
                String password = scanner.next();
                if (i == 1) {
                    System.out.println(addNewUser(new User(login, password)));
                }
                if (i == 2) {
                    System.out.println(deleteUser(new User(login, password)));
                }
                if (i == 3) {
                    System.out.println(checkUser(new User(login, password)));
                }
                if(i == 4) {
                    System.out.print("Enter new login --> ");
                    String login2 = scanner.next();
                    System.out.println(changeUser(new User(login,password),login2,false));
                }
                if(i==5){
                    System.out.print("Enter new password --> ");
                    String password2 = scanner.next();
                    System.out.println(changeUser(new User(login,password),password2,true));
                }
            }
            if(i==6){
                System.out.println(users.toString());
            }
        }
    }

    private String addNewUser(User user) {
        if (users.add(user)) {
            return ("User \"" + user.getLogin() + "\" was added successfully");
        } else {
            return ("User \"" + user.getLogin() + "\" was not added. Already exists!");
        }
    }

    private String checkUser(User user) {
        if (users.contains(user)) {
            return ("User \"" + user.getLogin() + "\" exists");
        } else {
            return ("User \"" + user.getLogin() + "\" does not exist");
        }
    }

    private String deleteUser(User user) {
        if (users.stream().anyMatch(u -> u.getLogin().equals(user.getLogin()) && u.getPassword().equals(user.getPassword()))) {
            users.remove(user);
            return ("User \"" + user.getLogin() + "\" was deleted");
        }
        return ("Password is not correct or user \"" + user.getLogin() + "\" does not exist");
    }

    private String changeUser(User user, String newStr, boolean index) {
        if (users.stream().anyMatch(u -> u.getLogin().equals(user.getLogin()) && u.getPassword().equals(user.getPassword()))) {
            users.remove(user);
            if (index) {
                users.add(new User(user.getLogin(), newStr));
            }
            else{
                users.add(new User(newStr, user.getPassword()));
            }
            return ("User's data is updated");
        }
        return ("User's data is not updated");
    }
}
