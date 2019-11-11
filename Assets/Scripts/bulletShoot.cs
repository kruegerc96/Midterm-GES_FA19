using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletShoot : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float shootForce = 1000f;
    [SerializeField] float shotsPerSecond = 10;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab, GameObject.("Bullet Spawn").transform.position, Quaternion.identity);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            // A quaternion multiplied by a Vector applies that rotation to the Vector.
            Vector3 direction = Quaternion.Euler(90, 0, 0) * transform.forward;

            rb.velocity = transform.TransformDirection(Vector3.forward * 10);
        }
    }
}
