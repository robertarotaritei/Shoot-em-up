using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public int health;
    public GameObject explosion;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.AddForce(movement * speed);

    }
    void Update()
    {
        if (!PauseMenu.GameIsPaused)
        {
            faceMouse();
        }
    }

    public void Damage(int damage)
    {
        health -=damage;
        StartCoroutine(Blink());
        if (health <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    IEnumerator Blink()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
    }

    private void faceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(
        mousePosition.x - transform.position.x,
        mousePosition.y - transform.position.y
        );

        transform.up = direction;
    }
}
