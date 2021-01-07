using UnityEngine.UI;
using UnityEngine;

public class LifeCount : MonoBehaviour
{
    public Image[] lives;
    public Animator danger;
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
            if(lastHealth == 2 && Player.health <= 1)
            {
                danger.Play("Danger");
            }

            if (lastHealth == 1 && Player.health == 2)
            {
                danger.Play("Safe");
            }

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
