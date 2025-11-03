using TMPro;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    // score / point tracker variables
    private int curPoints = 0;      // player's current score
    private int quota = 100;       // the current quota goal
    private int unpaidOvertime;     // player's current unpaid overtime

    // player stats (stuff that gets upgraded in the shop)
    private int click_modifier = 1;
    private float crit_chance = 0.01f;
    private float crit_bonus = 1.5f;
    public int critC_level = 0;
    public int mod_level = 0;
    public int critB_level = 0;

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

    /// <summary>
    /// addQuota: 
    /// </summary>
    public void addQuota()
    {
        curPoints += 1;
        quotaTMP.text = "Quota - " + curPoints + "/" + quota;
    }

    /// <summary>
    /// delQuota:
    /// </summary>
    /// <param name="amount"></param>
    public void delQuota(int amount) // for spending points in the shop will probably change at some point
    {
        curPoints -= amount;
        quotaTMP.text = "Quota - " + curPoints + "/" + quota;
    }
    
    /// <summary>
    /// addUnpaidOT: takes no arguments, increments unpaidOT by one 
    /// and updates TMP object accordingly 
    /// </summary>
    public void addUnpaidOT()
    {
        unpaidOvertime += 1;
        unpaidTMP.text = "Unpaid Overtime - " + unpaidOvertime;
    }

    /// <summary>
    /// removeUnpaidOT: takes int, removes int from unpaidOT as long as 
    /// unpaidOT is larger than the int. Updates TMP object accordingly
    /// </summary>
    /// <param name="cost"></param>
    public void removeUnpaidOT(int cost)
    {
        if (unpaidOvertime >= cost)
        {
            unpaidOvertime -= cost;
            unpaidTMP.text = "Unpaid Overtime - " + unpaidOvertime;
            Debug.Log("give player cosmetic");
        }
    }

    /// <summary>
    /// increaseScore: increases the users score while accounting 
    /// for crit chance. Updates TMP object accordingly
    /// </summary>
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

    /// <summary>
    /// resetScore: sets the players score to zero. 
    /// No TMP object update currently.
    /// </summary>
    public void resetScore()
    {
        curPoints = 0;
    }

    /// <summary>
    /// upgradeStat: takes in string and int, upgrades stat 
    /// specified as string by value specified by int. As of now.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="upgrade"></param>
    public void upgradeStat(string type, double upgrade)
    {
        // probably a switch case the check the upgade type and upgrade 
        // the corresponding stat based on the given upgrade value
        switch (type)
        {
            case "modifier":
                mod_level++;
                break;
            case "crit_bonus":
                critC_level++;
                break;
            case "crit_chance":
                critB_level++;
                break;
            default:
                // Code to execute if no case matches (optional)
                Debug.Log("Upgraded " + type + " stat to level " + upgrade);
                break;
        }
    }

    // getters and setters 

    public int getCurPoints()
    {
        return curPoints;
    }

    public void setCurPoints(int newVal)
    {
        curPoints = newVal;
    }

    public int getQuota()
    {
        return quota;
    }

    public void setQuota(int newVal)
    {
        quota = newVal; 
    }
}

