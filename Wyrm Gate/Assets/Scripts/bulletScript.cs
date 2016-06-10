﻿using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {

    public GameObject bullets;
    public int bulletLimit;
    private int currentAmount;
    private int[] bulletArray;
    private GameObject[] bulletList;
    private Rigidbody2D rb;
    private bool check = false;
    
    // Use this for initialization
	void Start ()
    {
        var player = GameObject.FindWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();
        bulletArray = new int[bulletLimit];
        bulletList = new GameObject[bulletLimit];
        currentAmount = 0;
    }

    void spawn()
    {
        print(bulletArray[1]);
        Quaternion bulletRotation = Quaternion.identity;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (currentAmount < bulletLimit)
        {
            Destroy(bulletList[currentAmount]);
            Vector3 spawnPosition = new Vector3(rb.position.x, rb.position.y, -9);
            bulletList[currentAmount] = (GameObject)Instantiate(bullets, spawnPosition, bulletRotation);
            bulletList[currentAmount].GetComponent<Rigidbody2D>().AddForce((mousePos - spawnPosition) * 1000);
            bulletArray[currentAmount] = 1;
            print(bulletArray[currentAmount]);
            print(currentAmount);
            currentAmount++;
        }
        else
        {
            currentAmount = 0;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if(Input.GetMouseButtonDown(0))
        {
            spawn();
        }
        GameController instanceOfB = GameObject.Find("GameController").GetComponent<GameController>();
        for (int i = 0; i < bulletLimit; i++)
        {
            if (bulletArray[i] == 0)
            {

            }
            else
            {
                print(bulletList);
                check = instanceOfB.collisonCheck(bulletList[i].GetComponent<Collider2D>());
                if (check == true)
                {
                    bulletArray[i] = 0;
                }
            }
        }
        
    }

}