using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    TextMeshProUGUI highScore;
    // Start is called before the first frame update
    void Start()
    {
        highScore = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        highScore.SetText(Variable.highestScoreName + " - {0}",Variable.highestScore);
    }
}
