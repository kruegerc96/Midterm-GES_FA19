using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletShoot : MonoBehaviour
{
    [SerializeField] Rigidbody bullet;
    [SerializeField] float bulletSpeed;
    [SerializeField] float fireRate;
    [SerializeField] GameObject bulletSpawn;
    bool shooting = false;

    // Update is called once per frame
    void Update()
    {
        CheckMouseInput();

        Fire();
    }

    void CheckMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shooting = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            shooting = false;
        }
    }

    void Fire()
    {
        if (shooting == true)
        {
            InvokeRepeating("BulletSpawn", 0f, fireRate);
        }
    }

    void BulletSpawn()
    {
        Rigidbody instantiatedBullet = Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        instantiatedBullet.velocity = transform.TransformDirection(new Vector3(0, 0, bulletSpeed));
    }
}
