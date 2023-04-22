using System.Collections;
using UnityEngine;

public class FlipToHazardPlatform : MonoBehaviour
{
    public float delayBeforeRotation = 2f;
    public float rotationSpeed = 2f;

    private bool canRotate = true;
    private int targetAngle = 180;

    private void Update()
    {
        if (!canRotate)
            return;
        
        // If Platform has rotated 180 Degrees, call the StopPlatformRotation coroutine to halt it for a moment...
        if (Mathf.Floor(transform.rotation.eulerAngles.z) % targetAngle == 0)
            StartCoroutine(StopPlatformRotation());

        // Rotate The Platform
        transform.Rotate(0,0,rotationSpeed * Time.deltaTime);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If player triggers in Spikes area, they die.
        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.GetComponent<PlayerBehaviour>().health.TakeDamage(1000);
    }

    IEnumerator StopPlatformRotation()
    {
        // Stops Rotation
        canRotate = false;
        // Wait for specified seconds
        yield return new WaitForSeconds(delayBeforeRotation);   
        // Starts Rotation
        canRotate = true;
    }
}
