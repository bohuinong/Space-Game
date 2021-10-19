using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win_menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void newGame()
    {
        Variable.scoreValue = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void main_menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
