using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text Mettext;
    public static float Metcount;
    private int playerLv;
    private int playerLvMax;
    private void Awake()
    {
        Metcount = 1;
        playerLv=PlayerPrefs.GetInt("PlayerLv");
        playerLvMax = PlayerPrefs.GetInt("PlayerLvMax");
    }
    private void Update()
    {
        Mettext.text = "破壞數: "+Metcount;
        LVmax();
    }
    void LVmax()
    {
        if(Metcount==0)
        {
            if (playerLv == playerLvMax)
            { 
                playerLvMax++;
                //playerLv++;
                PlayerPrefs.SetInt("PlayerLvMax", playerLvMax);
                PlayerPrefs.SetInt("PlayerLv", playerLv);
            }
                
        }
    }
}
