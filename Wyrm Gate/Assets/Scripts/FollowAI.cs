using UnityEngine;
using System.Collections;

public class FollowAI : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed;
    private bool activated;
    private bool bullets;
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
        if (Vector2.Distance(player.GetComponent<Rigidbody2D>().position, GetComponent<Rigidbody2D>().position) < 20.0f)
        {
            activated = true;
            bullets = true;
        }
        else
        {
            bullets = false;
        }
        if (activated == true)
        {
            x = player.GetComponent<Rigidbody2D>().position.x;
            y = player.GetComponent<Rigidbody2D>().position.y;
            Vector2 movement = new Vector2(x, y);
            Vector2 Range = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), movement, speed * Time.deltaTime);
            Vector3 position = new Vector3(Range.x, Range.y, -9f);
            transform.position = position;

        }

    }

    public bool getActivated()
    {
        return bullets;
    }

}
