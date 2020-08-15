using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        GameObject leftBullet = Instantiate(bullet, leftBarrel.position, leftBarrel.rotation);
        GameObject rightBullet = Instantiate(bullet, rightBarrel.transform.position, rightBarrel.transform.rotation);

        Rigidbody2D rb = leftBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(leftBarrel.up * bulletForce, ForceMode2D.Impulse);
        rb = rightBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(rightBarrel.up * bulletForce, ForceMode2D.Impulse);
    }
}
