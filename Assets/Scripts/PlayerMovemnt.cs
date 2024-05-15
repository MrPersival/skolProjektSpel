using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;
using System;

public class PlayerMovemnt : MonoBehaviour
{
    public float speed;
    public float rotationCoeficient = -20f;
    public CharacterController controller;
    public Transform playerModel;

    public GameController gc;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        controller.Move(move * speed * Time.deltaTime);
        //Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);
        playerModel.eulerAngles = new Vector3(playerModel.eulerAngles.x, playerModel.eulerAngles.y, move.x * rotationCoeficient);
        //Debug.LogWarning(move.x * rotationCoeficient - 90);
    }


}
