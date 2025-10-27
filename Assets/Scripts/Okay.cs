using System;
using UnityEngine;

public class Okay : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            gameObject.transform.position = new Vector3(.4f, .4f, 0f);
        }
    }

    public void SaySomething()
    {
        Debug.Log("SaySomething");
    }
}
