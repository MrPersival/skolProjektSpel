using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class trapGenerator : MonoBehaviour
{

    public trapsPreset[] trapsPresets;
    void Start() //Decides what trap preset to use. All presets have diffrent coeficient to spawn.
    {
        float summOfAllCoef = 0f;
        foreach (trapsPreset preset in trapsPresets) summOfAllCoef += preset.coefToSpawn;
        float oneSpawnCoef = 100f / summOfAllCoef;
        Dictionary<trapsPreset, float> trapsWithChanses = new Dictionary<trapsPreset, float>();
        float lastChanse = 0f;
        foreach (trapsPreset preset in trapsPresets)
        {
            trapsWithChanses.Add(preset, oneSpawnCoef * preset.coefToSpawn + lastChanse);
            lastChanse = oneSpawnCoef * preset.coefToSpawn + lastChanse;
        }
        System.Random rand = new System.Random();
        float rndChanse = rand.Next(0, 100);

        foreach(var dictObj in trapsWithChanses)
        {
            //Debug.LogWarning(rndChanse);
            if (dictObj.Value >= rndChanse)
            {
                dictObj.Key.preset.SetActive(true);
                //Debug.LogWarning(dictObj.Value);
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
