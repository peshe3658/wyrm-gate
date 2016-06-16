using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	// Use this for initialization
	public void load ()
    {
        var core = GameObject.FindGameObjectWithTag("Player");
        GameObject player = core;
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<RotatePlayer>().enabled = true;
        DontDestroyOnLoad(player);
        GameObject[] bPlaceArray = GetComponent<BlockBuilder>().getBPlaceArray();
        GameObject[] cPlaceArray = GetComponent<BlockBuilder>().getCPlaceArray();
        for (int i = 0; i < bPlaceArray.Length; i++)
        {
            if (bPlaceArray[i] == null)
            {

            }
            else
            {
                bPlaceArray[i].GetComponent<PlayerController>().enabled = true;
            }
        }
        for (int i = 0; i < cPlaceArray.Length; i++)
        {
            if (cPlaceArray[i] == null)
            {

            }
            else
            {
                cPlaceArray[i].GetComponent<PlayerController>().enabled = true;
            }
        }
        SceneManager.LoadScene("Game");
        SceneManager.MoveGameObjectToScene(player, SceneManager.GetActiveScene());

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
