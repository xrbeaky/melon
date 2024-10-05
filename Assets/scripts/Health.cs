using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EntityType
{
    Player,
    Enemy,
    Destructible,
    Other
}

[RequireComponent(typeof(Collider))]
public class Health : MonoBehaviour
{
    [SerializeField] EntityType type = EntityType.Other;
    [SerializeField] float maxHealth = 100f;
    [SerializeField] ParticleSystem deathVFX;
    [SerializeField] GameObject gfx;
    [SerializeField] float deathVFXDelay;
    
    float health;

    private void Start()
    {
        health = maxHealth;
    }

    public void Heal(float _health)
    {
        if(health < 0 && health + _health > 0)
        {
            Respawn();
        }
        health = Mathf.Clamp(health + _health, 0, maxHealth);
    }

    public void Respawn()
    {
        health = maxHealth;
        gfx.SetActive(true);
    }

    public void DealDamage(float _damage)
    {
        health -= _damage;
        if(health < 0)
        {
            Death();
        }
    }

    void Death()
    {
        switch (type)
        {
            case EntityType.Player:
                gfx.SetActive(false);
                deathVFX.Play();
                GetComponent<Collider>().enabled = false;
                GameManager.instance.Respawn();
                break;
            case EntityType.Enemy:
                deathVFX.Play();
                gfx.SetActive(false);
                GetComponent<Collider>().enabled = false;
                Invoke("Kill", deathVFXDelay);
                break;
            case EntityType.Destructible:
                Invoke("Kill", deathVFXDelay);
                break;
            case EntityType.Other:
                Invoke("Kill", deathVFXDelay);
                break;
        }
        
    }

    void Kill()
    {
        Destroy(gameObject);
    }
}
