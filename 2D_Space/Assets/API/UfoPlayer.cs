using UnityEngine;
using UnityEngine.UI;

public class UfoPlayer : MonoBehaviour
{
    private float hp;
    private float maxHp;
    private Rigidbody2D rig;
    private Image barHp;
    public GameObject hitPrint;
    public GameObject bar;
    private bool hit;
    private float cdhit;
    public GameObject End;
    private int gold;
    public Text endText;
    private int playerLv;
    private int one;

    private void Awake()
    {
        gold = PlayerPrefs.GetInt("gold");
        barHp = bar.GetComponent<Image>();
        hp = PlayerPrefs.GetFloat("UFOhpMax");
        rig = GetComponent<Rigidbody2D>();
        maxHp = hp;
        playerLv = PlayerPrefs.GetInt("PlayerLv");
        one = 1;
    }
    public void Hit(float damage, Transform direction)
    {
        if (hit==true)
        {
            hit = false;
            hp -= damage;
            rig.AddForce(direction.right * 150 + direction.up * 80);
            barHp.fillAmount = hp / maxHp;
            GameObject points = Instantiate(hitPrint, transform.position, Quaternion.identity) as GameObject;
            points.transform.GetChild(0).GetComponent<TextMesh>().text = "" + damage;
            //aud.PlayOneShot(hitclip);
            //ani.SetTrigger("hit");
            
        }


        if (hp <= 0) Dead();
    }
    private void Dead()
    {
        
        End.SetActive(true);
        endText.text = ((10 + playerLv * 2)-GameManager.Metcount) + "\n" + "獲得$:" + ((10 + playerLv * 2) - GameManager.Metcount) * 20;
        
        if (one == 1)
        {
            gold += ((10 + playerLv * 2) - GameManager.Metcount) * 20;
            one--;
        }
        PlayerPrefs.SetInt("gold", gold);
        //ani.SetBool("die", true);

        // StartCoroutine(ShowFinal());
        enabled = false;
    }
    private void Update()
    {
        if (!hit)
        {
            cdhit += Time.deltaTime;
            if (cdhit > 0.6f)
            {
                hit = true;
                cdhit = 0;
            }
        }
    }
}
