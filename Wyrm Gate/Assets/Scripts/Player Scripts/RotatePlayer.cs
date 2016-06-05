using UnityEngine;
using System.Collections;
/*
 * Ryan Kearns
 * 03/06/2016
 * Desc: rotates the player to follow the mouse movements
 */
public class RotatePlayer : MonoBehaviour {

	void Update(){
		// takes all the positions of the mouse
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		//moves the player to "look at" the mouse position
		transform.rotation = Quaternion.LookRotation (Vector3.forward, mousePos - transform.position);
	}

		
	}


