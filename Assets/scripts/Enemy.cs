using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float damage = 20f;
    [SerializeField] float lifetime = 10f;
    private Health health;

    private void Start()
    {
        health = GetComponent<Health>();

        Invoke("Death", lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Health>().DealDamage(damage);
        }
    }

    private void OnDrawGizmos()
    {
       Gizmos.DrawWireSphere(transform.position, 2f);
    }

    void Death()
    {
        health.DealDamage(200f);
    }
}
