using UnityEngine;

public class ShopItem : MonoBehaviour
{
    // upgrade shop information
    public string upgrade_name = "";    // upgrade display name for shop
    public string upgrade_desc = "";    // upgrade description for shop
    public int upgrade_cost = 0;        // how many points are needed to purchase

    // upgrade stat information 
    public string upgrade_type = "";
    private int upgrade_level = 0;      // will influence how much the corresponding stat will change

    // reference variables
    private PlayerInfo playerRef;

    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>();
    }


    private void OnMouseDown()
    {
        Debug.Log("Upgrade purchased: " + upgrade_name + " for $" + upgrade_cost);

        // increase upgrade attributes after purchase
        upgrade_level++;
        upgrade_cost++;
        
        
        // call function to update attribute in player stats
        playerRef.upgradeStat(upgrade_type, upgrade_level); 
    }
}