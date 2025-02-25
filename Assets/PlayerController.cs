using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    public float jumpForce = 7f;
    public Rigidbody2D rb;
    private SpriteRenderer sr;
    private PlayerAnimation pa;
    public bool isGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        pa = GetComponentInChildren<PlayerAnimation>();
    }

    void Update()
    {
        float movement = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(movement * speed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
            isGround = false;
        }

       
        if (transform.position.y < -30)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        sr.flipX = movement < 0;
        pa.IsMoving = movement != 0;
        pa.IsJumping = !isGround;
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}