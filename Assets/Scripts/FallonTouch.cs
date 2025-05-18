using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FallingBlock : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool hasFallen = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic; // изначально блок не двигается
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasFallen && collision.collider.CompareTag("Player"))
        {
            rb.bodyType = RigidbodyType2D.Dynamic; // блок становится динамическим и падает
            hasFallen = true;
        }
    }
}