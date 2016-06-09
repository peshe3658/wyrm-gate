﻿using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {

    public GameObject bullets;
    public int bulletLimit;
    private int currentAmount;
    private int[] bulletArray;
    private GameObject[] bulletList;
    private Rigidbody2D rb;
    
    // Use this for initialization
	void Start ()
    {
        var player = GameObject.FindWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();
        bulletArray = new int[bulletLimit];
        currentAmount = 0;
    }

    void spawn()
    {
        Vector3 test = rb.position;
        Quaternion bulletRotation = Quaternion.Euler(test);
        bulletList = new GameObject[bulletLimit];
        if (currentAmount < bulletLimit)
        {
            Destroy(bulletList[currentAmount]);
            Vector3 spawnPosition = new Vector3(rb.position.x, rb.position.y, 0);
            bulletList[currentAmount] = (GameObject)Instantiate(bullets, spawnPosition, bulletRotation);
            bulletList[currentAmount].GetComponent<Rigidbody2D>().velocity = 10*(rb.velocity);
            currentAmount++;
            print(currentAmount);
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
	}
}
