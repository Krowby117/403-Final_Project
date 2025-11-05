//using System;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInfo : MonoBehaviour
{
    // score / point tracker variables
    private int curPoints = 0;      // player's current score
    private int quota = 0;       // the current quota goal
    private int unpaidOvertime = 0;     // player's current unpaid overtime
    private int day = 0;

    // player stats (stuff that gets upgraded in the shop)
    private int click_modifier = 1;
    private float crit_chance = 0.01f;
    private float crit_bonus = 1.5f;
    public int critC_level = 0;
    public int cosmetic = 0;
    public int mod_level = 0;
    public int critB_level = 0;

    // object references
    private TextMeshProUGUI quotaTMP;
    private TextMeshProUGUI unpaidTMP;
    private TextMeshProUGUI dayTMP;

    //move the player info object into a folder that will not be destroyed on scene transitions and initialize the SceneLoaded function
    private void Awake()
    {
        
        DontDestroyOnLoad(this);
        SceneManager.sceneLoaded += SceneLoaded;
    }

    // This activates whenever a new Scene is loaded that PlayerInfo exists in. I use it to update the upgrade modifiers and to find TMP objects
    void SceneLoaded(Scene newScene, LoadSceneMode loadMode)
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        // if loading the main game scene, do these actions
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            dayTMP = GameObject.Find("DayText").GetComponent<TextMeshProUGUI>();
            quotaTMP = GameObject.Find("QuotaText").GetComponent<TextMeshProUGUI>();
            unpaidTMP = GameObject.Find("UnpaidText").GetComponent<TextMeshProUGUI>();

            click_modifier = 1 + mod_level;
            crit_chance = .01f + (critC_level * .01f);
            crit_bonus = 1.5f + (critB_level * .1f);
            unpaidTMP.text = "Unpaid Overtime: " + unpaidOvertime;
        }
        // You can add else ifs if you want to reference different TMP objects from the store
        // else if (SceneManager.GetActiveScene().name == "ShopScene")
        else
        {
            dayTMP = null;
            quotaTMP = null;
            unpaidTMP = null;
        }
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
        if (curPoints < quota){
            if (UnityEngine.Random.value < crit_chance) // if a random number is less than the crit chance
            {
                Debug.Log("Crit");      // CRIT!!!
                curPoints += (int)Mathf.Round(1 * click_modifier * crit_bonus); // add the click modifyer + 
            }                                                         // amount to change with balancing
            else
            {
                curPoints += (int)(1f * click_modifier);
            }
            quotaTMP.text = "Quota: " + curPoints + " / " + quota;
            Debug.Log("Player score increased by: " + curPoints);
        }
        else
        {
            unpaidOvertime += 1;
            unpaidTMP.text = "Unpaid Overtime: " + unpaidOvertime;
        }
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
                Debug.Log("Upgraded Multiplier");
                break;
            case "crit_bonus":
                critB_level++;
                Debug.Log("Upgraded Crit Bonus");
                break;
            case "crit_chance":
                critC_level++;
                Debug.Log("Upgraded Crit Chance");
                break;
            case "cosmetic":
                cosmetic++;
                Debug.Log("Purchsaed Cosmetic");
                break;
            default:
                // Code to execute if no case matches (optional)
                Debug.Log("Upgraded " + type + " stat to level " + upgrade);
                break;
        }
    }
    // Transitions to mainScene whenever Called
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
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

    public int getCurOvertime()
    {
        return unpaidOvertime;
    }

    public void setCurOvertime(int newVal)
    {
        unpaidOvertime = newVal;
    }

    public int getQuota()
    {
        return quota;
    }

    public int getDay() 
    { 
        return day; 
    }

    public void addDay()
    {
        day++;
        dayTMP.text = "Day: " + day;
        quota = (int)(100 * Math.Pow(Math.E, day-1));
        quotaTMP.text = "Quota: " + curPoints + " / " + quota;
    }

    
}

