using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_ItemPickup : MonoBehaviour
{
    public Item item; // Asigna el ítem en el inspector

    private void Update()
    {
        // Verifica si se ha hecho clic con el botón izquierdo del ratón
        if (Input.GetMouseButtonDown(0))
        {
            // Obtén el centro de la pantalla
            Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0f);

            // Crea un rayo desde la cámara utilizando el centro de la pantalla
            Ray ray = Camera.main.ScreenPointToRay(screenCenter);
            RaycastHit hit;

            // Si el rayo impacta algún objeto
            if (Physics.Raycast(ray, out hit))
            {
                // Comprueba si el objeto golpeado es este mismo objeto de recogida
                if (hit.transform == transform)
                {
                    // Llama al método para recoger el ítem y agregarlo al inventario
                    InventoryManager.Instance.OnItemPicked(item);

                    // Destruye el objeto recogido de la escena
                    Destroy(gameObject);
                }
            }
        }
    }
}

