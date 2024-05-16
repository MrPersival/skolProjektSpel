using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsSpawner : MonoBehaviour
{
    public Transform player;
    public float distanceToPlayerOnSpawn = 100f;
    public Transform maxPoint; //Some obj will spawn between borders in random, so we need their X-coord
    public Transform minPoint;

    public GameObject pointObj;
    public GameObject augmentationObj; //Not yet implimented
    public GameObject trapPlatform;

    public GameController gc;

    void Start() //Start calling function that spawn obj every N seconds.
    {
        InvokeRepeating("spawnPointObj", 0f, .5f);
        InvokeRepeating("spawnTrapPlatform", 0f, 2f);

    }
    void SpawnObj(GameObject objToSpawn, bool randomPosition = false)
    {
        //Debug.LogWarning("Spawning " + objToSpawn.name);
        float x = 0f;
        if (randomPosition) { //If obj needs to be spawned in random postiton, will take random X between two borders
            x = Random.Range(minPoint.position.x, maxPoint.position.x);
        }
        else { //If not, will just spawn obj in middle.
            x = (maxPoint.position.x + minPoint.position.x) / 2;
        }
        GameObject newObj = Instantiate(objToSpawn, new Vector3 (x, player.position.y, player.position.z + distanceToPlayerOnSpawn), Quaternion.identity);
        newObj.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, gc.speed);
    }

    void spawnPointObj() {
        SpawnObj(pointObj, true);
    }

    
    void spawnAugmentationObj() {
        SpawnObj(augmentationObj);
    }

    void spawnTrapPlatform() {
        SpawnObj(trapPlatform);
    }

}
