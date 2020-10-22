using UnityEngine;
using UnityEngine.SceneManagement;

public class SetPause : MonoBehaviour
{
    private bool setpause;
    private bool setUiOpen;
    private bool nomusic;
    private bool setShopOpen;
    public GameObject setUI;
    public GameObject setstart;
    public GameObject music;
    public GameObject setting;
    public GameObject shop;
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
        setting.SetActive(setUiOpen);
        shop.SetActive(!setUiOpen);
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
    public void openShop()
    {
        setShopOpen = !setShopOpen;
        setUI.SetActive(setShopOpen);
        shop.SetActive(setShopOpen);
        setting.SetActive(!setShopOpen);
        if (setShopOpen == true)
        {
            if (Time.timeScale == 1)
            {
                PauseGame();
            }
        }
        if (setShopOpen == false)
        {
            if (Time.timeScale == 0)
            {
                ResumeGame();
            }
        }
    }
    public void Shop()
    {
        shop.SetActive(true);
        setting.SetActive(false);
    }
    public void Setting()
    {
        shop.SetActive(false);
        setting.SetActive(true);
    }    
    public void NoMusic()
    {
        nomusic = !nomusic;
        if (nomusic) music.GetComponent<AudioSource>().volume = 0;
        if (!nomusic) music.GetComponent<AudioSource>().volume = 80;

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
