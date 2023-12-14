using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class trapGenerator : MonoBehaviour
{

    public trapsPreset[] trapsPresets;
    void Start()
    {
        float summOfAllCoef = 0f;
        foreach (trapsPreset preset in trapsPresets) summOfAllCoef += preset.coefToSpawn;
        float oneSpawnCoef = 100 / summOfAllCoef;
        Dictionary<trapsPreset, float> trapsWithChanses = new Dictionary<trapsPreset, float>();
        float lastChanse = 0;
        foreach (trapsPreset preset in trapsPresets)
        {
            trapsWithChanses.Add(preset, oneSpawnCoef * preset.coefToSpawn + lastChanse);
            lastChanse += oneSpawnCoef * preset.coefToSpawn;
        }
        float rndChanse = UnityEngine.Random.Range(0, 100);

        foreach(var dictObj in trapsWithChanses)
        {
            if(dictObj.Value <= rndChanse)
            {
                dictObj.Key.preset.SetActive(true);
                break;
            }
        }

    }
}

[Serializable]
public struct trapsPreset {
    public GameObject preset;
    public float coefToSpawn;
    
}
