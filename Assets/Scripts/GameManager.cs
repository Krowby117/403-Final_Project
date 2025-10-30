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
    private bool countingDown = false; // only true when in MainScene
    private int seconds;
    private int remainingSeconds;

    public TextMeshProUGUI counterTMP;

    // making an instance of PlayerInfo 
    public PlayerInfo playerReference;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        // keeping track of current scene
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "MainScene")
        {
            countingDown = true;

        }
     
    }

    // Update is called once per frame
    void Update()
    {
        // if we are in the proper scene, the counter begins 
        if (countingDown)
        {
            remainingSeconds = Countdown();

            // if time runs out, game ends
            if (remainingSeconds == 0 )
            {
                // go to game over scene 
                SceneManager.LoadScene(1);
                Debug.Log("Scene changed to GameOver");
            }


        }

        // if the score meets the quota then change to unpaid overtime 

        // when the time ends unpaid overtime ends also and goes to shop 
    }

    /// <summary>
    ///  Countdown: decreases according to deltatime 
    ///  only counts down if countingDown is true 
    ///  updates the counter TMP
    /// </summary>
    private int Countdown()
    {   
        // timer only decreases in the main scene 
        dayLength -= Time.deltaTime;

        // converting to seconds and displaying 
        int seconds = (int)(dayLength % 60);
        Debug.Log("Counter is now: " + seconds);
        counterTMP.text = "" + seconds;

        return seconds;

    }
}
