using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Menu : MonoBehaviour
{
    public AudioSource sound;
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }
    public void Level1()
    {
        SceneManager.LoadScene(1);
    }
    public void Level2()
    {
        SceneManager.LoadScene(2);
    }
    public void Level3()
    {
        SceneManager.LoadScene(3);
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
