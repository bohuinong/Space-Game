using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerInput : MonoBehaviour
{
    TMP_InputField input;
    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<TMP_InputField>();
        if (input != null)
            input.text = Variable.playerName;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void changeName(string val)
    {
        Variable.playerName = input.text;
    }

}
