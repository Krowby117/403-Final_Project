using TMPro;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    // score / point tracker variables
    private int curPoints = 0;      // player's current score
    private int quota = 100;        // the current quota goal
    private int unpaidOvertime;     // player's current unpaid overtime

    // player stats (stuff that gets upgraded in the shop)
    private int click_modifier = 1;
    private float crit_chance = 0.01f;
    private float crit_bonus = 1.5f;

    // object references
    public TextMeshProUGUI quotaTMP;
    public TextMeshProUGUI unpaidTMP;
    public TextMeshProUGUI scoreTMP;

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

    // increases the players curScore and updates tmp
    public void increaseScore()
    {
        if (Random.Range(0, 1) < crit_chance) // if a random number is less than the crit chance
        {
            Debug.Log("Crit");      // CRIT!!!
            curPoints += (int)Mathf.Round(1 * click_modifier * crit_bonus); // add the click modifyer + 
        }                                                         // amount to change with balancing
        else
        {
            curPoints += (int)(1f * click_modifier);
        }

        scoreTMP.text = "Score: " + curPoints;
        Debug.Log("Player score increased by: " + curPoints);
    }

    // resets player score 
    public void resetScore()
    {
        curPoints = 0;
    }
}
