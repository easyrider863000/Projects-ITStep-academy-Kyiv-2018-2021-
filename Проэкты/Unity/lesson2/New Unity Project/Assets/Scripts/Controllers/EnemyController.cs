using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController{
    private List<Enemy> listOfEnemy;
    private Enemy exampleOfEnemy;
    private long time; 
    private int interval;
    public EnemyController(Enemy enemy, int intervalSeconds){
        time = DateTimeOffset.Now.ToUnixTimeSeconds();
        interval = intervalSeconds;
        listOfEnemy = new List<Enemy>();
        listOfEnemy.Add(enemy);
        GameObject gameObject = GameObject.Instantiate(enemy.getObj());
        GameObject.Destroy(gameObject.GetComponent<RigitBody>());
        gameObject.SetActive(false);
        exampleOfEnemy = new Enemy(gameObject,enemy.getPath());
    }
    public void Go(){
        if(listOfEnemy.Count<=1 || time+interval<DateTimeOffset.Now.ToUnixTimeSeconds()){
            GameObject gameObject = GameObject.Instantiate(exampleOfEnemy.getObj());
            gameObject.SetActive(true);
            listOfEnemy.Add(new Enemy(gameObject,exampleOfEnemy.getPath()));
            time = DateTimeOffset.Now.ToUnixTimeSeconds();
        }
        for (int i = 0; i < listOfEnemy.Count; i++)
        {
            listOfEnemy[i].Next();
        }
    }

}