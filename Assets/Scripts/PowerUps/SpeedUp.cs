using UnityEngine;

public class SpeedUp : PowerUp
{
    public override void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Shooting.speedUp = true;
            Destroy(gameObject);
        }
    }
}
