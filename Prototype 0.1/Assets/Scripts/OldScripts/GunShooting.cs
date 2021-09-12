using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    //References
    public PlayerManager playerManager;
    //Variables
    public float bulletSpeed;
    public float shootCooldown;
    public bool isShooting;
    public bool canShoot;
    //Objects
    GameObject bullet;
    public GameObject pivot;
    public GameObject gun;
    public Transform firePoint;
    public GameObject bulletPrefab;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            canShoot = false;
            ShootGun();
        }
    }
    void ShootGun()
    {
        bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
    }
}
