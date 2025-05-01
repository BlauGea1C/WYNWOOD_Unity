/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Scr_Movimiento3D : MonoBehaviour
{
    public float speedH;
    public float speedV;

    float moveH;
    float moveV;

    private void OnMouseDrag()
    {
        Debug.Log("HOLA");

        moveH -= speedH * Input.GetAxis("Mouse X");
        moveV += speedV * Input.GetAxis("Mouse Y");

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("GIRE");
            transform.eulerAngles = new Vector3(moveV, moveH, 0f);
        }

        Debug.Log("ADEU");
    }
}
*/

/*using UnityEngine;


public class Scr_Movimiento3D : MonoBehaviour
{
    public float rotationSpeed = 5f;  // Velocidad de rotación
    private Vector3 lastMousePosition;  // Última posición del mouse

    public GameObject ObjView;

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detecta cuando el usuario hace clic
        {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0)) // Mantiene presionado el clic
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            float rotX = delta.y * rotationSpeed * Time.deltaTime;
            float rotY = -delta.x * rotationSpeed * Time.deltaTime;

            ObjView.transform.Rotate(Vector3.right, rotX, Space.World);
            ObjView.transform.Rotate(Vector3.up, rotY, Space.World);

            lastMousePosition = Input.mousePosition; // Actualiza la última posición del mouse
        }
    }
}
*/

using UnityEngine;

public class Scr_Movimiento3D : MonoBehaviour
{
    public float rotationSpeed = 5f;  // Velocidad de rotación
    private Vector3 lastMousePosition;  // Última posición del mouse

    public GameObject ObjView; // Objeto que se rota (el objeto que contiene el modelo 3D)
    private Transform objetoARotar;

    void Start()
    {
        // Buscar el mesh dentro de ObjView si está anidado
        if (ObjView.transform.childCount > 0)
        {
            objetoARotar = ObjView.transform.GetChild(0); // Rota el primer hijo
        }
        else
        {
            objetoARotar = ObjView.transform; // Si no tiene hijos, rota el mismo objeto
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detecta clic inicial
        {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0)) // Mientras se mantenga el clic
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            float rotX = delta.y * rotationSpeed * Time.deltaTime;
            float rotY = -delta.x * rotationSpeed * Time.deltaTime;

            if (objetoARotar != null)
            {
                objetoARotar.Rotate(Vector3.right, rotX, Space.World);
                objetoARotar.Rotate(Vector3.up, rotY, Space.World);
            }

            lastMousePosition = Input.mousePosition;
        }
    }
}