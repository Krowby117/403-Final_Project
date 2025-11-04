using UnityEngine;
using UnityEngine.InputSystem.Controls;
using TMPro;
//using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

/// <summary>
/// GameManager: class which handles scene transitions and the 
/// </summary>
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
        playerReference = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>();
        playerReference.addDay();

    }

    // Update is called once per frame
    void Update()
    {
        // keeping track of current scene
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "MainScene")
        {
            countingDown = true;
        }
        // if we are in the proper scene, the counter begins 
        if (countingDown)
        {
            remainingSeconds = Countdown();

            // if time runs out and quota is not met, game ends
            if (remainingSeconds == 0 && playerReference.getCurPoints() < playerReference.getQuota() )
            {
                // go to game over scene 
                SceneManager.LoadScene(3);
                Debug.Log("Scene changed to GameOver");
            }

            else if(remainingSeconds == 0 && playerReference.getCurPoints() >= playerReference.getQuota())
            {
                // go to the shop scene 
                SceneManager.LoadScene(2);
                Debug.Log("Scene changed to ShopScene");
            }
        }

        // if the score meets the quota then change to unpaid overtime 
        //if (playerReference.getCurPoints() == playerReference.getQuota())
        //{
            // implementation of unpaid overtime goes here 
        //}
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
