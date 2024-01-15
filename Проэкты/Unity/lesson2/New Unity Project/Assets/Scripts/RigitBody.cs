using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigitBody : MonoBehaviour
{
    public List<GameObject> target;
    public GameObject capsule;
    private EnemyController enemyController;
    void Start()
    {
        enemyController = new EnemyController(new Enemy(capsule, target), 1);
    }

    void Update()
    {
        enemyController.Go();
    }
}





