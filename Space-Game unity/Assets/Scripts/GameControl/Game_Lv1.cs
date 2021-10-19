using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Lv1 : MonoBehaviour
{ 
    public float spawn_rate = 0.5f;
    public float max_rate = 0.2f;
    public GameObject meteor;
    public float timer = 10f;
    private float next_spawn = 0.0f;

    //For score
    public int reward = 500;
    public int scorePerSecond = 10;
    private float score_counter = 1f;

    public GameObject NextLevelMenu;
    public GameObject pause_menu;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("levelReward", timer + 4.8f);
    }

    // Update is called once per frame
    void Update()
    {
        increment();
        spawn();
        GamePause();
    }

    void spawn()
    {
        timer -= Time.deltaTime;

        if (Time.time > next_spawn && timer >= 0)
        {
            next_spawn = Time.time + Random.Range(spawn_rate, max_rate);
            Vector2 position = new Vector2(Random.Range(40, 45), Random.Range(-18, 18));
            Instantiate(meteor, position, Quaternion.identity);
        }
        else if (timer <= 0)
            StartCoroutine(nextLevel());
    }

    void increment()
    { 
        score_counter -= Time.deltaTime;

        if (score_counter <= 0 && Variable.playerAlive)
        {
            Variable.scoreValue += scorePerSecond;
            score_counter = 1f;
        }
    }

    void levelReward()
    {
        Variable.scoreValue += reward * Variable.scoreMulti;
        Variable.previousScore = Variable.scoreValue;
    }

    IEnumerator nextLevel()
    {
        yield return new WaitForSeconds(5);
        Variable.pasueEnable = false;
        NextLevelMenu.SetActive(true);
        Time.timeScale = 0;
    }

    void GamePause()
    {
        if (Variable.pasueEnable)
        {
            if (Input.GetKeyDown("escape") || Input.GetKeyDown("p"))
            {
                PlayerControl.isfire = false;
                Time.timeScale = 0;
                pause_menu.SetActive(true);
            }
        }
    }
}
