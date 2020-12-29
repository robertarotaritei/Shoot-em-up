using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    public bool canShoot;
    public float fireRate, bulletForce, speed, distanceFromTarget;
    public int health, score;
    public GameObject bullet, explosion;
    public GameObject fuel, fuel2;
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
            InvokeRepeating(nameof(EnemyShoot), 1f, fireRate);
        }
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) > distanceFromTarget)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            fuel.SetActive(true);
            fuel2.SetActive(true);
        }
        else
        {
            fuel.SetActive(false);
            fuel2.SetActive(false);
        }
        rb.velocity = new Vector2();

        FacePlayer();
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().Damage(1);
            Die();
        }
    }

    protected void Die()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Score.score += score;
        Destroy(gameObject);
    }

    public void Damage(int damage)
    {
        health -= damage;
        StartCoroutine(Blink());
        if(health <= 0)
        {
            Die();
        }
    }

    IEnumerator Blink()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
    }

    private void FacePlayer()
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
