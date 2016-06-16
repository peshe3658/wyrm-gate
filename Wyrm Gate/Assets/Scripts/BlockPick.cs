using UnityEngine;
using System.Collections;

public class BlockPick : MonoBehaviour {
	public static bool isOn;

	void OnMouseOver(){
		isOn = true;
		CannonPick.isOn = false;
	}
}
