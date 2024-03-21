using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public int sceneBuildIndex;
    public int goal;
    public GameObject uiObject;

    void Start()
    {
        uiObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            int moneyAmount = MoneyManager.instance.money;
            Debug.Log($"Current money amount: {moneyAmount}");
            // Check if the object to move is not null
            if (moneyAmount >= goal)
            {
                SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
            }
            else
            {
                uiObject.SetActive(true);
                StartCoroutine("WaitForSec");
            }
        }
    }
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        Destroy(uiObject);
        Destroy(gameObject);
    }
}
