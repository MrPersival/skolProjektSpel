using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Random = System.Random;

public class AugmentationPointsController : MonoBehaviour
{
    public List<pointsGeneratorPool> pointsGeneratorPools = new List<pointsGeneratorPool>();

    public Transform firstCollider;
    public TextMeshProUGUI firstColliderPointsText;
    public Transform secondCollider;
    public TextMeshProUGUI secondColliderPointsText;

    private triggerPoints firstColTriggerPoints = new triggerPoints();
    private triggerPoints secondColTriggerPoints = new triggerPoints();


    void Start()
    {
        Dictionary<pointsGeneratorPool, float> poolsWithChanses = new Dictionary<pointsGeneratorPool, float>();
        float spawnCoefTotal = 0f;
        foreach (pointsGeneratorPool pool in pointsGeneratorPools) spawnCoefTotal += pool.spawnCoef;
        float oneSpawnCoef = 100 / spawnCoefTotal;
        float lastChanse = 0;
        foreach (pointsGeneratorPool pool in pointsGeneratorPools)
        {
            poolsWithChanses.Add(pool, oneSpawnCoef * pool.spawnCoef + lastChanse);
            //Debug.LogWarning($"Chanses of spawning: {oneSpawnCoef * pool.spawnCoef + lastChanse}");
            lastChanse += (oneSpawnCoef * pool.spawnCoef);
        }

        //TODO: Possible to do as cycle when needed
        Random rnd = new Random();
        float rndChanse = rnd.Next(0, 1000) / 10;
        pointsGeneratorPool chosedPGP = new pointsGeneratorPool();
        //Debug.LogWarning(rndChanse);
        foreach(var pool in poolsWithChanses) {
            //Debug.LogWarning(rndChanse + " " + pool.Value);
            if(pool.Value >= rndChanse) {
                chosedPGP = pool.Key;
                //Debug.LogWarning($"{chosedPGP.maxPoints}, {chosedPGP.minPoints}, {pool.Value}, {rndChanse}");
                break;
            }
        }
        firstColTriggerPoints.points = rnd.Next(chosedPGP.minPoints, chosedPGP.maxPoints);
        firstColTriggerPoints.isProcents = chosedPGP.isProcents;
        //Debug.LogWarning($"Chosed PGP for first: {chosedPGP.minPoints}, {chosedPGP.maxPoints}, {chosedPGP.isProcents}. Coef was {chosedPGP.spawnCoef}, chanse to spawn was {poolsWithChanses[chosedPGP]}, rndNumber {rndChanse}");

        rndChanse = rnd.Next(0, 1000) / 10;
        foreach(var pool in poolsWithChanses) {
            if(pool.Value <= rndChanse) {
                chosedPGP = pool.Key;
                break;
            }
        }
        secondColTriggerPoints.points = rnd.Next(chosedPGP.minPoints, chosedPGP.maxPoints);
        secondColTriggerPoints.isProcents = chosedPGP.isProcents;

        if(firstColTriggerPoints.isProcents) firstColliderPointsText.text = Convert.ToString(firstColTriggerPoints.points) + " %";
        else firstColliderPointsText.text = Convert.ToString(firstColTriggerPoints.points);
        if(secondColTriggerPoints.isProcents) secondColliderPointsText.text = Convert.ToString(secondColTriggerPoints.points) + " %";
        else secondColliderPointsText.text = Convert.ToString(secondColTriggerPoints.points);

    }
    
}

[System.Serializable]
public struct pointsGeneratorPool {
    public int maxPoints;
    public int minPoints;

    public float spawnCoef;
    public bool isProcents;
}

public struct triggerPoints
{
    public int points;
    public bool isProcents;
}
