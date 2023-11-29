using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AugmentationPointsController : MonoBehaviour
{
    public List<pointsGeneratorPool> pointsGeneratorPools = new List<pointsGeneratorPool>();

    public Transform firstCollider;
    public Transform secondCollider;

    void Start()
    {
        Dictionary<pointsGeneratorPool, float> poolsWithChanses = new Dictionary<pointsGeneratorPool, float>();
        float spawnCoefTotal = 0f;
        foreach (pointsGeneratorPool pool in pointsGeneratorPools) spawnCoefTotal += pool.spawnCoef;
        float oneSpawnCoef = 100 / spawnCoefTotal;
        foreach (pointsGeneratorPool pool in pointsGeneratorPools) poolsWithChanses.Add(pool, oneSpawnCoef * pool.spawnCoef);
    }
    
}

[System.Serializable]
public struct pointsGeneratorPool {
    public int maxPoints;
    public int minPoints;

    public float spawnCoef;
    public bool isProcents;
}
