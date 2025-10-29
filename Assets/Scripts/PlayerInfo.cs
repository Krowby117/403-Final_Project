using TMPro;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    // score / point tracker variables
    private int curPoints = 0;      // player's current score
    private int quota = 100;        // the current quota goal
    private int unpaidOvertime;     // player's current unpaid overtime

    // player stats (stuff that gets upgraded in the shop)
    int click_modifier = 1;
    double crit_chance;
    double crit_bonus;

    // object references
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
        curPoints += 1;
        quotaTMP.text = "Quota - " + curPoints + "/" + quota;
    }

    public void delQuota(int amount) // for spending points in the shop will probably change at some point
    {
        curPoints -= amount;
        quotaTMP.text = "Quota - " + curPoints + "/" + quota;
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
