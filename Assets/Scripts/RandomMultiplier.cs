using System.Collections;
using System.Threading;
using UnityEngine;

public class RandomMultiplier : MonoBehaviour
{
    private float multiplier;
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
        Debug.Log("getting new mult");
        getMult();
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
    
    IEnumerator buttonAvailable()
    {
        timer = 0;
        button.SetActive(true);
        yield return new WaitForSeconds(10);
        button.SetActive(false);
        getMult();
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
    private void getMult()
    {
        if (Random.Range(0, 2) == 0)
        {
            multiplier = Random.value * .5f;
        }
        else
        {
            multiplier = Random.value + 1;
        }
        Debug.Log(multiplier);
    }
}
