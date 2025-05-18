using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class NewLevel3 : MonoBehaviour
{
    public TMP_Text LevelText;
    public float showTime = 2f;

    private void Start()
    {
        
        if (SceneManager.GetActiveScene().name == "Finish" && PlayerPrefs.GetString("LastScene") == "Level2")
        {
            StartCoroutine(ShowLevelName());
        }
        else
        {
            LevelText.gameObject.SetActive(false);
        }
    }

    IEnumerator ShowLevelName()
    {
        LevelText.gameObject.SetActive(true);
        yield return new WaitForSeconds(showTime);
        LevelText.gameObject.SetActive(false);
    }
}
