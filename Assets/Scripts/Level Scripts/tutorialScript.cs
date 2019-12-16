﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorialScript : MonoBehaviour
{
    private int winCondition = 300;

    // Start is called before the first frame update
    void Start()
    {
        //establish win condition
        FindObjectOfType<scoreManager>().maxScore = winCondition;
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<scoreManager>().currentScore >= winCondition)
        {
            SceneManager.LoadScene("Level 1");
        }
    }
}