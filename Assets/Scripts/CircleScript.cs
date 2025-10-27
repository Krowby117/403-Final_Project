using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CircleScript : MonoBehaviour
{
    //public GameObject square; can grab whole objects 
    //public Transform square; // can also grab obj components
    public Collider2D mousecollide;

    // awake runs before everything in start
    private void Awake()
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene("Scene2");
        }

    }
}
