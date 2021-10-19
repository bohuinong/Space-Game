using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Menu : MonoBehaviour
{
    public AudioClip sound;
    public GameObject start;
    void Start()
    {
        GetComponent<AudioSource>().clip = sound;
    }
    public void ExitGame()
    {
        Debug.Log("Exit function work");
        Application.Quit();
    }
    public void buttonClick()
    {
        if (Variable.soundVolume > 0)
        {
            gameObject.GetComponent<AudioSource>().volume = Variable.soundVolume;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    public void closeMenu()
    {
        StartCoroutine(disable());
    }
    IEnumerator disable()
    {
        yield return new WaitForSeconds(.001f);
        gameObject.SetActive(false);
    }
}
