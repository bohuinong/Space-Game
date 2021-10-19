using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Variable : MonoBehaviour
{
    public static int scoreValue = 0;
    public static int highestScore = 0;
    public static string highestScoreName = "";
    public static int previousScore = 0;
    public static int scoreMulti = 1;

    public static bool playerAlive = true;
    public static bool pasueEnable = false;
    public static float musicVolume = 0.25f;
    public static float soundVolume = 0.50f;
    public static int playerHp = 1;

    public static string playerName = "player";

    public Slider music, sound;

    // Start is called before the first frame update
    void Start()
    {
        scoreValue = 0;
        previousScore = 0;
        playerAlive = true;
        pasueEnable = false;
    }

    // Update is called once per frame
    void Update()
    {
        music.value = musicVolume;
    }
    public void setMusicVolume(float val)
    {
        musicVolume = val;
    }

    public void setSoundVolume(float val)
    {
        soundVolume = val;
    }
}
