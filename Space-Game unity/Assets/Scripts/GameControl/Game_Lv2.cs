using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Lv2 : MonoBehaviour
{
    // Chaser Enemy spawn
    public float spawn_rate1 = 1.5f;
    public GameObject enemy1;
    private float next_spawn1 = 0;

    // Shooter Enemy spawn
    public float spawn_rate2;
    public GameObject enemy2;
    private float next_spawn2 = 0;
    public int maxEnemy = 5;
    private int numEnemy = 0;

    //wining condition
    public float timer = 29f;

    //score
    public int reward = 1000;
    public int scorePerSecond = 10;
    private float score_counter = 1f;
    private float temp;

    //menu
    public GameObject NextLevelMenu;
    public GameObject pause_menu;

    // Start is called before the first frame update
    void Start()
    {
        temp = score_counter;
        Invoke("levelReward", timer + 1.8f);
    }

    // Update is called once per frame
    void Update()
    {
        spawn1();
        spawn2();
        increment();
        clear();
        GamePause();
    }

    void spawn1()//chaser
    {
        if(Time.time > next_spawn1 && timer >= 0)
        {
            next_spawn1 = Time.time + spawn_rate1;
            Vector2 position1 = new Vector2(Random.Range(40, 45), Random.Range(-18, 18));
            Instantiate(enemy1, position1, Quaternion.identity);
        }
    }
    void spawn2()//shooter
    {
        if(Time.time > next_spawn2 && timer >= 0 && numEnemy <= maxEnemy)
        {
            next_spawn2 = Time.time + spawn_rate2;
            Vector2 position2 = new Vector2(Random.Range(40, 45), Random.Range(-18, 18));

            Instantiate(enemy2, position2, Quaternion.identity);
            numEnemy++;
        }
    }
    void GamePause()
    {
        if (Variable.pasueEnable) { 
            if (Input.GetKeyDown("escape") || Input.GetKeyDown("p"))
            {
                PlayerControl.isfire = false;
                Time.timeScale = 0;
                pause_menu.SetActive(true);
            }
        }
    }
    void levelReward()
    {
        Variable.scoreValue += reward * Variable.scoreMulti;
        Variable.previousScore = Variable.scoreValue;
    }
    void increment()
    {
        temp -= Time.deltaTime;

        if(temp <= 0 && Variable.playerAlive)
        {
            Variable.scoreValue += scorePerSecond;
            temp = score_counter;
        }
    }
    void clear()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
            StartCoroutine(nextLevel());
    }
    IEnumerator nextLevel()
    {
        yield return new WaitForSeconds(2);
        Variable.pasueEnable = false;
        NextLevelMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void decremNumEnemy(int value)
    {
        numEnemy -= value;
    }
}
