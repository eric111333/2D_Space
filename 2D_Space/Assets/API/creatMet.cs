using UnityEngine;

public class creatMet : MonoBehaviour
{
    public GameObject Met;
    public GameObject BigMet;
    public GameObject Enemy;
    public GameObject Boss;
    public int playerLv;
    private void Awake()
    {
        playerLv = PlayerPrefs.GetInt("PlayerLv");

    }
    private void CreatMeteorite()
    {
        float x = Random.Range(-50, 50);
        float y = Random.Range(-50, 50);
        Vector3 pos = new Vector3(x, y, 0);
        Instantiate(Met, pos, Quaternion.identity);
    }
    private void CreatBigMet()
    {
        float x = Random.Range(-50, 50);
        float y = Random.Range(-50, 50);
        Vector3 pos = new Vector3(x, y, 0);
        Instantiate(BigMet, pos, Quaternion.identity);
    }
    private void CreatEnemy()
    {
        float x = Random.Range(-50, 50);
        float y = Random.Range(-50, 50);
        Vector3 pos = new Vector3(x, y, 0);
        Instantiate(Enemy, pos, Quaternion.identity);
    }
    private void CreatBoss()
    {
        float x = Random.Range(-50, 50);
        float y = Random.Range(-50, 50);
        Vector3 pos = new Vector3(x, y, 0);
        Instantiate(Boss, pos, Quaternion.identity);
    }
    private void Start()
    {
        float r = Random.Range(1, 5);
        float s = Random.Range(1, 5);
        InvokeRepeating("CreatMeteorite", r, s);
        InvokeRepeating("CreatBigMet", r+5, s+5);
        if(playerLv==5 | playerLv == 15 || playerLv == 25 || playerLv == 10 || playerLv == 20 || playerLv == 30)
        {
            Invoke("CreatBoss",10);
        }
        if(playerLv>=11)
        {
            InvokeRepeating("CreatEnemy", r+10, s+10);
        }
    }
}
