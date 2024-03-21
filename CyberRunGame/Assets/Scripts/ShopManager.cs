using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public PlayerShoot playerShootScript;
    // Removed the local playerGold initialization
    public Text goldText;

    // Define buttons for each upgrade in the inspector
    public Button moreBulletsButton;
    public Button fasterBulletsButton;
    public Button followingBulletsButton;
    public Button strongerBulletsButton;
    public Button piercingBulletsButton;
    public Button laserButton;

    void Start()
    {
        UpdateGoldText();
        moreBulletsButton.onClick.AddListener(() => BuyUpgrade("MoreBullets", 50));
        fasterBulletsButton.onClick.AddListener(() => BuyUpgrade("FasterBullets", 30));
        followingBulletsButton.onClick.AddListener(() => BuyUpgrade("FollowingBullets", 300));
        strongerBulletsButton.onClick.AddListener(() => BuyUpgrade("StrongerBullets", 50));
        piercingBulletsButton.onClick.AddListener(() => BuyUpgrade("PiercingBullets", 60));
    }

    void UpdateGoldText()
    {
        // Access the player's gold from the MoneyManager singleton instance
        goldText.text = "Gold: " + MoneyManager.instance.money.ToString();
    }

    void BuyUpgrade(string upgradeType, int baseCost)
    {
        int cost = baseCost + GetAdditionalCost(upgradeType);

        // Access the player's gold from the MoneyManager singleton instance
        if (MoneyManager.instance.money >= cost)
        {
            // Adjust player gold through the MoneyManager
            MoneyManager.instance.AddMoney(-cost); // Assuming AddMoney can handle negative values for deduction
            UpdateGoldText();
            playerShootScript.Upgrade(upgradeType);
            DebugUpgradeStatus(upgradeType); // Debugging the upgrade status after purchase
        }
        else
        {
            Debug.Log("Not enough gold for " + upgradeType + ".");
        }
    }
    void DebugUpgradeStatus(string upgradeType, int cost)
    {
        // Fetching current levels of upgrades to provide detailed feedback
        int moreBulletsLevel = playerShootScript.GetUpgradeLevel("MoreBullets");
        int fasterBulletsLevel = playerShootScript.GetUpgradeLevel("FasterBullets");
        int strongerBulletsLevel = playerShootScript.GetUpgradeLevel("StrongerBullets");
        int piercingBulletsLevel = playerShootScript.GetUpgradeLevel("PiercingBullets");

        // Constructing the message
        string message = $"Purchased {upgradeType} upgrade for {cost} gold. Current stats:" +
                         $"\n- More Bullets Level: {moreBulletsLevel}" +
                         $"\n- Faster Bullets Level: {fasterBulletsLevel}" +
                         $"\n- Stronger Bullets Additional Damage: {strongerBulletsLevel * 5}" +
                         $"\n- Piercing Bullets Level (Objects it can pierce): {piercingBulletsLevel}";

        Debug.Log(message);
    }
    int GetAdditionalCost(string upgradeType)
    {
        int level = playerShootScript.GetUpgradeLevel(upgradeType);
        // Example calculation: each level increases cost by 20% of the base cost
        return (int)(level * 0.2 * 20);
    }

    // New method to log current upgrade status
    void DebugUpgradeStatus(string upgradeType)
    {
        // Fetching current levels of upgrades to provide detailed feedback
        int moreBulletsLevel = playerShootScript.GetUpgradeLevel("MoreBullets");
        int fasterBulletsLevel = playerShootScript.GetUpgradeLevel("FasterBullets");
        int strongerBulletsLevel = playerShootScript.GetUpgradeLevel("StrongerBullets");
        int piercingBulletsLevel = playerShootScript.GetUpgradeLevel("PiercingBullets");

        // Constructing the message
        string message = $"Upgrade purchased: {upgradeType}. Current stats:" +
                         $"\n- More Bullets Level: {moreBulletsLevel}" +
                         $"\n- Faster Bullets Level: {fasterBulletsLevel}" +
                         $"\n- Stronger Bullets Additional Damage: {strongerBulletsLevel * 5}" +
                         $"\n- Piercing Bullets Level (Objects it can pierce): {piercingBulletsLevel}";

        Debug.Log(message);
    }
}
