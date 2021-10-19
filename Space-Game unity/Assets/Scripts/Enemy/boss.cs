using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    //body
    public static int hp;
    public int scorePerHit = 10;
    public GameObject explode;

    //boss skill 1
    public float spawn_rate1 = 5f;
    public GameObject EnergyBall;
    private float next_spawn1 = 0;
    private bool activate1 = false;

    //boss skill 2
    public float spawn_rate2 = 15f;
    public GameObject chargeLaser;
    private float next_spawn2 = 0;
    private bool activate2 = false;
    private GameObject charging;

    // boss skill 3
    public float spawn_rate3 = 2.5f;
    public GameObject spreadBullet;
    private float next_spawn3 = 0;
    private bool activate3 = false;

    // Start is called before the first frame update
    void Start()
    {
        hp = 50;
        StartCoroutine(setActivate1(true,3f));
        StartCoroutine(setActivate2(true, 15f));
        StartCoroutine(setActivate3(true, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        skill1();
        skill2();
        skill3();
        death();
    }

    void skill1() // enegry ball
    {
        if (Time.time > next_spawn1 && activate1)
        {
            next_spawn1 = Time.time + spawn_rate1;
            Vector2 position1 = new Vector2(34, 16.5f);
            Vector2 position2 = new Vector2(34, -16.5f);
            Instantiate(EnergyBall, position1, Quaternion.identity);
            Instantiate(EnergyBall, position2, Quaternion.identity);
        }
    }

    void skill2() // laser
    {
        if(Time.time > next_spawn2 && activate2)
        {
            next_spawn2 = Time.time + spawn_rate2;
            Vector2 position = new Vector2(15.6f, 0.25f);
            charging = Instantiate(chargeLaser, position, Quaternion.identity);
        }
    }
    void skill3() // spread bullet
    {
        if(Time.time > next_spawn3 && activate3)
        {
            next_spawn3 = Time.time + spawn_rate3;
            for (int i = 0; i < 20; i ++) {
                Vector2 position = transform.position;
                GameObject bullet = Instantiate(spreadBullet, position, Quaternion.identity);
                bullet.transform.Rotate(0, 0, 5*i);
            }
        }
    }
    IEnumerator setActivate1(bool value, float time)
    {
        yield return new WaitForSeconds(time);
        activate1 = value;
    }
    IEnumerator setActivate2(bool value, float time)
    {
        yield return new WaitForSeconds(time);
        activate2 = value;
    }
    IEnumerator setActivate3(bool value, float time)
    {
        yield return new WaitForSeconds(time);
        activate3 = value;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player bullet") && Variable.playerAlive) 
        {
            hp -= 1;
            Variable.scoreValue += scorePerHit;
        }
    }

    void death()
    {
        if(hp <= 0)
        {
            Vector2 position = transform.position;
            Instantiate(explode, position, Quaternion.identity);

            if(charging)
                Destroy(charging);

            Destroy(gameObject);
        }
    }
}
