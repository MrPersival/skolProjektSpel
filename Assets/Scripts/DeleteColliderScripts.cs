using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteColliderScripts : MonoBehaviour
{
    public GameController gameController;
    public Transform basePlane;
    
    private Transform basePlaneTransformOnStart;

    void Start() {
        basePlaneTransformOnStart = basePlane;
    }

    private void OnTriggerEnter(Collider col)
    {
        //Debug.LogWarning("Entered collider, tag: " + col.tag);
        if (col == basePlane) basePlane = basePlaneTransformOnStart;
        else if (col.tag == "Platform") gameController.deletePaltform(col.gameObject);
    }
}
