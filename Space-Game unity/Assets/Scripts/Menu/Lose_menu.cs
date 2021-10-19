using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose_menu : MonoBehaviour
{
    public void retry()
    {
        Variable.scoreValue = Variable.previousScore;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void main_menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
