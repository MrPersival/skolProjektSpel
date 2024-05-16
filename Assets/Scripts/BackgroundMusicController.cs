using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackgroundMusicController : MonoBehaviour
{
    public AudioClip[] songs;
    public AudioSource backgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
        backgroundMusic.clip = songs[Random.Range(0, songs.Length)];
        backgroundMusic.Play();
    }
}
