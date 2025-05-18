using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetString("LastScene", "Level1");
            SceneManager.LoadScene("Level2"); 
        }
    }
}
