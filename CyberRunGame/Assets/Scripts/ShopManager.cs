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
    // Audio 
    public AudioClip purchaseSoundClip;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        UpdateGoldText();
        moreBulletsButton.onClick.AddListener(() => BuyUpgrade("MoreBullets", 500));
        fasterBulletsButton.onClick.AddListener(() => BuyUpgrade("FasterBullets", 100));
        followingBulletsButton.onClick.AddListener(() => BuyUpgrade("FollowingBullets", 1000));
        strongerBulletsButton.onClick.AddListener(() => BuyUpgrade("StrongerBullets", 100));
        piercingBulletsButton.onClick.AddListener(() => BuyUpgrade("PiercingBullets", 150));
        laserButton.onClick.AddListener(() => BuyUpgrade("Laser", 1000));
    }

    void UpdateGoldText()
    {
        goldText.text = "Money: " + MoneyManager.instance.money.ToString();
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
            // Play the purchase sound clip
            if (purchaseSoundClip != null && audioSource != null)
            {
                audioSource.PlayOneShot(purchaseSoundClip);
            }
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
