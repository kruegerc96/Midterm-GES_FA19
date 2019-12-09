﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyEnemy : MonoBehaviour
{
    public int score = FindObjectOfType<scoreManager>().currentScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Debug.Log("Hit Head");
            GetPoints();
            Destroy(transform.parent.gameObject);
        }
    }

    private void GetPoints()
    {
        FindObjectOfType<scoreManager>().currentScore += 100;
    }
}
