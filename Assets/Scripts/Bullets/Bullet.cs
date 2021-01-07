using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletDamage;

    private void Awake()
    {
        var bulletsShot = PlayerPrefs.GetInt("Bullets", 0);
        PlayerPrefs.SetInt("Bullets", bulletsShot + 1);
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
