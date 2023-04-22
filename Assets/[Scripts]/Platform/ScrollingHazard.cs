using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingHazard : MonoBehaviour
{
    public float rotationSpeed;
    
    public float movementSpeed;
    public Transform startPoint;
    public Transform endPoint;

    private Vector2 targetPosition;

    private void Start()
    {
        targetPosition = endPoint.position;
    }

    private void Update()
    {
        // Rotate the Blade to make it look nice...
        transform.Rotate(0,0,rotationSpeed * Time.deltaTime);
        // Move towards Target Position over time...
        transform.position = Vector2.Lerp(transform.position, targetPosition, movementSpeed * Time.deltaTime);

        // Switch the Target Position if reached at current Target
        if(Vector2.Distance(transform.position, targetPosition) <= 0.1f)
            targetPosition = (targetPosition == (Vector2)endPoint.position)? startPoint.position : endPoint.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If blade collides with Player, kill the player...
        if(collision.gameObject.CompareTag("Player"))
            collision.gameObject.GetComponent<PlayerBehaviour>().health.TakeDamage(1000);
    }
}
