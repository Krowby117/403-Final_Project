using TMPro;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    // quotaScore is the players current 
    private int quotaScore = 0;
    private int quota = 100;
    
    private int unpaidOvertime;

    public TextMeshProUGUI quotaTMP;
    public TextMeshProUGUI unpaidTMP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addQuota()
    {
        quotaScore += 1;
        quotaTMP.text = "Quota - " + quotaScore + "/" + quota;
    }
    
    public void addUnpaidOT()
    {
        unpaidOvertime += 1;
        unpaidTMP.text = "Unpaid Overtime - " + unpaidOvertime;
    }
    public void removeUnpaidOT(int cost)
    {
        if (unpaidOvertime >= cost)
        {
            unpaidOvertime -= cost;
            unpaidTMP.text = "Unpaid Overtime - " + unpaidOvertime;
            Debug.Log("give player cosmetic");
        }
    }
}
