using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    bool canShoot = true;
    [SerializeField] float bulletDamage;
    [SerializeField] float bulletSpeed;
    [SerializeField] float shootDelay = 0.4f;
    private float shootTimer = 0f;
    [SerializeField] Transform bullet;
    [SerializeField] Transform firePoint;
    [SerializeField] AudioSource bulletSound;
    bool locked;

    private void Update()
    {
        if (!locked)
        {
            CheckShoot();
        }
    }

    void Shoot()
    {
        foreach (AudioSource source in bulletSound.transform.GetComponentsInChildren<AudioSource>())
        {
            if (source != null)
            {
                source.Play();
            }
        }

        var bul = Instantiate(bullet, firePoint.position, Quaternion.identity).GetComponent<Bullet>();
        bul.SetBullet(bulletDamage, bulletSpeed);
        canShoot = false;
        shootTimer = shootDelay;
    }

    void CheckShoot()
    {
        if (!canShoot)
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer < 0f)
            {
                canShoot = true;
            }
        }

        if (Input.GetKey(KeyCode.Space) && canShoot)
        {
            Shoot();
        }
    }

    public void onPlayerDeath()
    {
        locked = true;
    }

    public void onPlayerRespawn()
    {
        locked = false;
        GetComponent<Health>().Heal(100f);
    }
}
