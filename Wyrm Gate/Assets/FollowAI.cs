using UnityEngine;
using System.Collections;

public class FollowAI : MonoBehaviour {

     private Rigidbody2D rb;
    public float speed;
    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        float x;
        float y;
        var player = GameObject.FindWithTag("Player");
        x = player.GetComponent<Rigidbody2D>().position.y;
        y = player.GetComponent<Rigidbody2D>().position.x;
        Vector2 movement = new Vector2(x, y);
        rb.AddForce(movement * speed);
    }
}
