using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_ItemPickup : MonoBehaviour
{
    /*public Item item; // Asigna el ítem en el inspector

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
                    // Verifica si el ID del ítem es válido antes de agregarlo al inventario
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
            }
        }
    }
}*/
    /*
    public bool isPickupItem = true; // Si es true, se recoge; si es false, activa un Canvas.
    public bool isCandadoItem = false; // Si es true, se recoge; si es false, activa un Canvas.
    public bool isPuertaItem = false; // Si es true, se recoge; si es false, activa un Canvas.
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
                    else if (isCandadoItem)// Si es un objeto que activa un Canvas
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
                    else if (isPuertaItem)
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
                }
            }
        }
    }
   */
    public bool isPickupItem = true; // Si es true, se recoge; si es false, activa un Canvas.
    public bool isCandadoItem = false; // Si es true, se recoge; si es false, activa un Canvas.
    public bool isPuertaItem = false; // Si es true, se recoge; si es false, activa un Canvas.
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
                    else if (isCandadoItem) // Si es un objeto que activa un Canvas
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
                        else if (InventoryManager.Instance.HasKeyForCanvas(item)) // Si tiene una llave para mostrar el canvas
                        {
                            if (canvasToActivate != null)
                            {
                                canvasToActivate.SetActive(true);
                                Debug.Log("Mostrando el Canvas de la llave.");
                            }
                            else
                            {
                                Debug.LogError("No se ha asignado un Canvas para esta llave.");
                            }
                        }
                        else
                        {
                            Debug.Log("No tienes la llave para abrir esta puerta.");
                        }
                    }
                }
            }
        }
    }
}

