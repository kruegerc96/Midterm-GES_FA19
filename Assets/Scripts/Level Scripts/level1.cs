using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level1 : MonoBehaviour
{
    private int winCondition = 500;
    private int totalTargets = 5;
    public int targetsHit;

    GameObject target1;
    GameObject target2;
    GameObject target3;
    GameObject target4;
    GameObject target5;

    public GUIText targetsLeftText;

    // Start is called before the first frame update
    void Start()
    {
        //establish win condition
        FindObjectOfType<scoreManager>().maxScore = winCondition;

        //set UI text
        FindObjectOfType<scoreManager>().maxScore = winCondition;
    }

    // Update is called once per frame
    void Update()
    {
        //update GUI text
        targetsLeftText.text = $"Targets remaining: {targetsHit}/{totalTargets}";

        if (FindObjectOfType<scoreManager>().currentScore >= winCondition)
        {
            SceneManager.LoadScene("Level 2");
        }
    }
}
