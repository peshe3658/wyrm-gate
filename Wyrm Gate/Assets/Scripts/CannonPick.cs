using UnityEngine;
using System.Collections;
/*
 * Ryan Kearns
 * 15/06/2016
 * Desc: If the user moves ovr the ghost above build area, the Cannon is chosen
 */
public class CannonPick : MonoBehaviour {
	public static bool isOn;

	void OnMouseOver(){
		isOn = true;
		BlockPick.isOn = false;
	}
}
