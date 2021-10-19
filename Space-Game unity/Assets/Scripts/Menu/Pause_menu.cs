using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_menu : MonoBehaviour
{
    void Start()
    {
    }
    void Update()
    {
        if(Input.GetKeyDown("escape") || Input.GetKeyDown("p"))
        {
            PlayerControl.isfire = true;

            Time.timeScale = 1;
            gameObject.SetActive(false);
        }
    }
    public void resume()
    {
        PlayerControl.isfire = true;
        Time.timeScale = 1;
    }
    public void mainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
