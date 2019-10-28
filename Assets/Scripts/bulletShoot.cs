using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletShoot : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float shootForce = 10f;
    [SerializeField] float shotsPerSecond = 10;

    void Update()
    {
        while (Input.GetMouseButtonDown(0))
        {
            GameObject bulletPrefab = Instantiate(bullet, transform.position, Quaternion.identity);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            // A quaternion multiplied by a Vector applies that rotation to the Vector.
            Vector3 direction = Quaternion.Euler(0, 0, 15) * transform.forward;

            rb.AddForce(direction * shootForce, ForceMode.Impulse);
        }
    }
}
