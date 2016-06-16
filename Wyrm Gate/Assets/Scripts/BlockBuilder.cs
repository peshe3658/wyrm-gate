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
	public GameObject Cannon;
	public GameObject[] bPlaceArray;
	public GameObject[] cPlaceArray;
	private int index;
	public int removeIndex;
	public bool cSpaceTaken;
	public bool bSpaceTaken;
	void Start () {
		index = 0;
		bPlaceArray = new GameObject[48];
		cPlaceArray = new GameObject[48];
	}
	void FixedUpdate ()
	{
		if (CannonPick.isOn == true) {
			if (Input.GetButtonDown ("Fire1") && Highlight.over == true) {
				//check if spot has block object
				//for loop finds if any block at highlight position retruns true if any are
				//makes cannons unstackable
				cSpaceTaken = false;
				for (int x = 0; x < 48; x++) {
					if (cPlaceArray [x] == null) {
					} else if (Highlight.positions == cPlaceArray [x].transform.position) {
						cSpaceTaken = true;
					}
				}
				bSpaceTaken = false;
				Vector3 tempPosition = new Vector3 (Highlight.positions.x, (Highlight.positions.y - 0.14f), Highlight.positions.z);
				for (int x = 0; x < 48; x++) {
					
					if (bPlaceArray [x] == null) {
					} else if (tempPosition == bPlaceArray [x].transform.position) {
						bSpaceTaken = true;
					}
				}
				if (cSpaceTaken == true || bSpaceTaken == false) {
				} else {
					GameObject cannonClone = (GameObject)Instantiate (Cannon, Highlight.positions, Quaternion.identity);

					//make cannon children of core
					cannonClone.transform.SetParent (Core.transform);
					//adds cannon to object array
					//loop makes builder instantiate cannon at end of array, makes array fill removed slots
					for (int x = 0; x < cPlaceArray.Length; x++) {
						if (cPlaceArray [x] == null) {
							index = x;
						}
					}
					//adding clone to array
					cPlaceArray [index] = cannonClone;
				}
			}
		}
		if (BlockPick.isOn == true) {
			if (Input.GetButtonDown ("Fire1") && Highlight.over == true) {
				//check if spot has block object
				//for loop finds if any block at highlight position retruns true if any are
				//makes blocks unstackable
				bool spaceTaken = false;
				for (int x = 0; x < bPlaceArray.Length; x++) {
					if (bPlaceArray [x] == null) {
					} else if (Highlight.positions == bPlaceArray [x].transform.position) {
						spaceTaken = true;
					}
				}
				if (spaceTaken == true || Highlight.positions == Core.transform.position) {

				} else {
					GameObject blockClone = (GameObject)Instantiate (Block, Highlight.positions, Quaternion.identity);
					//make blocks children of core
					blockClone.transform.SetParent (Core.transform);
					//adds block to object array
					//loop makes builder instantiate block at end of array, makes array fill removed slots
					for (int x = 0; x < bPlaceArray.Length; x++) {
						if (bPlaceArray [x] == null) {
							index = x;
						}
					}
					//adding clone to array
					bPlaceArray [index] = blockClone;
				}
			}
		}
		//player removing blocks
		if (CannonPick.isOn == true) {
			if (Input.GetButtonDown ("Fire2") && Highlight.over == true) {
				//checks if spot has a block to remove
				removeIndex = 49;
				for (int x = 0; x < 48; x++) {
					//catch if slot is empty
					if (cPlaceArray [x] == null) {
					} else if (Highlight.positions == cPlaceArray [x].transform.position) {
						//found where block on cursor is
						removeIndex = x;
					}
					//no item to remove
					if (removeIndex > 48) {

					} else if (removeIndex < 49) {
						//gives block on cursor a tag
						cPlaceArray [removeIndex].gameObject.tag = "remove";
						//removes block from array
						cPlaceArray [removeIndex] = null;
						//finds the object with the tag
						GameObject cannonClone = GameObject.FindGameObjectWithTag ("remove");
						//removes object
						Destroy (cannonClone, 0.0f);
					}
				}
			}
		}
		if (BlockPick.isOn == true) {
			if (Input.GetButtonDown ("Fire2") && Highlight.over == true) {
				//checks if spot has a block to remove
				removeIndex = 49;
				for (int x = 0; x < 48; x++) {
					//catch if slot is empty
					if (bPlaceArray [x] == null) {
					} else if (Highlight.positions == bPlaceArray [x].transform.position) {
						//found where block on cursor is
						removeIndex = x;
					}
					//no item to remove
					if (removeIndex > 48) {

					} else if (removeIndex < 49) {
						//gives block on cursor a tag
						bPlaceArray [removeIndex].gameObject.tag = "remove";

						//finds the object with the tag
						GameObject blockClone = GameObject.FindGameObjectWithTag ("remove");
						bPlaceArray [removeIndex].gameObject.tag = "Untagged";
						bPlaceArray [removeIndex] = null;
						Destroy (blockClone, 0.0f);
						//checks if spot has a block to remove
						/*
						removeIndex = 49;
						Vector3 tempHighlight = new Vector3 (Highlight.positions.x, (Highlight.positions.y - 0.14f), Highlight.positions.z);
						for (int y = 0; y < 48; y++) {
							//catch if slot is empty

							if (cPlaceArray [y] == null) {
							} else if (Highlight.positions == cPlaceArray[y].transform.position){
									//found where block on cursor is
								removeIndex = y;
								}

							}
							//no item to remove
							if (removeIndex > 48) {

							} else if (removeIndex < 49) {
								//gives block on cursor a tag
								cPlaceArray [removeIndex].gameObject.tag = "remove";

								//finds the object with the tag
								GameObject cannonClone = GameObject.FindGameObjectWithTag ("remove");
								cPlaceArray [removeIndex].gameObject.tag = "Untagged";
								print ("loc of block = " + blockClone.transform.position);
								print ("loc of cannon = " + cannonClone.transform.position);
								//removes object
								Destroy (cannonClone, 0.0f);
								//removes block from array
								cPlaceArray [removeIndex] = null;
								//removes object
								Destroy (blockClone, 0.0f);
						



							}*/
						}
					}
				}		
			}
		}
    public GameObject[] getBPlaceArray()
    {
        return bPlaceArray;
    }
    public GameObject[] getCPlaceArray()
    {
        return cPlaceArray;
    }
}

		