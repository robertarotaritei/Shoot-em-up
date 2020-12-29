using UnityEngine.UI;
using UnityEngine;

public class LifeCount : MonoBehaviour
{
    public Image[] lives;
    private int lastHealth;

    void Start()
    {
        lastHealth = Player.health;
        int i;
        for (i = 0; i < lastHealth; i++)
        {
            lives[i].enabled = true;
        }
        for (i = lastHealth; i < lives.Length; i++)
        {
            lives[i].enabled = false;
        }
    }

    void Update()
    {
        if(lastHealth != Player.health)
        {
            lastHealth = Player.health;
            int i;
            for(i = 0; i < lastHealth; i++)
            {
                lives[i].enabled = true;
            }
            for(i = lastHealth; i < lives.Length; i++)
            {
                lives[i].enabled = false;
            }
        }
    }
}
