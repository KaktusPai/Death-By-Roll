using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    //References
    public PlayerManager playerManager;
    public PlayerMovement playerMovement;
    //Variables
    public float bulletSpeed;
    public float shootCooldown;
    public bool isShooting;
    public bool canShoot = true;
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
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot == true)
        {
            ShootBullet();
            Debug.Log("Clicked to shoot");
            canShoot = false;
        }
    }
    void ShootBullet()
    {
        bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
    }
}
