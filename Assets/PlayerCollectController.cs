using UnityEngine;

public class PlayerCollectController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coins"))
        {
            Destroy(collision.gameObject);
        }
    }
}
