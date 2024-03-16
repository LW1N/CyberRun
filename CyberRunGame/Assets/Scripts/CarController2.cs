using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController2 : MonoBehaviour
{
    public GameObject objectToMove;
    private float targetYPosition = -34.71f;
    private Vector3 targetPosition; // The target Y position to move the object to
    private float moveSpeed = 10f;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Access the money variable from the MoneyManager instance
        int moneyAmount = MoneyManager.instance.money;
        Debug.Log($"Current money amount: {moneyAmount}");

        // Check if the object to move is not null
        if (objectToMove != null && moneyAmount > 1000f)
        {
            // Set the target position
            targetPosition = new Vector3(objectToMove.transform.position.x, targetYPosition, objectToMove.transform.position.z);

            // Start moving the object towards the target position
            StartCoroutine(MoveObject(objectToMove.transform, targetPosition, moveSpeed));
        }
    }

    IEnumerator MoveObject(Transform objectTransform, Vector3 targetPosition, float moveSpeed)
    {
        float distance = Vector3.Distance(objectTransform.position, targetPosition);

        while (distance > 0.01f)
        {
            objectTransform.position = Vector3.MoveTowards(objectTransform.position, targetPosition, moveSpeed * Time.deltaTime);
            distance = Vector3.Distance(objectTransform.position, targetPosition);
            yield return null;
        }

        // Ensure the object reaches exactly the target position
        objectTransform.position = targetPosition;
    }
}
