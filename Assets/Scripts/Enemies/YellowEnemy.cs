using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets
{
    class YellowEnemy : Enemy
    {
        public override void EnemyShoot()
        {
            GameObject enemyBullet = Instantiate(bullet, barrel.position, barrel.rotation);

            enemyBullet.GetComponent<Renderer>().material.color = Color.red;

            Rigidbody2D rb = enemyBullet.GetComponent<Rigidbody2D>();
            rb.AddForce(-barrel.up * bulletForce, ForceMode2D.Impulse);
        }
    }
}
