using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vertMouseLook : MonoBehaviour
{
    public float lookSpeed = 3;
    private float rotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotation.x += -Input.GetAxis("Mouse Y");
        //transform.eulerAngles = new Vector3() * lookSpeed;
    }
}
