using UnityEngine;

namespace Assets
{
    class RedEnemy : Enemy
    {
        public override void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<Player>().Damage(1);
                Die();
            }
        }
    }
}
