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
    public Transform player;

    public float pointsSpeedCoef = 0.00005f; //Coeficient to how points will influence speed.

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
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        pointsTimer = Time.deltaTime + pointsTimer;
        //Debug.LogWarning(pointsTimer);
        if (pointsTimer >= 1f)
        {
            points = points + pointsForSecond; // + Math.Abs(pointsForSecond * speed) to take speed in acount. Not in use becasue will add points to fast.
            speed = speed - (points * pointsSpeedCoef); //Uses minus because speed is allways negative
            pointsUi.text = Convert.ToString(Math.Round(points));
            pointsTimer = 0f;
            
        }


    }
    public void endGame() {
        //Debug.LogWarning("GG WP");
        Time.timeScale = 0f;
        gameOverScreen.gameObject.SetActive(true);
        endPointsUi.text = Convert.ToString(Math.Round(points));
    }


}

