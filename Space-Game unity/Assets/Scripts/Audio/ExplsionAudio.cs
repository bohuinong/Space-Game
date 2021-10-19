using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplsionAudio : MonoBehaviour
{
    public AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void explode()
    {
        sound.volume = Variable.soundVolume/3;
        sound.Play();
    }
}
