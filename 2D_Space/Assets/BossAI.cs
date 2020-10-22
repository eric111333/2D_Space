using UnityEngine.UI;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    private float speed;
    private float attack;
    private float hp;
    private float hpmax;
    private Transform target;
    private Rigidbody2D rig;
    public GameObject hitPrint;
    public GameObject bar;
    private Image barHp;
    public int playerLv;
    private int dieone;
    private bool hit;
    private float cdhit;
    private void Awake()
    {
        playerLv = PlayerPrefs.GetInt("PlayerLv");
        speed = 20f;
        attack = 20 + playerLv * 5;
        hp = 500 + playerLv * 50;
        target = GameObject.FindGameObjectWithTag("ufoplayer").GetComponent<Transform>();
        rig = GetComponent<Rigidbody2D>();
        hpmax = hp;
        barHp = bar.GetComponent<Image>();
        dieone = 1;

    }
    public void Hit(float damage, Transform direction)
    {
        if (hit==true)
        {
            hit = false;
            hp -= damage;
            rig.AddForce(direction.right * 180 + direction.up * 80);
            GameObject points = Instantiate(hitPrint, transform.position, Quaternion.identity) as GameObject;
            points.transform.GetChild(0).GetComponent<TextMesh>().text = "" + Mathf.Round(damage);
            //ani.SetTrigger("hit");
            barHp.fillAmount = hp / hpmax;
            

        }
        if (hp <= 0 && dieone == 1) Dead();
    }
    void Dead()
    {
        //ani.SetTrigger("die");
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
    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
    private void Update()
    {
        if (!hit)
        {
            cdhit += Time.deltaTime;
            if (cdhit > 0.4f)
            {
                hit = true;
                cdhit = 0;
            }
        }
    }
}
