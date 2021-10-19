using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 direction;
    private Vector2 previousDirection;
    public float speed = 15f;

    public int hp = 2;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 2000 * Time.deltaTime);
        Boundary();
        death();
    }
    void FixedUpdate()
    {
        direction = (player.position - transform.position).normalized;

        if (direction.x < 0)
        {
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
            previousDirection = direction;
        }
        else
            rb.MovePosition(rb.position + previousDirection * speed * Time.fixedDeltaTime);
    }
    void Boundary()
    {
        if (rb.position.x < -40f)
            Destroy(gameObject);

        if (rb.position.y > 22f || rb.position.y < -22f)
            Destroy(gameObject);
    }

    void death()
    {
        if (hp <= 0)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("player bullet"))
        {
            hp -= 1;
        }
    }
}
