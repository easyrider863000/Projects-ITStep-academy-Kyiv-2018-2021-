package com.itstep;

import java.lang.reflect.Array;
import java.util.Arrays;
import java.util.Collections;
import java.util.Scanner;

public class DZ {

    public static void main(String[] args) {

        /*String text = "My lover's got humor\n" +
                "She's the giggle at a funeral\n" +
                "Knows everybody's disapproval\n" +
                "I should've worshiped her sooner\n" +
                "If the Heavens ever did speak\n" +
                "She's the last true mouthpiece\n" +
                "Every Sunday's getting more bleak\n" +
                "A fresh poison each week\n" +
                "\"We were born sick\", you heard them say it\n" +
                "My church offers no absolutes\n" +
                "She tells me, \"Worship in the bedroom\"\n" +
                "The only Heaven I'll be sent to\n" +
                "Is when I'm alone with you\n" +
                "I was born sick, but I love it\n" +
                "Command me to be well\n" +
                "A-, Amen, Amen, Amen";
        int count=0;
        int last_pos = 0;
        String chars = "qwertyuiopasdfghjklzxcvbnm";
        for(int j = 0;j<chars.length();j++) {
            count = 0;
            last_pos = 0;
            for (int i = 0; i < text.length(); i++) {
                if (text.indexOf(chars.charAt(j), last_pos) >= 0) {
                    count += 1;
                    last_pos = text.indexOf(chars.charAt(j), last_pos) + 1;
                }
            }
            System.out.println(chars.charAt(j)+" = "+count*100/text.length()+"%");
        }*/



        /*int[] arr = new int[10];
        for (int i = 0; i < 10; i++) {
            arr[i]= Fib(i);
        }
        System.out.println(Arrays.toString(arr));*/

        int [][]arr = {{1,2,1},
                {0,1,2}};
        int [][]arr2 = {{1,0},
                {0,1},
                {1,1}};
        printArr2(arr);
        printArr2(arr2);
    }
    public static boolean isArr(int arr[][]){
        for(int i =0;i< arr.length;i++){
            for(int j =0;j< arr.length;j++){
                if(arr[i].length>arr[j].length){
                    return false;
                }
            }
        }
        return true;
    }
    public static void printArr2(int arr[][]){
        if(!isArr(arr)){return;}
        for(int i = 0;i<arr.length;i++){
            for(int j = 0;j<arr[i].length;j++){
                System.out.print(arr[i][j]+" ");
            }
            System.out.println();
        }
    }
    public static int[][] getNewArr(int arr[][], int arr2[][]){
        if(!isArr(arr)){return null;}
        int arr3[];
        int [][]arr4 = new int[arr.length][arr2[0].length]
        for(int i=0;i<arr.length;i++){
            arr3=getColumn(arr2)
        }
    }


    public static int Fib(int n){
        if(n==0){
           return 0;
        }
        if(n==1){
            return 1;
        }
        else{
            return Fib(n-2)+Fib(n-1);
        }
    }
}

