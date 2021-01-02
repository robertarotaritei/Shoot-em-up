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
    private Vector2 lastPosition;
    private bool fuelState, fuelPastState = false;
    public static bool invincible = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        health = startingLives;
        lastPosition = rb.position;
        SetFuel(false);
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        var displacement = rb.position - lastPosition;
        lastPosition = rb.position;

        if (displacement.magnitude > 0.035)
        {
            SetFuel(true);
            fuelState = true;
        }
        else
        {
            SetFuel(false);
            fuelState = false;
        }

        if(fuelState != fuelPastState)
        {
            if (fuelState)
            {
                FindObjectOfType<AudioManager>().Play(Audio.Fuel);
            }
            else
            {
                FindObjectOfType<AudioManager>().Stop(Audio.Fuel);
            }
            fuelPastState = fuelState;
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
        invincible = true;
        StartCoroutine(Blink());
        invincible = false;
        if (health <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play(Audio.PlayerDeath);
            FindObjectOfType<AudioManager>().Stop(Audio.Fuel);
            GameOverMenu.gameIsOver = true;
        }
    }

    public void LifeUp()
    {
        if (health < 5)
        {
            health += 1;
        }
    }

    IEnumerator Blink()
    {
        for(int i = 0; i < 3; i++)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
            yield return new WaitForSeconds(0.2f);
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            yield return new WaitForSeconds(0.2f);
        }
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

    private void SetFuel(bool value)
    {
        fuel.SetActive(value);
        fuel2.SetActive(value);
    }
}
