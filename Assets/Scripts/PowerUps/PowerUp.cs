using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private float initializationTime;

    void Start()
    {
        initializationTime = Time.timeSinceLevelLoad;
    }

    void Update()
    {
        if(Time.timeSinceLevelLoad - initializationTime > 10)
        {
            Destroy(gameObject);
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<Player>().LifeUp();
            Destroy(gameObject);
        }
    }
}
