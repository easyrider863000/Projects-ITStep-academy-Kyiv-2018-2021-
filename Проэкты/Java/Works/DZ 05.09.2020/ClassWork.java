package com.itstep;

import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;

public class ClassWork {
    public static void main(String[] args) {
        try (FileWriter writer = new FileWriter("./src/com/itstep/hello2.txt", true)) {
            writer.append("0 ");
            writer.flush();
        } catch (IOException ex) {

            System.out.println(ex.getMessage());
        }
        File f = new File("./src/com/itstep/hello.txt");
        long len = f.length();
        try(FileReader reader = new FileReader("./src/com/itstep/hello.txt"))
        {
            int c;
            int num = 0;
            int i = 0;
            StringBuilder str = new StringBuilder();
            while((c=reader.read())!=-1) {
                i++;
                if(i>=0) {
                    if (c >= 48 && c <= 57) {
                        str.append((char)c);
                    } if(c == 32 || i==len-1) {
                        try (FileWriter writer = new FileWriter("./src/com/itstep/hello2.txt", true)) {
                            if (num + 1 == Integer.parseInt(str.toString())) {
                                writer.append(str.toString());
                                num = Integer.parseInt(str.toString());
                            }
                            else{
                                writer.append(String.valueOf(num+1));
                                num = Integer.parseInt(String.valueOf(num+1));
                            }
                            writer.append(" ");
                            writer.flush();
                            str = new StringBuilder();
                        } catch (IOException ex) {

                            System.out.println(ex.getMessage());
                        }
                    }
                }
            }
        }
        catch(IOException ex){

            System.out.println(ex.getMessage());
        }
    }
}
