using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_ItemPickup : MonoBehaviour
{
    public Item item; // Asigna el �tem en el inspector

    private void Update()
    {
        // Verifica si se ha hecho clic con el bot�n izquierdo del rat�n
        if (Input.GetMouseButtonDown(0))
        {
            // Obt�n el centro de la pantalla
            Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0f);

            // Crea un rayo desde la c�mara utilizando el centro de la pantalla
            Ray ray = Camera.main.ScreenPointToRay(screenCenter);
            RaycastHit hit;

            // Si el rayo impacta alg�n objeto
            if (Physics.Raycast(ray, out hit))
            {
                // Comprueba si el objeto golpeado es este mismo objeto de recogida
                if (hit.transform == transform)
                {
                    // Llama al m�todo para recoger el �tem y agregarlo al inventario
                    InventoryManager.Instance.OnItemPicked(item);

                    // Destruye el objeto recogido de la escena
                    Destroy(gameObject);
                }
            }
        }
    }
}

