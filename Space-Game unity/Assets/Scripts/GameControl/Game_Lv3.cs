using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Lv3 : MonoBehaviour
{
    //boss
    public GameObject boss;
    GameObject clone;
    private bool isClear;

    //score
    public int reward = 3000;
    public int bossScore = 10000;
    public int ScorePerSecond = 10;
    private float score_counter = 1f;
    private float next_score = 0;

    //menu
    public GameObject win_menu;
    public GameObject pause_menu;

    // Start is called before the first frame update
    void Start()
    {
        isClear = false;
        bossSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        decrement();
        clear();
        GamePause();
    }

    void bossSpawn()
    {
        Vector2 position = new Vector2(30, 0);
        clone =Instantiate(boss, position, Quaternion.identity);
        clone.transform.Rotate(0, 0, 270);
    }
    void decrement()
    {
        if (Time.time > next_score && Variable.playerAlive && bossScore >= 0)
        {
            next_score = Time.time + score_counter;
            bossScore -= ScorePerSecond;
        }
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
    void clear()
    {
        if (clone == null && isClear == false)
        {
            Variable.scoreValue += reward * Variable.scoreMulti + bossScore;
            if (Variable.highestScore < Variable.scoreValue)
            {
                Variable.highestScore = Variable.scoreValue;
                Variable.highestScoreName = Variable.playerName;
            }
            StartCoroutine(win());
            isClear = true;
        }
    }
    IEnumerator win()
    {
        yield return new WaitForSeconds(1);
        Variable.pasueEnable = false;
        win_menu.SetActive(true);
        Time.timeScale = 0;
    }
}
