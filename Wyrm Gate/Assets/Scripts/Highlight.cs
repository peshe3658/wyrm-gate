using UnityEngine;
using System.Collections;

public class Highlight : MonoBehaviour {
	private Texture2D square;
	public GameObject Ghost;
	public int positionx;
	public int positiony;
	private Vector3 mousePosition;
	public static bool over;
	public static Vector3 positions;
	// Use this for initialization
	void Start () {
		//Sprite.Instantiate(Ghost);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseOver(){
		mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);
		positionx = (int) mousePosition.x;
		positiony = (int) mousePosition.y;
		positions = new Vector3 (positionx,positiony,0);
		Ghost.transform.position = positions;
		over = true;
		//draws and destroys when mouse position over area
		//converts mouse floats to integers

		//when user over area, blocks drawn in placeable areas

		//int currentGhost = Ghost.GetHashCode();
		//if area placeable sends true to blockBuilder

	}
	void OnMouseExit(){
		//Ghost.
		over = false;
	}
	void FixedUpdate(){

	
	//area is null colour

	

	}
}
