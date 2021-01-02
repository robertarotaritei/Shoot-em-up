using UnityEngine;

public class LifeUp : PowerUp
{
    public override void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<Player>().LifeUp();
            Destroy(gameObject);
        }
    }
}
