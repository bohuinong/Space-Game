using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject laser;

    public void finishCharge()
    {
        Vector2 position = transform.position;
        GameObject clone = Instantiate(laser, position, Quaternion.identity);
        clone.transform.Rotate(0, 180, 0);
    }

}
