using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;
using TMPro;
using System;
using Random = System.Random;
using UnityEngine.UIElements;
using UnityEditor;

public class GameController : MonoBehaviour
{
    public float points = 1f;
    public int objectsToSpawnOnStart = 4;
    public float speed = -1.0f;
    public GameObject emptyPlatform;
    //public GameObject autgumentPlatform;

    public GameObject trapPlatform;
    public GameObject startPlatform;
    public GameObject basePlane;
    public BoxCollider deleteColider;
    private List<GameObject> platforms = new List<GameObject>();
    public Transform player;
    //public float rotatationCoefficient = 1f;

    public float chanseToSpawnPlatform = 25f;

    public float chanseToSpawnTrap = 50f;

    public float pointsSpeedCoef = 0.0001f;

    public float pointsForSecond = 1f;

    public TextMeshProUGUI pointsUi;

    private float pointsTimer = 0f;

    public Transform gameOverScreen;
    public TextMeshProUGUI endPointsUi;

    Random rnd = new Random();


    // Start is called before the first frame update
    void Start() 
    {
        Time.timeScale = 1f;
        platforms.Add(startPlatform);
        startPlatform.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed);
        basePlane.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed);
        for(int i = 1; i <= objectsToSpawnOnStart; i++)
        {
            SpawnNewPlatform();
        }
        //player.Rotate(new Vector3(speed * rotatationCoefficient, 0, 0));

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        pointsTimer = Time.deltaTime + pointsTimer;
        //Debug.LogWarning(pointsTimer);
        if (pointsTimer >= 1f)
        {
            //points = points + pointsForSecond; // + Math.Abs(pointsForSecond * speed)
            speed = speed - (points * pointsSpeedCoef);
            pointsUi.text = Convert.ToString(Math.Round(points));
            pointsTimer = 0f;
            
        }


    }

    void SpawnNewPlatform()
    {
        GameObject platform = new GameObject();
        GameObject lastPlatform = platforms.Last();
        float rndChanse = rnd.Next(0, 1000) / 10;
        Vector3 lastPlatformFrontPoint = lastPlatform.transform.Find("FrontPoint").transform.position;
        /*if(rndChanse < chanseToSpawnPlatform && lastPlatform.name != autgumentPlatform.name + "(Clone)") { //Find other way maybe
            platform = Instantiate(autgumentPlatform,
            lastPlatformFrontPoint + new Vector3(0, 0, autgumentPlatform.GetComponent<MeshFilter>().sharedMesh.bounds.size.x / 2),
            Quaternion.identity);
            //platform.transform.Rotate(0, 180, 0);
        }*/
        if(rndChanse < chanseToSpawnTrap && lastPlatform.name != trapPlatform.name + "(Clone)" && platforms.Count >= 5)
        {
            platform = Instantiate(trapPlatform,
            lastPlatformFrontPoint + new Vector3(0, 0, trapPlatform.GetComponent<MeshFilter>().sharedMesh.bounds.size.x / 2),
            Quaternion.identity);
        }
        else
        {
            platform = Instantiate(emptyPlatform,
            lastPlatformFrontPoint + new Vector3(0, 0, emptyPlatform.GetComponent<MeshFilter>().sharedMesh.bounds.size.x / 2),
            Quaternion.identity);
        }

        platform.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed);
        platforms.Add(platform);
    }

    public void deletePaltform(GameObject platform)
    {
        //Debug.LogWarning("Deleting and spawning new platform");
        platforms.Remove(platform);
        Destroy(platform);
        SpawnNewPlatform();
    }

    public void endGame() {
        //Debug.LogWarning("GG WP");
        Time.timeScale = 0f;
        gameOverScreen.gameObject.SetActive(true);
        endPointsUi.text = Convert.ToString(Math.Round(points));
    }


}

