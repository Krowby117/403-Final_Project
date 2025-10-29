using UnityEngine;

public class ShopItem : MonoBehaviour
{
    // upgrade shop information
    public string upgrade_name = "";    // upgrade display name for shop
    public string upgrade_desc = "";    // upgrade description for shop
    public int upgrade_cost = 0;        // how many points are needed to purchase

    // upgrade stat information 
    private string upgrade_type = "";   // what stat is being upgraded
    private int upgrade_level = 0;      // will influence how much the corresponding stat will change


    private GameObject player_stats;


    private void OnMouseDown()
    {
        Debug.Log("Upgrade purchased: " + upgrade_name + " for $" + upgrade_cost);
        // call function to update attribute in player stats

        // increase upgrade attributes after purchase
        upgrade_level++;
        upgrade_cost++;
    }
}