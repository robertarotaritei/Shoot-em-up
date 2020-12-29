using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int bulletDamage;

    private void Awake()
    {
        Destroy(gameObject, 2.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().Damage(bulletDamage);
            Destroy(gameObject);
        }
    }
}
