using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_ItemPickup : MonoBehaviour
{
    public Item item; // Asigna el ítem en el inspector

    private void Update()
    {
       // // Verifica si se ha hecho clic con el ratón
       // if (Input.GetMouseButtonDown(0)) // 0 es el botón izquierdo del ratón
       // {
       //     // Realiza un rayo desde la cámara hacia la posición del ratón
       //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       //     RaycastHit hit;
       //
       //     // Si el rayo golpea un objeto
       //     if (Physics.Raycast(ray, out hit))
       //     {
       //         // Verifica si el objeto golpeado es este ítem
       //         if (hit.transform == transform)
       //         {
       //             // Llama al método para recoger el ítem
       //             InventoryManager.Instance.OnItemPicked(item);
       //             Destroy(gameObject); // Destruye el objeto de recogida
       //         }
       //     }
       // }
    }
}

