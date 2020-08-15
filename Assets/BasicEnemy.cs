using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public bool canShoot;
    public float fireRate;
    public int health;
    public float distanceFromTarget;
    Transform target;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) > distanceFromTarget)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        rb.velocity = new Vector2();

        facePlayer();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().Damage();
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
    void Damage()
    {
        health--;

        if(health == 0)
        {
            Die();
        }
    }

    private void facePlayer()
    {
        Vector2 direction = new Vector2(
        target.position.x - transform.position.x,
        target.position.y - transform.position.y
        );

        transform.up = direction;
    }
}
