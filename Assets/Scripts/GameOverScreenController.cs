using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class GameOverScreenController : MonoBehaviour
{
    public TMP_Text recordPoints;
    public GameController gameController;

    void Start()
    {
        if(PlayerPrefs.GetInt("record points", 0) < gameController.points)
        {
            PlayerPrefs.SetInt("record points", Convert.ToInt16(gameController.points));
            PlayerPrefs.Save();
        }
        recordPoints.text = Convert.ToString(PlayerPrefs.GetInt("record points", 0));
    }
    void Update()
    {
        if(Input.GetButtonDown("Jump") == true)
        {
            SceneManager.LoadScene(0);
        }
    }
}
