using UnityEngine.UI;
using UnityEngine;

public class attackball : MonoBehaviour
{
    public float attack;
    private float speedx;
    private float speedy;
    private Rigidbody2D rig;
    private void Awake()
    {
        
        rig = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        attack = 20;
        attack += speedx;
        attack += speedy;
        if (collision.tag == "met")
        {
            collision.GetComponent<Meteorite>().Hit(attack, transform);
        }
    }
    private void Update()
    {
        speedx = Mathf.Abs(rig.velocity.x);
        speedy = Mathf.Abs(rig.velocity.y);
    }
}
