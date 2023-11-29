using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

public class GameController : MonoBehaviour
{
    public int objectsToSpawnOnStart = 4;
    public float speed = 1.0f;
    public GameObject emptyPlatform;
    public GameObject autgumentPlatform;
    public GameObject startPlatform;
    public BoxCollider deleteColider;
    private List<GameObject> platforms = new List<GameObject>();
    public Transform player;
    public float rotatationCoefficient = 1f;

    // Start is called before the first frame update
    void Start()
    {
        platforms.Add(startPlatform);
        startPlatform.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed);
        for(int i = 1; i <= objectsToSpawnOnStart; i++)
        {
            SpawnNewPlatform();
        }
        player.Rotate(new Vector3(speed * rotatationCoefficient * -1f, 0, 0));
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void SpawnNewPlatform()
    {
        GameObject platform = new GameObject();
        GameObject lastPlatform = platforms.Last();
        platform = Instantiate(emptyPlatform,
            lastPlatform.transform.position + new Vector3(0, 0, lastPlatform.GetComponent<Renderer>().bounds.size.z - 0.0001f) * -1,
            Quaternion.identity);
        platform.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed);
        platforms.Add(platform);
    }

    public void deletePaltform(GameObject platform)
    {
        platforms.Remove(platform);
        Destroy(platform);
        SpawnNewPlatform();
    }
}
