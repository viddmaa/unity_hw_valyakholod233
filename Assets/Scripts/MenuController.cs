using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuController : MonoBehaviour
{

    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider soundVolumeSlider;
    [SerializeField] private AudioMixer musicMixer;
    [SerializeField] private AudioMixer soundMixer;


    private bool isPaused = false;

    void Start()
    {
        if (pausePanel != null)
            pausePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
                PauseGame();
            else
                ResumeGame();
        }
    }


    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        if (pausePanel != null)
            pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        if (pausePanel != null)
            pausePanel.SetActive(false);
    }


    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }


    public void OnMusicVolumeChange(float value)
    {
        Debug.Log("Music volume changed to: " + value);
        musicMixer.SetFloat("MusicVolume", Mathf.Lerp(-80f, 0f, value));
    }

    public void OnSoundVolumeChange(float value)
    {
        Debug.Log("Sound volume changed to: " + value);
        soundMixer.SetFloat("SFXVolume", Mathf.Lerp(-80f, 0f, value));
    }
}



