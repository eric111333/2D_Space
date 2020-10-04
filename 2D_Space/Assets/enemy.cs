using UnityEngine;

public class enemy : MonoBehaviour
{
    private Transform target;
    private float speed;
    private float distanceEn;
    private float timer;
    public float cd;
    public GameObject weapon_prefab;
    public float turret_rotation_speed = 3f;
    public float shot_speed;
    int barrel_index = 0;
    private void Awake()
    {
        speed = 15f;
        distanceEn = 3f;
        cd = 3f;
        target = GameObject.FindGameObjectWithTag("ufoplayer").GetComponent<Transform>();
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
            GameObject bullet = (GameObject)Instantiate(weapon_prefab, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().MovePosition(bullet.transform.up * shot_speed);
            //bullet.GetComponent<Projectile>().firing_ship = transform.parent.gameObject;
            //barrel_index++; //This will cycle sequentially through the barrels in the barrel_hardpoints array
            //bullet.transform.position = Vector3.MoveTowards(
            //       target.transform.position, target.position, Time.deltaTime * 0.001f);
            timer = 0;
            
        }
    }
    private void Update()
    {
        Attack();
        timer += Time.deltaTime;
    }

}
/*        Vector2 direction = transform.position -target.transform.position  ;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
*/
