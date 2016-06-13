using UnityEngine;
using System.Collections;
/*
 * Ryan Kearns
 * 10/06/2016
 * Desc: Script for the building scene. This script allows the player to place and remove blocks
 */
public class BlockBuilder : MonoBehaviour {
    public bool isOn;
	public GameObject Ghost;
	public GameObject Block;
	public GameObject Core;
	public GameObject[] placeArray;
	private int index;
	public int removeIndex;
  //  public Renderer rend;
	//public GameObject positions

	// Use this for initialization
	void Start () {
		index = 0;
		placeArray = new GameObject[48];
//        rend.GetComponent<Renderer>();
       // rend.material.color = new Color(111, 111, 111, 0);
	}

	void FixedUpdate(){
		if (Input.GetButtonDown("Fire1") && Highlight.over == true) {
			//check if spot has block object
			//for loop finds if any block at highlight position retruns true if any are
			//makes blocks unstackable
			bool spaceTaken = false;
			for (int x = 0; x < placeArray.Length; x++) {
				if(placeArray[x] == null){
				}
				else if (Highlight.positions == placeArray[x].transform.position) {	//need a way to find empty slots and fill them with objects
					spaceTaken = true;
				}
			}
			if (spaceTaken == true || Highlight.positions == Core.transform.position) {

			} else {
				GameObject blockClone = (GameObject) Instantiate (Block, Highlight.positions, Quaternion.identity);

				//make blocks children of core
				blockClone.transform.SetParent( Core.transform);
				//adds block to object array
				for (int x = 0; x < placeArray.Length; x++) {
					if (placeArray [x] == null) {
						index = x;
					}
				}
				placeArray[index] = blockClone;
				index ++;

			}


		}
		//player removing blocks
		if (Input.GetButtonDown ("Fire2") && Highlight.over == true) {
			//checks if spot has a block to remove
			removeIndex = 49;
			for (int x = 0; x < 48; x++) {
				if (placeArray [x] == null) {
				}
				else if (Highlight.positions == placeArray [x].transform.position) {
					removeIndex = x;
				}
				//no item to remove
				if (removeIndex > 48) {

				} else if(removeIndex < 49) {

					string blockName = placeArray [removeIndex].name;
					placeArray [removeIndex] = null;
					GameObject blockClone = GameObject.Find (blockName);
					Destroy(blockClone,0.0f);
					//GameObject blockClone = placeArray[removeIndex].gameObject;
					//blockClone.
				}
			}

		}
	}
	// Update is called once per frame
		//when mouse over highlighted sprite
		//on mouse click
		//checks coords and places in variables
		//checks if object at coords
		//if not, instantiate
		
}
