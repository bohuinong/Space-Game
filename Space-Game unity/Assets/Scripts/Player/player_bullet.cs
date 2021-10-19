using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_bullet : MonoBehaviour
{
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    void movement()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;

        if (temp.x > 35f)
            Destroy(gameObject,.2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("isTrigged");

        if (collision.gameObject.CompareTag("Meteor") ||
            collision.gameObject.CompareTag("Enemy")||
            collision.gameObject.CompareTag("laser"))
        {
            Destroy(gameObject);
        }
    }
}
