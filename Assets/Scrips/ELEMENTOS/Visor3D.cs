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
        if(Input.GetKeyDown(KeyCode.E) && activa == true)
        {
            ObjVisual.SetActive(true);
            camaraVisual.SetActive(true);
            objEnEscena.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && activa == true)
        {
            ObjVisual.SetActive(false);
            camaraVisual.SetActive(false);
            objEnEscena.SetActive(true);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
            activa = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            activa = false;
            ObjVisual.SetActive(false);
            camaraVisual.SetActive(false);
            objEnEscena.SetActive(true);

        }
    }
}
