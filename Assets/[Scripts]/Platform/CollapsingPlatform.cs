using System.Collections;
using UnityEngine;

public class CollapsingPlatform : MonoBehaviour
{
    public Sprite damagedPlatformSprite;
    public float fallingDelay;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            StartCoroutine(StartFalling());
    }

    IEnumerator StartFalling()
    {
        GetComponent<SpriteRenderer>().sprite = damagedPlatformSprite;

        yield return new WaitForSeconds(fallingDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
