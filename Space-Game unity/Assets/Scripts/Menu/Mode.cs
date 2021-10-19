using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode : MonoBehaviour
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

    public void easy()
    {
        Variable.scoreMulti = 1;
        Variable.playerHp = 10;
    }
    public void normal()
    {
        Variable.scoreMulti = 2;
        Variable.playerHp = 5;
    }
    public void hard()
    {
        Variable.scoreMulti = 3;
        Variable.playerHp = 1;
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
        yield return new WaitForSeconds(0.001f);
        gameObject.SetActive(false);
    }
}
