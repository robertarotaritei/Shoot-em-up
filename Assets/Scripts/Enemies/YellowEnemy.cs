using UnityEngine;

namespace Assets
{
    class YellowEnemy : Enemy
    {
        public override void EnemyShoot()
        {
            if (target != null)
            {
                GameObject enemyBullet = Instantiate(bullet, barrel.position, barrel.rotation);

                enemyBullet.GetComponent<Renderer>().material.color = Color.red;

                Rigidbody2D rb = enemyBullet.GetComponent<Rigidbody2D>();
                rb.AddForce(-barrel.up * Random.Range(bulletForce / 1.5f, bulletForce * 1.5f), ForceMode2D.Impulse);

                FindObjectOfType<AudioManager>().Play(Audio.EnemyShoot);
            }
        }
    }
}
