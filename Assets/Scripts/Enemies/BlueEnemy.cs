using UnityEngine;

namespace Assets
{
    class BlueEnemy : Enemy
    {
        public override void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (Player.invincible == false)
                {
                    collision.gameObject.GetComponent<Player>().Damage(2);
                }

                Die();
            }
        }
    }
}
