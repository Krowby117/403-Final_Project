using UnityEngine;

public class ClickScript : MonoBehaviour
{
    private GameObject playerRef;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {   

    }

    // making instance of PlayerInfo    
    private void OnMouseDown()
    {
        Debug.Log("Button clicked");
        gameObject.GetComponent<Animator>().SetTrigger("OnClick");
        playerRef.GetComponent<PlayerInfo>().increaseScore();

    }
}
