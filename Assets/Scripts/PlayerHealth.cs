using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 3;
    private int currentHP;

    public Image[] heartImages; 
    private PlayerCheckPoint checkpointSystem;

    void Start()
    {
        currentHP = maxHP;
        checkpointSystem = GetComponent<PlayerCheckPoint>();
        UpdateHearts();
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
        currentHP -= amount;

        if (currentHP <= 0)
        {
            currentHP = 0;
            Respawn();
        }

        UpdateHearts();
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
        if (collision.CompareTag("Trap") || collision.CompareTag("Enemy"))
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
