using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsSpawner : MonoBehaviour
{
    public Transform basePlane;
    public Transform player;
    public Transform maxPoint;
    public Transform minPoint;

    public GameObject pointObj;
    public GameObject augmentationObj;

    float timeTotalPoint = 0f;
    float timeTotalAugmentation = 0f;
    // Update is called once per frame
    void Update()
    {
        timeTotalPoint += Time.deltaTime;
        if (timeTotalPoint >= 1)
        {
            timeTotalPoint = 0f;
            SpawnObj(pointObj);
        }

        timeTotalAugmentation += Time.deltaTime;
        if (timeTotalAugmentation >= 60)
        {
            timeTotalAugmentation = 0f;
            SpawnObj(augmentationObj);
        }
        
    }

    void SpawnObj(GameObject objToSpawn)
    {
        Debug.LogWarning("Spawning " + objToSpawn.name);
        float x = Random.Range(minPoint.position.x, maxPoint.position.x);
        GameObject newPointObj = Instantiate(objToSpawn, new Vector3 (x, player.position.y, player.position.z + 40), Quaternion.identity);
        newPointObj.transform.SetParent(basePlane, true);
    }
}
