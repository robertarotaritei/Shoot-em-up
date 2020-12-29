﻿using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletDamage;

    private void Awake()
    {
        Destroy(gameObject, 2.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().Damage(bulletDamage);
            Destroy(gameObject);
        }
    }
}
