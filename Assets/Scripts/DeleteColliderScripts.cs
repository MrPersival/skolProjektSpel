

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteColliderScripts : MonoBehaviour
{   
    //Destroys all object that entered Collider. Does so to prevent game to have to many objects in game.
    private void OnTriggerEnter(Collider col)
    {
        //Debug.LogWarning("Entered collider, tag: " + col.tag);
        if (col == null) Destroy(col);
    }
}
