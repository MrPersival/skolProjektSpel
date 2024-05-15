using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PointsAddingObject : MonoBehaviour
{
    public GameObject destroyEffect;
    public GameObject pickUpSound;
    public float pointsValue = 5f;
    void OnTriggerEnter(Collider col) { //adds point to player and deletes object
        if (col.tag == "Player") {
            col.GetComponent<PlayerMovemnt>().gc.points += pointsValue;
            destroyEffect.GetComponent<ParticleSystem>().Play();
            pickUpSound.SetActive(true);
            Destroy(gameObject, 0.1f);
        }
    }
}
