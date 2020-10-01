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

    private void Awake()
    {
        barHp = bar.GetComponent<Image>();
        hp = 200;
        rig = GetComponent<Rigidbody2D>();
        maxHp = hp;

    }
    public void Hit(float damage, Transform direction)
    {
        hp -= damage;
        rig.AddForce(direction.right * 150 + direction.up * 80);
        barHp.fillAmount = hp / maxHp;
        GameObject points = Instantiate(hitPrint, transform.position, Quaternion.identity) as GameObject;
        points.transform.GetChild(0).GetComponent<TextMesh>().text = "" + damage;
        //aud.PlayOneShot(hitclip);
        //ani.SetTrigger("hit");

        if (hp <= 0) Dead();
    }
    private void Dead()
    {
        enabled = false;
        //ani.SetBool("die", true);

       // StartCoroutine(ShowFinal());
    }
}
