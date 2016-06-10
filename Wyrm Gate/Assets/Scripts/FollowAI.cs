using UnityEngine;
using System.Collections;

public class FollowAI : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed;
    private float Range;
    bool activated;
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
        if (Vector2.Distance(player.GetComponent<Rigidbody2D>().position, GetComponent<Rigidbody2D>().position) < 10.0f)
        {
            activated = true;
        }
        if (activated == true)
        {
            x = player.GetComponent<Rigidbody2D>().position.x;
            y = player.GetComponent<Rigidbody2D>().position.y;
            Vector2 movement = new Vector2(x, y);
            x = GetComponent<Rigidbody2D>().position.x;
            y = GetComponent<Rigidbody2D>().position.y;
            Vector2 current = new Vector2(x, y);
            Range = Vector2.Distance(current, movement);
            transform.Translate(Vector2.MoveTowards(current, movement, Range) * speed * Time.deltaTime);
            
        }

    }

}
