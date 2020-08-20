using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public bool canShoot;
    public float fireRate;
    public int health;
    public float distanceFromTarget;
    public GameObject bullet;
    public float bulletForce;
    protected Transform target, barrel;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        barrel = transform.Find("barrel");
    }
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (canShoot)
        {
            InvokeRepeating("EnemyShoot", 1f, fireRate);
        }
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) > distanceFromTarget)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        rb.velocity = new Vector2();

        facePlayer();
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().Damage(1);
            Die();
        }
    }

    protected void Die()
    {
        Destroy(gameObject);
    }
    public void Damage(int damage)
    {
        health -= damage;

        if(health <= 0)
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
    public virtual void EnemyShoot()
    {
        GameObject enemyBullet = Instantiate(bullet, barrel.position, barrel.rotation);

        Rigidbody2D rb = enemyBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(-barrel.up * bulletForce, ForceMode2D.Impulse);
    }
}
