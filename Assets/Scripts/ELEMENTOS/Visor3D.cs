using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visor3D : MonoBehaviour
{
    public GameObject ObjVisual;
    public GameObject camaraVisual;
    public GameObject objEnEscena;

    public bool activa;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q) && activa == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            ObjVisual.SetActive(true);
            camaraVisual.SetActive(true);
            objEnEscena.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && activa == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            ObjVisual.SetActive(false);
            camaraVisual.SetActive(false);
            objEnEscena.SetActive(true);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            activa = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;


            activa = false;
            ObjVisual.SetActive(false);
            camaraVisual.SetActive(false);
            objEnEscena.SetActive(true);

        }
    }
}


