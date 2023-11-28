using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteColliderScripts : MonoBehaviour
{
    public GameController gameController;

    private void OnTriggerEnter(Collider col)
    {
        if(col != null)
        {
            gameController.deletePaltform(col.gameObject);
        }
    }
}
