using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;
using System;

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

    private void OnTriggerEnter(Collider col)
    {
        Debug.LogWarning("Collided with: " + col.gameObject.name + " with tag " + col.tag);
        if(col.tag == "AddPointsTrigger") {
            string addPointsText = col.GetComponentInChildren<TextMeshProUGUI>().text;
            Debug.LogWarning("Substring 1: " + addPointsText.Substring(addPointsText.Length - 1));
            Debug.LogWarning("Substring 2: " + addPointsText.Substring(0, addPointsText.Length - 2));

            if(addPointsText.Substring(addPointsText.Length - 1) == "%")
            {
                gc.points += gc.points * (Convert.ToInt16(addPointsText.Substring(0, addPointsText.Length - 2)) / 100);
            }
            else gc.points += Convert.ToInt16(addPointsText);
        }
    }
}
