using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_ItemPickup : MonoBehaviour
{
    public Item item; // Asigna el �tem en el inspector

    private void Update()
    {
       // // Verifica si se ha hecho clic con el rat�n
       // if (Input.GetMouseButtonDown(0)) // 0 es el bot�n izquierdo del rat�n
       // {
       //     // Realiza un rayo desde la c�mara hacia la posici�n del rat�n
       //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       //     RaycastHit hit;
       //
       //     // Si el rayo golpea un objeto
       //     if (Physics.Raycast(ray, out hit))
       //     {
       //         // Verifica si el objeto golpeado es este �tem
       //         if (hit.transform == transform)
       //         {
       //             // Llama al m�todo para recoger el �tem
       //             InventoryManager.Instance.OnItemPicked(item);
       //             Destroy(gameObject); // Destruye el objeto de recogida
       //         }
       //     }
       // }
    }
}

