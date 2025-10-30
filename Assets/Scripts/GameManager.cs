using UnityEngine;
using UnityEngine.InputSystem.Controls;
using TMPro;
//using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // establishing counter for day length 
    // should remain constant throughout game as quota increases 

    private float dayLength = 60f;
    private bool countingDown = false; // not intially counting down on main menu 
    private int seconds;

    public TextMeshProUGUI counterTMP;

    // keeping track of current scene
    //Scene currentScene = SceneManager.GetActiveScene();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //if (currentScene.name == "MainScene")
        //{
        //    Countdown();

        //}
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    /// <summary>
    ///  Countdown: decreases according to deltatime 
    ///  only counts down if countingDown is true 
    ///  updates the counter TMP
    /// </summary>

    private void Countdown()
    {   
        // timer only decreases in the main scene 
        dayLength -= Time.deltaTime;

        // converting to seconds and displaying 
        int seconds = (int)(dayLength % 60);
        Debug.Log("Counter is now: " + seconds);
        counterTMP.text = "" + seconds;

    }
}
