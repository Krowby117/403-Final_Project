using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopTimer : MonoBehaviour
{
    public float shopTime = 30f;
    private float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= shopTime)
        {
            SceneManager.LoadScene("MainScene");
        }
        gameObject.GetComponent<TextMeshProUGUI>().text = (shopTime - (int) timer).ToString();
    }
}
