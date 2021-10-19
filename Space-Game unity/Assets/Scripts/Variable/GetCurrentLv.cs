using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GetCurrentLv : MonoBehaviour
{
    TextMeshProUGUI level;
    // Start is called before the first frame update
    void Start()
    {
        level = GetComponent<TextMeshProUGUI>();
        level.SetText("level {0}", SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
