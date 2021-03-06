﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject enemy;
    private GameObject[] enemies;
    private int currentAmount;
    private int[] enemyArray;
    public Vector3 positionRange;
    public int enemyAmount;
    private BoxCollider2D rb;
    private bool skip = false;


    // Use this for initialization
    void Start ()
    {
        spawn();
        var player = GameObject.FindWithTag("Player");
        rb = player.GetComponent<BoxCollider2D>();
    }

    void spawn()
    {
        currentAmount = enemyAmount;
        enemyArray = new int[enemyAmount];
        Quaternion enemyRotation = Quaternion.identity;
        enemies = new GameObject[enemyAmount];
        for (int i = 0; i < enemyAmount; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-positionRange.x, positionRange.x), Random.Range(-positionRange.y, positionRange.y), -9);
            enemies[i] = (GameObject)Instantiate(enemy, spawnPosition, enemyRotation);
        }
    }

    

    public bool collisonCheck(Collider2D rb)
    {
        bool check = false;
        
        for (int i = 0; i < enemyAmount; i++)
        {

            if(enemyArray[i] == 1)
            {
                skip = true;
            }
            
            else if (enemies[i].GetComponent<Collider2D>().IsTouching(rb))
            {
                enemies[i].GetComponent<BulletScriptE>().destroy();
                Destroy(enemies[i]);
                currentAmount--;
                enemyArray[i] = 1;
                check = true;
            }
        }
        if (currentAmount == 0)
        {
            spawn();
        }
        return check;
    }
}
