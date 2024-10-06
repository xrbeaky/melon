using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public float damage = 51f;
    [SerializeField] float speed = 200f;
    [SerializeField] float lifeTime;
    [SerializeField] GameObject bulletHitFX;
    Vector3 velocity = Vector3.forward;

    private void Start()
    {
        Invoke("Timeout", lifeTime);
    }

    private void Update()
    {
        transform.Translate(velocity * speed * Time.deltaTime);
    }

    void Timeout()
    {
        Destroy(gameObject);
    }

    public void SetBullet(float dmg)
    {
        damage = dmg;
    }

    public void SetBullet(float dmg, float speed)
    {
        damage = dmg;
        this.speed = speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Instantiate(bulletHitFX, transform.position, Quaternion.identity);
            other.GetComponent<Health>().DealDamage(damage);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Environment"))
        {
            Instantiate(bulletHitFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }    
    }
}
