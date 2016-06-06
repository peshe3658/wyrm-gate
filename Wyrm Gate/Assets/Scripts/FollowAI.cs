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
        x = player.GetComponent<Rigidbody2D>().position.x;
        y = player.GetComponent<Rigidbody2D>().position.y;
        Vector2 movement = new Vector2(x, y);
        x = GetComponent<Rigidbody2D>().position.x;
        y = GetComponent<Rigidbody2D>().position.y;
        Vector2 current = new Vector2(x, y);
        rb.AddForce(-1 * (Vector2.MoveTowards(current, movement, 2.0f) * speed));
        if (rb.velocity.magnitude > 50 && rb.drag < 100)
        {
            rb.drag += 1.0f;
        }

        if (rb.velocity.magnitude < 50 && rb.drag > 0)
        {
            rb.drag -= 1.0f;
        }

    }

}
