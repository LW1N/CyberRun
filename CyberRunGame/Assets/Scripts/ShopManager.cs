using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public PlayerShoot playerShootScript;
    public Text goldText;
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
        goldText.text = "Gold: " + MoneyManager.instance.money.ToString();
    }

    void BuyUpgrade(string upgradeType, int baseCost)
    {
        int cost = baseCost + GetAdditionalCost(upgradeType);

        if (MoneyManager.instance.money >= cost)
        {
            MoneyManager.instance.AddMoney(-cost);
            UpdateGoldText();
            playerShootScript.Upgrade(upgradeType);
            DebugUpgradeStatus(upgradeType);
        }
        else
        {
            Debug.Log("Not enough gold for " + upgradeType + ".");
        }
    }

    void DebugUpgradeStatus(string upgradeType)
    {
        int moreBulletsLevel = playerShootScript.GetUpgradeLevel("MoreBullets");
        int fasterBulletsLevel = playerShootScript.GetUpgradeLevel("FasterBullets");
        int strongerBulletsLevel = playerShootScript.GetUpgradeLevel("StrongerBullets");
        int piercingBulletsLevel = playerShootScript.GetUpgradeLevel("PiercingBullets");

        string message = $"Upgrade purchased: {upgradeType}. Current stats:" +
                         $"\n- More Bullets Level: {moreBulletsLevel}" +
                         $"\n- Faster Bullets Level: {fasterBulletsLevel}" +
                         $"\n- Stronger Bullets Additional Damage: {strongerBulletsLevel * 5}" +
                         $"\n- Piercing Bullets Level (Objects it can pierce): {piercingBulletsLevel}";

        Debug.Log(message);
    }

    int GetAdditionalCost(string upgradeType)
    {
        int level = playerShootScript.GetUpgradeLevel(upgradeType);
        return (int)(level * 0.2 * 20);
    }

    public void RemoveAllUpgrades()
    {
        // Call the method to remove all upgrades from the PlayerShoot script
        playerShootScript.RemoveAllUpgrades();
    }
}
