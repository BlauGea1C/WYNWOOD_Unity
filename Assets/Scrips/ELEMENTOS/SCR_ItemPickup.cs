using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_ItemPickup : MonoBehaviour
{
 
    public bool isPickupItem = true; 
    public bool isCandadoItem = false; 
    public bool isPuertaItem = false; 
    public bool isCajaDiaro = false; 
    public Item item; // Solo si es un objeto recogible.
    public GameObject canvasToActivate; // Solo si es un objeto que activa un Canvas.

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0f);
            Ray ray = Camera.main.ScreenPointToRay(screenCenter);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    if (isPickupItem) // Si es un objeto recogible
                    {
                        if (!string.IsNullOrEmpty(item.id))
                        {
                            InventoryManager.Instance.OnItemPicked(item);
                            Destroy(gameObject);
                        }
                        else
                        {
                            Debug.LogError("El ítem no tiene un ID asignado.");
                        }
                    }
                    else if (isCandadoItem) // Si el objeto activa un Canvas con opciones
                    {
                        if (canvasToActivate != null)
                        {
                            canvasToActivate.SetActive(true); 
                        }
                        else
                        {
                            Debug.LogError("No se ha asignado un Canvas para activar.");
                        }
                    }
                    else if (isPuertaItem) // Si es una puerta, comprobar si el jugador tiene la llave
                    {
                        if (InventoryManager.Instance.HasKeyForDoor(item)) // Si tiene la llave para la puerta
                        {
                            Destroy(gameObject); // Destruir la puerta
                            Debug.Log("La puerta ha sido abierta.");
                        }
                        else
                        {
                            Debug.Log("No tienes la llave para abrir esta puerta.");
                        }
                    }
                    else if (isCajaDiaro) // Si es una puerta, comprobar si el jugador tiene la llave
                    {
                        if (InventoryManager.Instance.HasKeyForBox(item)) // Si tiene la llave para la puerta
                        {
                            canvasToActivate.SetActive(true);
                            Debug.Log("La caja / diario ha sido abierta.");
                        }
                        else
                        {
                            Debug.Log("No tienes la llave para abrir esta caja.");
                        }
                    }
                }
            }
        }
    }
}

