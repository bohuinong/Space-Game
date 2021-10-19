using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetPlayerHp : MonoBehaviour
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
        if (PlayerControl.hp > 0)
            hp.SetText(Variable.playerName+ ": {0}", PlayerControl.hp);
        else
            hp.SetText(Variable.playerName +": {0}", 0);
    }
}
