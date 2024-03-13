using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public PlayerShoot playerShootScript; // Assign in Inspector
    public int playerGold = 100; // Just for testing purposes, please replace :]
    public Text goldText; // Assign in Inspector
    public Button tripleShotButton; // Assign in Inspector

    void Start()
    {
        if (goldText == null)
        {
            Debug.LogError("ShopManager: Gold Text is not assigned!");
            return; // Prevent further execution if goldText is not assignedw
        }
        if (tripleShotButton == null)
        {
            Debug.LogError("ShopManager: Triple Shot Button is not assigned!");
            return; // Prevent further execution if tripleShotButton is not assigned
        }

        goldText.text = "Gold: " + playerGold.ToString();
        tripleShotButton.onClick.AddListener(BuyTripleShot);
    }

    void BuyTripleShot()
    {
        if (playerShootScript == null)
        {
            Debug.LogError("ShopManager: PlayerShoot script is not assigned!");
            return; // Prevent execution if playerShootScript is not assigned
        }

        int cost = 50;
        if (playerGold >= cost)
        {
            playerGold -= cost;
            goldText.text = "Gold: " + playerGold.ToString();
            playerShootScript.tripleShotEnabled = true;
            tripleShotButton.interactable = false; // Disable the button after purchase
        }
        else
        {
            Debug.Log("Not enough gold.");
        }
    }
}
