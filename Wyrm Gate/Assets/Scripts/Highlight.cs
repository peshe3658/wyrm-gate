using UnityEngine;
using System.Collections;
/*
 * Ryan Kearns
 * 05/06/2016
 * Desc: Build Menu. This code moves the highlight ghostblock where the mouse is when it is over the build area
 */
public class Highlight : MonoBehaviour {
	public GameObject blockPick;
	public GameObject cannonPick;
	private Texture2D square;
	public GameObject Ghost;
	public GameObject cGhost;
	public int positionx;
	public int positiony;
	private Vector3 mousePosition;
	public static bool over;
	public static Vector3 positions;
	public float mousePosx;
	public float mousePosy;
	// Use this for initialization
	void Start () {
		//Sprite.Instantiate(Ghost);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseOver(){
		if(BlockPick.isOn == true){
			mousePosition = Input.mousePosition;
			//convertst the mouse on screen to positions in game
			mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);
			//turns the mouse float
			mousePosx = mousePosition.x;
			mousePosy = mousePosition.y;
			positionx = (int) Mathf.Round(mousePosition.x);
			positiony = (int) Mathf.Round(mousePosition.y);
			positions = new Vector3 (positionx,positiony,1);
			//moves the Highlight to the mouse
			Ghost.transform.position = positions;
			//has over check for build manager
			over = true;
		}
		if (CannonPick.isOn == true) {
			mousePosition = Input.mousePosition;
			//convertst the mouse on screen to positions in game
			mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);
			//turns the mouse float
			mousePosx = mousePosition.x;
			mousePosy = mousePosition.y;
			positionx = (int) Mathf.Round(mousePosition.x);
			positiony = (int) Mathf.Round(mousePosition.y);
			positions = new Vector3 (positionx,(positiony+0.14f),1);
			//moves the Highlight to the mouse
			cGhost.transform.position = positions;
			//has over check for build manager
			over = true;
		}
	}
	void OnMouseExit(){
		over = false;
		cGhost.transform.position = new Vector3 (100, 100, 0);
		Ghost.transform.position = new Vector3 (100, 100, 0);
	}
	void FixedUpdate(){

	
	//area is null colour

	

	}
}
