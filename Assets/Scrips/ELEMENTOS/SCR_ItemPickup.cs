using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_ItemPickup : MonoBehaviour
{
    public Item item; // Asigna el ítem en el inspector

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
}
