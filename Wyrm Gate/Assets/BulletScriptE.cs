using UnityEngine;
using System.Collections;

public class BulletScriptE : MonoBehaviour {

    public GameObject bullets;
    public int bulletLimit;
    private int currentAmount;
    private int[] bulletArray;
    private GameObject[] bulletList;
    private Rigidbody2D rb;
    private bool check = false;
    private float timer;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletArray = new int[bulletLimit];
        bulletList = new GameObject[bulletLimit];
        currentAmount = 0;
        timer = Time.time;
    }

    void spawn()
    {
        var player = GameObject.FindWithTag("Player");
        Vector3 mousePos = player.GetComponent<Rigidbody2D>().position;
        Quaternion bulletRotation = Quaternion.identity;
        if (currentAmount < bulletLimit)
        {
            Destroy(bulletList[currentAmount]);
            Vector3 spawnPosition = new Vector3(rb.position.x, rb.position.y, -9);
            bulletList[currentAmount] = (GameObject)Instantiate(bullets, spawnPosition, bulletRotation);
            bulletList[currentAmount].GetComponent<Rigidbody2D>().AddForce((mousePos - spawnPosition) * 100);
            bulletArray[currentAmount] = 1;
            currentAmount++;
        }
        else
        {
            currentAmount = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<FollowAI>().getActivated() == true && check == false)
        {
            InvokeRepeating("spawn", 1, 3f);
            check = true;
        }

        else if (GetComponent<FollowAI>().getActivated() == false)
        {
            CancelInvoke();
            check = false;
        }

        

        GameController instanceOfB = GameObject.Find("GameController").GetComponent<GameController>();
        for (int i = 0; i < bulletLimit; i++)
        {
            if (bulletArray[i] == 0)
            {

            }
            else
            {
                //check = instanceOfB.collisonCheck(bulletList[i].GetComponent<Collider2D>());
                //if (check == true)
                //{
                //    bulletArray[i] = 0;
                //    Destroy(bulletList[i]);
                //}
                if (Time.time - timer >= 1f)
                {
                    timer = Time.time;
                    Destroy(bulletList[i]);
                }
            }
        }

    }
}
