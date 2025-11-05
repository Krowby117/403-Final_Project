using UnityEngine;

public class MultButton : MonoBehaviour
{
    private GameObject playerRef;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnMouseDown()
    {
        StartCoroutine(playerRef.GetComponent<PlayerInfo>().multiplyScore());
        gameObject.SetActive(false);
    }
}
