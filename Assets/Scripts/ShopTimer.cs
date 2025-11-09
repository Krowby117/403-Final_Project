using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopTimer : MonoBehaviour
{
    public float shopTime = 30f;

    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad >= shopTime)
        {
            SceneManager.LoadScene("MainScene");
        }
        gameObject.GetComponent<TextMeshProUGUI>().text = (shopTime - (int) Time.timeSinceLevelLoad).ToString();
    }
}
