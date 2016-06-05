using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject enemy;
    public Vector3 positionRange;
    
    
    // Use this for initialization
	void Start ()
    {
        spawn();
	}

    void spawn()
    {
        Quaternion enemyRotation = Quaternion.identity;
        Vector3 spawnPosition = new Vector3(Random.Range(-positionRange.x, positionRange.x), positionRange.y, positionRange.z);
        Instantiate(enemy, spawnPosition, enemyRotation);
    }
}
