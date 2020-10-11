﻿using UnityEngine;

public class enemy : MonoBehaviour
{
    private Transform target;
    private float speed;
    private float distanceEn;
    private float timer;
    private float cd;
    public GameObject weapon_prefab;
    private Transform att;
    public float turret_rotation_speed = 3f;
    public float shot_speed;
    //int barrel_index = 0;
    private void Awake()
    {
        speed = 15f;
        distanceEn = 3f;
        cd = 2f;
        target = GameObject.FindGameObjectWithTag("ufoplayer").GetComponent<Transform>();
        //att = GameObject.FindGameObjectWithTag("enatt").GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        float angle = Vector3.SignedAngle(transform.up, target.position - transform.position, Vector3.forward);
        transform.Rotate(new Vector3(0, 0, Mathf.Sign(angle) * speed*10 * Time.deltaTime));

        if (Vector2.Distance(transform.position,target.position)>distanceEn)
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
    private void Attack()
    {
        if (timer >= cd)
        {
            timer = 0;
            //Vector3 Pos = new Vector3(att.position.x, att.position.y, att.position.z);
            GameObject bullet = (GameObject)Instantiate(weapon_prefab, transform.GetChild(0).position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * shot_speed);
            bullet.GetComponent<Projectile>().firing_ship = transform.parent.gameObject;
            //barrel_index++; //This will cycle sequentially through the barrels in the barrel_hardpoints array
            //if (barrel_index >= barrel_hardpoints.Length)
            //    barrel_index = 0;
            //bullet.transform.position = Vector3.MoveTowards(
            //       target.transform.position, target.position, Time.deltaTime * 0.001f);
            
            
        }
    }
    private void Update()
    {
        Attack();
        timer += Time.deltaTime;
        //Vector2 turretPosition = target.transform.position;
        //Vector3 direction = CustomPointer.pointerPosition - turretPosition;
        //transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.LerpAngle(transform.rotation.eulerAngles.z, (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) - 90f, turret_rotation_speed * Time.deltaTime)));
    }

}
/*        Vector2 direction = transform.position -target.transform.position  ;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
*/
