using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public PlayerShoot playerShootScript;
     // Just for testing purposes, please replace :]
    public int playerGold = 100;
    public Text goldText;
    public Button tripleShotButton;

    void Start()
    {
        goldText.text = "Gold: " + playerGold.ToString();
        tripleShotButton.onClick.AddListener(BuyTripleShot);
    }

    void BuyTripleShot()
    {
        int cost = 50;
        if (playerGold >= cost)
        {
            playerGold -= cost;
            goldText.text = "Gold: " + playerGold.ToString();
            playerShootScript.tripleShotEnabled = true;
            // Disable the button after purchase
            tripleShotButton.interactable = false; 
        }
        else
        {
            Debug.Log("Not enough gold.");
        }
    }
}
