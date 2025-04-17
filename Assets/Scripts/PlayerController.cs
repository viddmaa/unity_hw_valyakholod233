using UnityEngine;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    public float jumpForce = 7f;
    public Rigidbody2D rb;

    private SpriteRenderer sr;
    private PlayerAnimation pa;
    public bool isGround;

    public AudioClip jumpSound;
    public AudioClip walkSound;

    private AudioSource jumpSource;
    private AudioSource walkSource;

    [SerializeField] private AudioMixerGroup sfxMixerGroup;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        pa = GetComponentInChildren<PlayerAnimation>();

        jumpSource = gameObject.AddComponent<AudioSource>();
        jumpSource.playOnAwake = false;
        jumpSource.outputAudioMixerGroup = sfxMixerGroup;
        walkSource = gameObject.AddComponent<AudioSource>();
        walkSource.loop = true;
        walkSource.playOnAwake = false;
        walkSource.outputAudioMixerGroup = sfxMixerGroup;
        walkSource.clip = walkSound;
    }

    void Update()
    {
        float movement = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(movement * speed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
            isGround = false;

            if (jumpSound != null)
                jumpSource.PlayOneShot(jumpSound);
        }

        sr.flipX = movement < 0;
        pa.IsMoving = movement != 0;
        pa.IsJumping = !isGround;

        if (movement != 0 && isGround)
        {
            if (!walkSource.isPlaying && walkSound != null)
                walkSource.Play();
        }
        else
        {
            if (walkSource.isPlaying)
                walkSource.Stop();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGround = false;
    }
}
