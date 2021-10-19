using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBullet : MonoBehaviour
{
    public float speed = 12f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        Boundary();
    }

    void movement()
    {
        transform.Translate(transform.up * speed * Time.deltaTime);
    }
    void Boundary()
    {
        if (transform.position.x < -35f || transform.position.x > 35f)
            Destroy(gameObject);

        if (transform.position.y < -18f || transform.position.y > 18f)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Destroy(gameObject);
    }
}
