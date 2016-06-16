using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    GameObject player;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
        var core = GameObject.FindGameObjectWithTag("Player");
        player = core;
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
