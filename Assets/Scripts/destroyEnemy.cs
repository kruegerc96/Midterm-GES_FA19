using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyEnemy : MonoBehaviour
{
    [SerializeField] float enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //destroy enemy and award points
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            GetPoints();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet" & collision.gameObject.tag == "enemyHead")
        {
            enemyHealth -= 100;
            Debug.Log("Hit Head");
        }

        if (collision.gameObject.tag == "bullet" & collision.gameObject.tag == "enemyBody")
        {
            enemyHealth -= 33.5f;
            Debug.Log("Hit Body");
        }
    }

    private void GetPoints()
    { 

    }
}
