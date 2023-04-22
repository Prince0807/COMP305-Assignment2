using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FerrisWheel : MonoBehaviour
{
    public float rotationSpeed = 200f;
    public float delayBeforeRotation = 2f;
    
    private bool canRotate = true;
    public int targetAngle = 90;

    // Update is called once per frame
    void Update()
    {
        if (!canRotate)
            return;
        
        /* Check if Current Angle is multiplier of specified interval angle, call StopPlatformRotation to
         * halt the rotation for a while */
        if (Mathf.Floor(transform.rotation.eulerAngles.z) % targetAngle == 0)
            StartCoroutine(StopPlatformRotation());

        // Rotate the Ferris Wheel
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        
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
