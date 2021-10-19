using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
        music.volume = Variable.musicVolume;
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        music.volume = Variable.musicVolume;
    }
}
