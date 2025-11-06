using System.Collections;
using UnityEngine;

public class RandomMultiplier : MonoBehaviour
{
    private float timer;
    private bool isActive = false;
    private bool isRunning = false;
    
    public GameObject button;
    public int cooldown = 20;
    public int buttonProb = 25; // the larger the less likely

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(cooldown < timer)
        {
            if (!isRunning)
            {
                StartCoroutine(tryForButton());
            }
            if (isActive)
            {
                StartCoroutine(buttonAvailable());
            }
            isActive = false;
        }
        timer += Time.deltaTime;
    }
    
    public void activateButtonMult()
    {
        
    }
    IEnumerator buttonAvailable()
    {
        timer = 0;
        button.SetActive(true);
        yield return new WaitForSeconds(10);
        button.SetActive(false);
    }

    IEnumerator tryForButton()
    {
        isRunning = true;
        Debug.Log("running coroutine");
        yield return new WaitForSeconds(2);
        int r = Random.Range(1, buttonProb);
        Debug.Log(r);
        if (r == 1) {
            isActive = true;
        }
        isRunning = false;
    }

}
