using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Text LvText;
    public int LvCount;
    public int PlayerLv;
    public int PlayerLvMax;
    public int backgame;
    private void Awake()
    {

    }
    private void Start()
    {
        //PlayerPrefs.SetInt("PlayerLvMax", 0);
        //PlayerPrefs.SetInt("backgame", 0);
        //PlayerPrefs.SetInt("gold", 200);
        backgame = PlayerPrefs.GetInt("backgame");
        PlayerLvMax = PlayerPrefs.GetInt("PlayerLvMax");
        //PlayerLv = PlayerPrefs.GetInt("PlayerLv");
        PlayerLv = PlayerLvMax;
        LvCount = PlayerLv;
        if(LvCount>=1)
        LvText.text = "Level" + "\n" + LvCount;
    }
    public void Playstart()
    {
        
        if(backgame==0)
        { 
        PlayerPrefs.SetFloat("volume", 0.7f);
        PlayerPrefs.SetFloat("UFOhpMax", 300);
        PlayerPrefs.SetFloat("UFOattackDamage", 20);
        PlayerPrefs.SetInt("PlayerLv", 0);
        //PlayerPrefs.SetInt("LvCount", 0);
        PlayerPrefs.SetInt("PlayerLvMax", 0);
        PlayerPrefs.SetInt("backgame", 1);
        PlayerPrefs.SetInt("gold", 100);
        }
        PlayerPrefs.SetInt("PlayerLv",PlayerLv);
        
        SceneManager.LoadScene("SampleScene");
    }
    public void PPLay()
    {
        SceneManager.LoadScene("遊戲");
    }
    public void right()
    {
        if (PlayerLvMax >= 1)
        {
            if (PlayerLv < PlayerLvMax)
            {
                LvCount++;
                PlayerLv++;
                LvText.text = "Level" + "\n" + LvCount;
            }
        }
    }
    public void Left()
    {
        if (LvCount > 1)
        {
            LvCount--;
            PlayerLv--;
            LvText.text = "Level" + "\n" + LvCount;
        }
    }
}
