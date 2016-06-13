using UnityEngine;
using System.Collections;

public class holder : MonoBehaviour {
	
	public static ArrayList[] blocksx = new ArrayList[6];
	public static ArrayList[] blocksy = new ArrayList[6]; 

	void Start(){
		for (int x = 0; x < 6; x++) {
			holder.blocksx.SetValue ((x-3), x);
		}
		holder.blocksy.SetValue (3, 0);
		holder.blocksy.SetValue (2, 1);
		holder.blocksy.SetValue (1, 2);
		holder.blocksy.SetValue (0, 3);
		holder.blocksy.SetValue (-1, 4);
		holder.blocksy.SetValue (-2, 5);
		holder.blocksy.SetValue (-3, 6);
	}
}