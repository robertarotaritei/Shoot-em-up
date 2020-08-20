using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    float delay = 60;
    public GameObject bullet;
    public float fireRatePerSecond;
    Transform leftBarrel, rightBarrel;
    public float bulletForce;

    public void Awake()
    {
        leftBarrel = transform.Find("LeftBarrel");
        rightBarrel = transform.Find("RightBarrel");
    }
    void Start()
    {
        
    }
    void Update()
    {
        if (!PauseMenu.GameIsPaused)
        {
            if (Input.GetButton("Fire1") && delay / 60 > fireRatePerSecond)
            {
                Shoot();
            }

            delay++;
        }
    }
    private void Shoot()
    {
        delay = 0;
        GameObject leftBullet = Instantiate(bullet, leftBarrel.position, leftBarrel.rotation);
        GameObject rightBullet = Instantiate(bullet, rightBarrel.transform.position, rightBarrel.transform.rotation);

        Rigidbody2D rb = leftBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(leftBarrel.up * bulletForce, ForceMode2D.Impulse);
        rb = rightBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(rightBarrel.up * bulletForce, ForceMode2D.Impulse);
    }
    public void EnemyShoot(Transform barrel, float bulletForce)
    {
        GameObject enemyBullet = Instantiate(bullet, barrel.position, barrel.rotation);
        
        Rigidbody2D rb = enemyBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(barrel.up * bulletForce, ForceMode2D.Impulse);
    }
}
