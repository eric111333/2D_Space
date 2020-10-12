using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour
{
    public Move A;
        
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        A.OnMouseDown();
        if (Input.GetKey(KeyCode.Mouse0))
        A.OnMouseDrag();
        if (Input.GetKeyUp(KeyCode.Mouse0)) 
        A.OnMouseExit();
    }
}
