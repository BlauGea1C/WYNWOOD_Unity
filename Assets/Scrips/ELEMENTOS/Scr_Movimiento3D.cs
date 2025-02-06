using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Movimiento3D : MonoBehaviour
{
    public float speedH;
    public float speedV;

    float moveH;
    float moveV;

    private void OnMouseDrag()
    {
        moveH -= speedH * Input.GetAxis("Mouse X");
        moveV += speedV * Input.GetAxis("Mouse Y");

        if (Input.GetMouseButtonDown(0))
        {
            transform.eulerAngles = new Vector3(moveV, moveH, 0f);
        }
    }
}
