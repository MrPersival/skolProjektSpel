using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreenController : MonoBehaviour
{
    void Update()
    {
        if(Input.GetButtonDown("Jump") == true)
        {
            SceneManager.LoadScene(0);
        }
    }
}
