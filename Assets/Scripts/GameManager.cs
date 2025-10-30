using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class GameManager : MonoBehaviour
{
    // establishing counter for day length 
    // should remain constant throughout game as quota increases 

    private float dayLength = 60f;
    private bool countingDown = true; // not intially counting down on main menu 
    private int seconds; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Countdown();
    }

    /// <summary>
    ///  Countdown function which decreases according to deltatime 
    ///  only counts down if countingDown is true 
    /// </summary>

    void Countdown()
    {
        if (countingDown) {
            dayLength -= Time.deltaTime;
        }
        // converting to seconds and displaying 
        int seconds = (int)(dayLength % 60);
        Debug.Log("Counter is now: " + seconds);




    }
}
