using UnityEngine;
using UnityEngine.UI;

public class Meteorite : MonoBehaviour
{
    private float speedx;
    private float speedy;
    private float hp;
    private float hpmax;
    private float attack ;
    private int dieone;
    private Image barHp;
    private Rigidbody2D rig;
    public GameObject hitPrint;
    public GameObject bar;
    private Animator ani;
    public int playerLv;
    //private float angle;
    private void Awake()
    {
        playerLv = PlayerPrefs.GetInt("PlayerLv");
        speedx = Random.Range(-20, 20);
        speedy = Random.Range(-20, 20);
        rig = GetComponent<Rigidbody2D>();
        hp = Random.Range(10, 50)+playerLv*10;
        attack = 10+playerLv;
        ani = GetComponent<Animator>();
        hpmax = hp;
        barHp =bar.GetComponent<Image>();
        dieone = 1;
    }
    private void Start()
    {
        rig.velocity = new Vector2(speedx, speedy);
    }
    public void Hit(float damage, Transform direction)
    {
        hp -= damage;
        rig.AddForce(direction.right * 180 + direction.up * 80);
        GameObject points = Instantiate(hitPrint, transform.position, Quaternion.identity) as GameObject;
        points.transform.GetChild(0).GetComponent<TextMesh>().text = "" + Mathf.Round(damage);
        //ani.SetTrigger("hit");
        barHp.fillAmount = hp / hpmax;
        if (hp <= 0 && dieone==1) Dead();
    }
    void Dead()
    {
        ani.SetTrigger("die");
        Destroy(gameObject, 0.8f);
        GameManager.Metcount--;
        dieone--;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ufoplayer")
        {
            collision.GetComponent<UfoPlayer>().Hit(attack, transform);
        }
    }

}
