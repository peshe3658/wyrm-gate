using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerCollider : MonoBehaviour {

    public float health = 100;
    Text healthF;

    void onTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            other.GetComponent<bulletScriptE>().destroy();
            Destroy(other);
            health = health - 10;
            print("test4");
        }
        else if (other.gameObject.tag == "bullet")
        {
            Destroy(other);
            health = health - 5;
        }
    }
    void onCollisionEnter(Collider2D other)
    {
        print("test");
    }

    void onTriggerExit(Collider2D other)
    {
        print("test2");
    }

    void onTriggerStay(Collider2D other)
    {
        print("test3");
    }


    // Use this for initialization
    void Start ()
    {
        
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        var core = GameObject.FindGameObjectWithTag("text");
        core.GetComponent<Text>().text = health.ToString();
    }
}
