using System.Collections.Generic;
using UnityEngine;

public class Enemy{
    private List<GameObject> path{get;set;}
    private GameObject obj{get;set;}
    private int currentPosition{get;set;}
    public Enemy(GameObject enemy, List<GameObject> listOfPlaces){
        obj = enemy;
        path = listOfPlaces;
        currentPosition = 0;
    }
    public void Next(){
        obj.transform.position = Vector3.MoveTowards(obj.transform.position, path[currentPosition].transform.position,0.05f);
        if(Vector3.Distance(obj.transform.position, path[currentPosition].transform.position)<0.1f){
            if(currentPosition!=path.Count-1){
                currentPosition++;
            }
        }
    }
    public void Prev(){
        obj.transform.position = Vector3.MoveTowards(obj.transform.position, path[currentPosition].transform.position,0.1f);
        if(Vector3.Distance(obj.transform.position, path[currentPosition].transform.position)<0.1f){
            if(currentPosition!=0){
                currentPosition--;
            }
        }
    }
    public int getPosition(){
        return currentPosition;
    }
    public GameObject getObj(){
        return obj;
    }
    public List<GameObject> getPath(){
        return path;
    }

}
