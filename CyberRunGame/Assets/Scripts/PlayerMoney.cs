using UnityEngine;
using UnityEngine.UI; // Include UI namespace

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;
    public int money; 
    public Text moneyText; 

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddMoney(int amount)
    {
        money += amount;
        Debug.Log($"Money updated: ${money}");
        if (moneyText != null)
        {
            moneyText.text = $"Money:\n ${money}";
        } 
            
    }
}
