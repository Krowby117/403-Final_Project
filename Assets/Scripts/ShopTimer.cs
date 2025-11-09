using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopTimer : MonoBehaviour
{
    public float shopTime = 30f;
    private void Start()
    {
        shopTime += (int) Time.realtimeSinceStartup;
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.realtimeSinceStartup >= shopTime)
        {
            SceneManager.LoadScene("MainScene");
        }
        gameObject.GetComponent<TextMeshProUGUI>().text = ((int) shopTime - (int) Time.realtimeSinceStartup).ToString();
    }
}
