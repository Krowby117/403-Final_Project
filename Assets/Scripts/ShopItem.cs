using System;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    // upgrade shop information
    public string upgrade_name = "";    // upgrade display name for shop
    public string upgrade_desc = "";    // upgrade description for shop
    public double upgrade_cost = 0;        // how many points are needed to purchase

    // upgrade stat information 
    public string upgrade_type = "";
    private double upgrade_level = 0;      // will influence how much the corresponding stat will change

    // reference variables
    private PlayerInfo playerRef;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemCost;
    public TextMeshProUGUI itemDesc;
    public TextMeshProUGUI funds;

    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>();

        switch (upgrade_type)
        {
            case "modifier":
                // pull the upgrade level from player info
                upgrade_level = playerRef.mod_level;
                upgrade_cost = math.floor(math.pow(2.71828, upgrade_level - 1));
                break;
            case "crit_bonus":
                // pull the upgrade level from player info
                upgrade_level = playerRef.critB_level;
                upgrade_cost = math.floor(math.pow(2.71828, upgrade_level - 1));
                break;
            case "crit_chance":
                // pull the upgrade level from player info
                upgrade_level = playerRef.critC_level;
                upgrade_cost = math.floor(math.pow(2.71828, upgrade_level - 1));
                break;
            case "cosmetic":
                // pull the upgrade level from player info
                upgrade_level = playerRef.critC_level;
                break;
            default: break;
        }

        funds.text = "Points : $" + playerRef.getCurPoints() + "\nOvertime : $" + playerRef.getCurOvertime();
    }


    private void OnMouseDown()
    {
        if (playerRef.getCurPoints() >= upgrade_cost)
        {
            playerRef.setCurPoints(playerRef.getCurPoints() - (int)upgrade_cost);
            Debug.Log("Upgrade purchased: " + upgrade_name + " for $" + upgrade_cost);

            // increase upgrade attributes after purchase
            upgrade_level++;
            upgrade_cost = math.floor(math.pow(2.71828, upgrade_level - 1));


            // call function to update attribute in player stats
            playerRef.upgradeStat(upgrade_type, upgrade_level);
            funds.text = "Points : $" + playerRef.getCurPoints() + "\nOvertime : $" + playerRef.getCurOvertime();
        }
        
        if ((playerRef.getCurOvertime() >= upgrade_cost) && (upgrade_type == "cosmetic") && (upgrade_level == 0))
        {
            playerRef.setCurOvertime(playerRef.getCurOvertime() - (int)upgrade_cost);
            Debug.Log("Cosmetic purchased: " + upgrade_name + " for $" + upgrade_cost);

            // increase upgrade attributes after purchase
            upgrade_level++;
            upgrade_cost = 1000000000;
            upgrade_desc = "Already purhcased! Limit: 1 per customer.";

            // call function to update attribute in player stats
            playerRef.upgradeStat(upgrade_type, upgrade_level);
            funds.text = "Points : $" + playerRef.getCurPoints() + "\nOvertime : $" + playerRef.getCurOvertime();
        }
    }

    void OnMouseOver()
    {
        itemName.text = upgrade_name;
        itemCost.text = "$ " + upgrade_cost;
        itemDesc.text = upgrade_desc;
    }
}