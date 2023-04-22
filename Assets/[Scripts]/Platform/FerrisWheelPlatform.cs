using UnityEngine;

[RequireComponent(typeof(Platform))]
public class FerrisWheelPlatform : MonoBehaviour
{
    public Transform rotatingObject;

    // Update is called once per frame
    void Update()
    {
        // Follow rotatingObject's position, which is a child of a rotating Ferris Wheel.
        transform.position = rotatingObject.position;
    }
}
