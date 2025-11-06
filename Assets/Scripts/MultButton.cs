using UnityEngine;

public class MultButton : MonoBehaviour
{
    private GameObject buttonRef;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        buttonRef = GameObject.FindGameObjectWithTag("MultButton");
    }
    private void OnMouseDown()
    {
        buttonRef.GetComponent<RandomMultiplier>().activateButtonMult();
        gameObject.SetActive(false);
    }
}
