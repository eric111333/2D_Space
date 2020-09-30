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

    private void Awake()
    {
        ani = GetComponent<Animator>();
        ballrig = ball.GetComponent<Rigidbody2D>();
    }
    void OnMouseDown()
    {
        if (Time.timeScale == 0) return;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        
    }
    void rePoint()
    {
        newPoint = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }
    void AddF()
    {
        InvokeRepeating("rePoint", 0, 0.3f);
        Vector3 newPoint2 = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        ballrig.AddForce((newPoint2 - newPoint) * 1000f);
    }

    void OnMouseDrag()
    {
        if (Time.timeScale == 0) return;
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
        ani.SetBool("move", true);
    }
    private void OnMouseExit()
    {
        ani.SetBool("move", false);
    }
    private void Update()
    {
        AddF();
    }
}
