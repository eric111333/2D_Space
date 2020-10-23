﻿using UnityEngine.UI;
using UnityEngine;

public class attackball : MonoBehaviour
{
    public float attack;
    private float speedx;
    private float speedy;
    private Rigidbody2D rig;
    private bool vib;
    private int vibre;
    public static int one;
    private void Awake()
    {
        vibre = PlayerPrefs.GetInt("vib");
        if (vibre == 1) vib = true;
        if (vibre == 0) vib = false;
        rig = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        attack = PlayerPrefs.GetFloat("UFOattackDamage");
        attack += speedx;
        attack += speedy;
        if (collision.tag == "met")
        {
            collision.GetComponent<Meteorite>().Hit(attack, transform);
            if(vib)
            Handheld.Vibrate();
        }
        if (collision.tag == "boss")
        {
            collision.GetComponent<BossAI>().Hit(attack, transform);
            if (vib)
                Handheld.Vibrate();
        }
        if (collision.tag == "enemy")
        {
            collision.GetComponent<enemy>().Hit(attack);
            if (vib)
                Handheld.Vibrate();
        }
    }
    private void Update()
    {
        speedx = Mathf.Abs(rig.velocity.x);
        speedy = Mathf.Abs(rig.velocity.y);
        if(one>=1)
        {
            vibre = PlayerPrefs.GetInt("vib");
            if (vibre == 1) vib = true;
            if (vibre == 0) vib = false;
            one--;
        }
    }
    
}
