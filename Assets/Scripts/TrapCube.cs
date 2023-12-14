using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrapCube : MonoBehaviour
{
    public GameController controller;

    void Start()
    {
        controller = Object.FindAnyObjectByType<GameController>();
    }

    private void OnTriggerEnter(Collider col) {
        Debug.LogWarning("Collided with: " + col.gameObject.name + " with tag " + col.tag);
        if(col.tag == "Player") {
            controller.endGame();
        }
    }

}
