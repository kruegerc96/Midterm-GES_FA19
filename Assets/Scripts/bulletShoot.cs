using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletShoot : MonoBehaviour
{
    [SerializeField] Rigidbody bullet;
    [SerializeField] float bulletSpeed;
    [SerializeField] float fireRate;
    [SerializeField] GameObject bulletSpawn;
    bool canShoot = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody instantiatedBullet = Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
            instantiatedBullet.velocity = transform.TransformDirection(new Vector3(0, 0, bulletSpeed));

            Invoke("EnableShooting", 1 / fireRate);
        }

        void EnableShooting()
        {
            canShoot = true;
        }
    }
}
