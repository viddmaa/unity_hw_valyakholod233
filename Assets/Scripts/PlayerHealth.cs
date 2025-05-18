using UnityEngine;
using UnityEngine.UI;
using System.Collections; 

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 3;
    private int currentHP;

    public Image[] heartImages;
    private PlayerCheckPoint checkpointSystem;
    private SpriteRenderer sr;
    private Color originalColor;

    private bool canTakeDamage = true;
    public float damageCooldown = 1f;

    void Start()
    {
        currentHP = maxHP;
        checkpointSystem = GetComponent<PlayerCheckPoint>();
        UpdateHearts();

        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    void UpdateHearts()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            heartImages[i].enabled = i < currentHP;
        }
    }

    public void TakeDamage(int amount)
    {
        if (!canTakeDamage) return;

        currentHP -= amount;
        if (currentHP < 0) currentHP = 0;

        UpdateHearts();

        if (currentHP <= 0)
        {
            Respawn();
        }

        StartCoroutine(DamageCooldown());
    }

    IEnumerator DamageCooldown()
    {
        canTakeDamage = false;

        for (int i = 0; i < 3; i++)
        {
            sr.color = Color.red;
            yield return new WaitForSeconds(0.15f);
            sr.color = originalColor;
            yield return new WaitForSeconds(0.15f);
        }

        canTakeDamage = true;
    }

    public void ResetHP()
    {
        currentHP = maxHP;
        UpdateHearts();
    }

    public void Respawn()
    {
        transform.position = checkpointSystem.GetCurrentCheckpointPosition();
        ResetHP();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("Trap") || collision.CompareTag("Enemy")) && canTakeDamage)
        {
            TakeDamage(1);
        }

        if (collision.CompareTag("DeadZone"))
        {
            currentHP = 0;
            Respawn();
        }
    }
}
