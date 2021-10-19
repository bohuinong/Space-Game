using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetBossHp : MonoBehaviour
{
    TextMeshProUGUI hp;
    // Start is called before the first frame update
    void Start()
    {
        hp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(boss.hp > 0)
            hp.SetText("boss hp {0}", boss.hp);
        else
            hp.SetText("boss hp {0}", 0);
    }
}
