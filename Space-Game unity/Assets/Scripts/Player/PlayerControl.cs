using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public AudioClip sound;
    public AudioClip gotHit;

    [SerializeField] float speed = 5.0f;
    float min_x = -33.5f;
    float max_x = 33.5f;
    float min_y = -17.4f;
    float max_y = 17.4f;

    public GameObject bullet;
    public float bullet_cd = 3.0f;
    private float next_fire = 0.0f;
    Vector2 bulletpos;

    public GameObject explosion;
    public GameObject lose_menu;

    Renderer render;
    private bool istrigger = false;
    public static bool isfire = true;
    public static int hp;
    // Start is called before the first frame update

    void Start()
    {
        hp = Variable.playerHp;
        Variable.pasueEnable = true;
        isfire = true;
        Variable.playerAlive = true;
        render = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        fire();
        death();
    }

    void FixedUpdate()
    {

    }

    void movement()
    {
        if (Input.GetAxisRaw("Vertical") > 0f)
        {
            Vector3 temp = transform.position;
            temp.y += speed * Time.deltaTime;

            if (temp.y > max_y)
                temp.y = max_y;

            transform.position = temp;
        }
        else if (Input.GetAxisRaw("Vertical") < 0f)
        {
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;

            if (temp.y < min_y)
                temp.y = min_y;

            transform.position = temp;
        }

        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;

            if (temp.x > max_x)
                temp.x = max_x;

            transform.position = temp;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;

            if (temp.x < min_x)
                temp.x = min_x;

            transform.position = temp;
        }
    }

    void fire()
    {
        if (isfire)
        {
            if (Input.GetKey("space") && Time.time > next_fire)
            {
                GetComponent<AudioSource>().clip = sound;
                next_fire = Time.time + bullet_cd;

                bulletpos = transform.position;
                bulletpos += new Vector2(+2.5f, 0f);
                Instantiate(bullet, bulletpos, Quaternion.identity);
                gameObject.GetComponent<AudioSource>().volume = Variable.soundVolume/3;
                gameObject.GetComponent<AudioSource>().Play();
            }
        }
    }
    void death()
    {
        if (hp <= 0 && Variable.playerAlive)
        {
            Vector2 explosionpos = transform.position;
            Instantiate(explosion, explosionpos, Quaternion.identity);
            StartCoroutine(lose());

            Variable.playerAlive = false;
            render.enabled = false;
            istrigger = true;
            isfire = false;
            if (Variable.highestScore < Variable.scoreValue)
            {
                Variable.highestScore = Variable.scoreValue;
                Variable.highestScoreName = Variable.playerName;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("isTrigger");
        if (collision.gameObject.CompareTag("Meteor")||
            collision.gameObject.CompareTag("enemy bullet")||
            collision.gameObject.CompareTag("Enemy")
            && istrigger == false)
        {
            hp -= 1;
            if (hp > 0)
            {
                GetComponent<AudioSource>().clip = gotHit;
                gameObject.GetComponent<AudioSource>().volume = Variable.soundVolume;
                gameObject.GetComponent<AudioSource>().Play();
            }
        }
        if (collision.gameObject.CompareTag("laser") && istrigger == false)
            hp = 0;
        
    }
    IEnumerator lose()
    {
        yield return new WaitForSeconds(1);
        Variable.pasueEnable = false;
        lose_menu.SetActive(true);
        Time.timeScale = 0;
        Destroy(gameObject);
    }
}
