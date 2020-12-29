using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public int startingLives;
    public static int health;
    public GameObject explosion;
    public GameObject fuel, fuel2;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        health = startingLives;
        fuel.SetActive(false);
        fuel2.SetActive(false);
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.AddForce(movement * speed);

        if (rb.velocity.magnitude > 1)
        {
            fuel.SetActive(true);
            fuel2.SetActive(true);
        }
        else
        {
            fuel.SetActive(false);
            fuel2.SetActive(false);
        }
    }

    void Update()
    {
        if (!PauseMenu.GameIsPaused)
        {
            FaceMouse();
        }
    }

    public void Damage(int damage)
    {
        health -= damage;
        StartCoroutine(Blink());
        if (health <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            GameOverMenu.gameIsOver = true;
        }
    }

    IEnumerator Blink()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
    }

    private void FaceMouse()
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
