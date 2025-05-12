using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2f;
    public float moveDistance = 3f;

    private Vector3 startPos;
    private int direction = 1;

    private Animator animator;

    void Start()
    {
        startPos = transform.position;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
        if (Mathf.Abs(transform.position.x - startPos.x) > moveDistance)
        {
            direction *= -1;
            Flip();
        }

        if (animator != null)
            animator.SetBool("IsMoving", true);
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject); // Удалить пулю
            Destroy(gameObject); // Удалить врага
        }
    }
}

