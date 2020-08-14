using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public int health;
    private void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
        rb.AddForce(new Vector2(0, Input.GetAxis("Vertical") * speed));
    }

    public void Damage()
    {
        health--;

        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
}
