using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable_menu : MonoBehaviour
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
    public void onClick()
    {
        sound.volume = Variable.soundVolume;
        sound.Play();
    }
    public void close()
    {
        StartCoroutine(disable());
    }
    IEnumerator disable()
    {
        yield return new WaitForSeconds(0.02f);
        gameObject.SetActive(false);
    }
}
