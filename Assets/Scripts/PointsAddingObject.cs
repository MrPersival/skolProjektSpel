using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PointsAddingObject : MonoBehaviour
{
    void OnTriggerEnter(Collider col) {
        if (col.tag == "Player") {
            col.GetComponent<PlayerMovemnt>().gc.points += 1;
            gameObject.transform.Find("DestroyEffect").GetComponent<ParticleSystem>().Play();
            Destroy(gameObject, 0.1f);
        }
    }
}
