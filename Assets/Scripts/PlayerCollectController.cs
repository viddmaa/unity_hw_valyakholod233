using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerCollectController : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private TextMeshProUGUI tm;

    void Start()
    {
        tm = GameObject.Find("TextScore").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        tm.SetText("Score: " + score.ToString());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coins"))
        {
            StartCoroutine(PlayUntilDestroy(collision.gameObject));
        }
        else if (collision.CompareTag("Checkpoint"))
        {
            Checkpoint checkpoint = collision.GetComponent<Checkpoint>();
            if (checkpoint != null && !checkpoint.IsActivated)
            {
                checkpoint.ActivateCheckpoint();
                StartCoroutine(PlayCheckpointSound(checkpoint));
            }
        }
    }

    IEnumerator PlayUntilDestroy(GameObject coins)
    {
        AudioSource sound = coins.GetComponent<AudioSource>();
        score++;
        sound.Play();
        yield return new WaitForSeconds(0.5f);
        Destroy(coins);
    }

    IEnumerator PlayCheckpointSound(Checkpoint checkpoint)
    {
        AudioSource sound = checkpoint.GetComponent<AudioSource>();
        if (sound != null)
        {
            sound.Play();
            yield return new WaitForSeconds(sound.clip.length);
        }
    }
}