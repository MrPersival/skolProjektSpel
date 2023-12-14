using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemnt : MonoBehaviour
{
    public float speed;
    public CharacterController controller;

    public GameController gc;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal") * -1f, 0, 0);
        controller.Move(move * speed * Time.deltaTime);
    }

    /* private void OnTriggerEnter(Collider col)
    {
        Debug.LogWarning("Collided with: " + col.gameObject.name + " with tag " + col.tag);
        if(col.tag == "Trap") {
            gc.endGame();
        }
    } */
}
