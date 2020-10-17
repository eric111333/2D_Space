using UnityEngine;
using UnityEngine.SceneManagement;

public class SetPause : MonoBehaviour
{
    private bool setpause;
    private bool setUiOpen;
    public GameObject setUI;
    public GameObject setstart;
    private void Awake()
    {
        setpause = false;
    }
    public void Menu()
    {
        SceneManager.LoadScene("選單");
    }
    public void Pause()
    {
        setpause = !setpause;
        setstart.SetActive(setpause);
        if (setpause == true)
        {
            if (Time.timeScale == 1)
            {
                PauseGame();
            }
        }
        if (setpause == false)
        {
            if (Time.timeScale == 0)
            {
                ResumeGame();
            }
        }
    }
    public void openUI()
    {
        setUiOpen = !setUiOpen;
        setUI.SetActive(setUiOpen);
        if (setUiOpen == true)
        {
            if (Time.timeScale == 1)
            {
                PauseGame();
            }
        }
        if (setUiOpen == false)
        {
            if (Time.timeScale == 0)
            {
                ResumeGame();
            }
        }
    }
    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
