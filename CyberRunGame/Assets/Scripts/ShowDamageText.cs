using UnityEngine;
using UnityEngine.UI;

public class ShowDamageText : MonoBehaviour
{
    public GameObject damageTextPrefab; // Assign your Text prefab in the Inspector

    public void ShowDamage(Vector3 position, int damageAmount)
    {
        // Instantiate the damage text prefab at the specified position
        GameObject textObj = Instantiate(damageTextPrefab, position, Quaternion.identity, FindObjectOfType<Canvas>().transform);
        textObj.transform.position = Camera.main.WorldToScreenPoint(position + new Vector3(0, 2, 0)); // Adjust the position as needed

        // Set the text to the damage amount
        Text damageText = textObj.GetComponent<Text>();
        if (damageText != null)
        {
            damageText.text = damageAmount.ToString();
        }
        
        // Optionally, destroy the text object after a few seconds
        Destroy(textObj, 2f); // Adjust time as necessary
    }
}
