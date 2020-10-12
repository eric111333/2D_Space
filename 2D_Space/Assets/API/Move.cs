using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private Animator ani;
    public GameObject ball;
    private Rigidbody2D ballrig;
    private Vector3 newPoint;
    private Vector3 ballPoint;
    public Vector3 linerSpeed;
    private float radius;
    private float speed;
    private float omga;

    private void Awake()
    {
        ani = GetComponent<Animator>();
        ballrig = ball.GetComponent<Rigidbody2D>();

    }
    private void Start()
    {
        ballrig.velocity = linerSpeed;
        radius = (gameObject.transform.position - ball.transform.position).magnitude;
        speed = linerSpeed.magnitude*10;
        omga = speed * speed / radius;
    }
    public void OnMouseDown()
    {
        if (Time.timeScale == 0) return;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        
    }
    void rePoint()
    {
        newPoint = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }
    void reballPoint()
    {
        ballPoint = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z);
    }
    void AddF()
    {
        InvokeRepeating("rePoint", 0, 0.3f);
        Vector3 newPoint2 = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        ballrig.AddForce((newPoint2 - newPoint) * 1500f);
    }
    void AddFball()
    {
        InvokeRepeating("reballPoint", 0, 0.3f);
        Vector3 ballPoint2 = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z);
        ballrig.AddForce((ballPoint2 - ballPoint) * 1500f);
    }

    public void OnMouseDrag()
    {
        if (Time.timeScale == 0) return;
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
        ani.SetBool("move", true);
    }
    public void OnMouseExit()
    {
        ani.SetBool("move", false);
    }
    private void Update()
    {
        AddF();
        AddFball();
    }
    void FixedUpdate()
    {
        Vector3 fp = newPoint - ball.transform.position;//向心力矢量，但此时向量模不正确
        fp = fp.normalized * ballrig.mass * omga;//纠正向量的模
        ballrig.AddForce(fp*90000, ForceMode2D.Force);
    }
}
