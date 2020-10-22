using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text Mettext;
    public Text endText;
    public static int Metcount;
    private int playerLv;
    private int playerLvMax;
    public GameObject End;
    private int gold;
    private int one;
    private void Awake()
    {
        //gold = 1;
        gold = PlayerPrefs.GetInt("gold");
        playerLv = PlayerPrefs.GetInt("PlayerLv");

        playerLvMax = PlayerPrefs.GetInt("PlayerLvMax");
        one = 1;
        Metcount = 10 + playerLv * 2;
    }
    private void Update()
    {
        Mettext.text = "破壞數: " + Metcount;
        LVmax();
    }
    void LVmax()
    {
        if (Metcount == 0)
        {
            if (playerLv == playerLvMax)
            {
                playerLvMax++;
                //playerLv++;
                PlayerPrefs.SetInt("PlayerLvMax", playerLvMax);
                PlayerPrefs.SetInt("PlayerLv", playerLv);
            }
            End.SetActive(true);
            endText.text = (10 + playerLv * 2) + "\n" + "獲得$:" + (10 + playerLv * 2) * 20;
            if (one == 1)
            {
                gold += (10 + playerLv * 2) * 20;
                one--;
            }
            PlayerPrefs.SetInt("gold", gold);
        }
    }
}
