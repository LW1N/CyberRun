using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public PlayerShoot playerShootScript;
    public int playerGold = 100;
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
        laserButton.onClick.AddListener(() => BuyUpgrade("Laser", 1000));
    }

    void UpdateGoldText()
    {
        goldText.text = "Gold: " + playerGold.ToString();
    }

    void BuyUpgrade(string upgradeType, int baseCost)
    {
        int cost = baseCost + GetAdditionalCost(upgradeType);

        if (playerGold >= cost)
        {
            playerGold -= cost;
            UpdateGoldText();
            playerShootScript.Upgrade(upgradeType);
            DebugUpgradeStatus(upgradeType); // Debugging the upgrade status after purchase
        }
        else
        {
            Debug.Log("Not enough gold for " + upgradeType + ".");
        }
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
