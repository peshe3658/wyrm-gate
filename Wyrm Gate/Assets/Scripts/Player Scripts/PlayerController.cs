using UnityEngine;
using System.Collections;

/*
 * Ryan Kearns
 * 01/06/2016
 * desc: script that allows the player to move with the keyboard.
 */
public class PlayerController : MonoBehaviour {
	public float boost;
	public float speed;
	public float fuel = 100f;
	private Rigidbody2D rb;
	//public float RotationSpeed = 5;

	void Start () {
		//initialize rigidbody
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void UnBrake(){
		rb.drag = 0;
	}
	void Update(){

		//transform.Rotate((Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime), 0, 0, Space.World);
		//transform.Rotate((Input.GetAxis("Mouse Z") * RotationSpeed * Time.deltaTime),(Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime), 0, Space.World);
	
		//the brakes
		if(Input.GetKey(KeyCode.LeftShift)){
			if (rb.drag < 100) {
				rb.drag += 0.1f;
			}
		}
		if (Input.GetKeyUp (KeyCode.LeftShift)) {
			UnBrake ();	
		}

     //   GameController instanceOfB = GameObject.Find("GameController").GetComponent<GameController>();
       // instanceOfB.collisonCheck(GetComponent<Collider2D>());
    }
	void FixedUpdate () {
		
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);


		//if the player holds the boost key and has enough boost fuel
		if(Input.GetKey("space")==true && fuel >0.0f){	
			//player moves at faster spped than not boosting
			rb.AddForce (movement * boost);
			//fuel will rapidly decrease
			fuel = fuel - 1.1666f;
			//will play boost sound
		}
		else{
			//will not play boost sound
			rb.AddForce (movement * speed);
			//if the player has less than full boost fuel
			if (fuel < 100f) {
				fuel = fuel + 0.5666f;
			}//stops the player getting more than max fuel
			if (fuel > 100f) {
				fuel = 100f;
			}
		}
}
			}