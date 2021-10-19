using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    //moving
    public float moveTimer = 1f;
    private float nextMove = 0f;
    public float moveSpeed = 0.5f;
    float x, y;

    //shooting
    public GameObject enemy_bullet;
    public float fireTimer = 0.5f;
    private float nextFire = 0f;
    Vector2 bulletpos;

   
    public int hp = 3;
    public int scoreOnKill = 100;
    public GameObject explosion;
    public GameObject GameControl;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        fire();
        death();
    }

    void movement()
    {
        if(Time.time > nextMove)
        {
            nextMove = Random.Range(moveTimer,moveTimer +1.2f) + Time.time;
            x = Random.Range(15, 36);
            y = Random.Range(-30, 30); 
        }

        transform.position = Vector2.Lerp(transform.position, new Vector2(x, y), Time.deltaTime * moveSpeed);
    }
    void fire()
    {
        if(Time.time > nextFire)
        {
            nextFire = fireTimer + Time.time;
            bulletpos = transform.position;

           Instantiate(enemy_bullet, bulletpos, Quaternion.identity);
        }
    }

    void death()
    {
        if(hp <= 0)
        {
            Variable.scoreValue += scoreOnKill;

            Vector2 explosionpos = transform.position;
            Instantiate(explosion, explosionpos, Quaternion.identity);

            GameControl.GetComponent<Game_Lv2>().decremNumEnemy(1);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player bullet") || collision.gameObject.CompareTag("Player"))
        {
            hp -= 1;
        }
    }

}
