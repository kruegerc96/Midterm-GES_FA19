using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletShoot : MonoBehaviour
{
    [SerializeField] Rigidbody bullet;
    [SerializeField] float bulletSpeed;
    [SerializeField] float fireRate;
    [SerializeField] GameObject bulletSpawn;
    [SerializeField] ParticleSystem muzzleFlash;

    private float timeLastFired = 0f;
    private bool firing = false;

    // Update is called once per frame
    void Update()
    {
       
    }

    void FixedUpdate()
    {
        float timeSinceLastFired = Time.time - timeLastFired;

        //calculates true or false
        bool canFire = timeSinceLastFired >= (1 / fireRate);

        if (Input.GetButton("Fire1") && canFire)
        {
            BulletSpawn();
        }
    }

    void BulletSpawn()
    {
        Rigidbody instantiatedBullet = Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        instantiatedBullet.velocity = transform.TransformDirection(new Vector3(0, 0, bulletSpeed));

        timeLastFired = Time.time;

        //play muzzle flash
        muzzleFlash.Emit(1);
        AkSoundEngine.PostEvent("PlayFire", gameObject);
    }
}
