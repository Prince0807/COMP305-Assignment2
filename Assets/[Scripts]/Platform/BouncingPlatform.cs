using UnityEngine;

public class BouncingPlatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.GetComponent<PlayerBehaviour>().verticalForce *= 1.4f;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.GetComponent<PlayerBehaviour>().verticalForce /= 1.4f;
    }
}
