using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class NewLevel : MonoBehaviour
{
    public TMP_Text LevelText;
    public float showTime = 2f;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level2")
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
