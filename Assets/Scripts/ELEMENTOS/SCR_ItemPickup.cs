using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_ItemPickup : MonoBehaviour
{
   
    public bool isPickupItem = true;
    public bool isCandadoItem = false;
    public bool isPuertaItem = false;
    public bool isCajaDiaro = false;
    public bool isMochila = false;
    public Item item;
    public KeyPad keyPad;
    public GameObject canvasToActivate;
    public GameObject canvasToActivateCandado2;

    private bool isAlreadyOpened = false;

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
                    if (isPickupItem)
                    {
                        if (!string.IsNullOrEmpty(item.id))
                        {
                            InventoryManager.Instance.OnItemPicked(item);
                            DialogManager.Instance.ShowMessage(item.mensajes);
                            Destroy(gameObject);
                        }
                        else
                        {
                            Debug.LogError("El ítem no tiene un ID asignado.");
                        }
                    }
                    else if (isCandadoItem)
                    {
                            if (canvasToActivate != null)
                            {

                                isAlreadyOpened = true;
                                DialogManager.Instance.ShowMessage("me guarde el codigo en la mochila ");
                                canvasToActivate.SetActive(true);
                                Cursor.visible = true;
                                Cursor.lockState = CursorLockMode.None;
                            }
                            else
                            {
                                Debug.LogError("No se ha asignado un Canvas para activar.");
                                return;
                            }
                       
                       
                    }
                    else if (isPuertaItem)
                    {
                        if (InventoryManager.Instance.HasKeyForDoor(item))
                        {
                            DialogManager.Instance.ShowMessage("Miremos que tiene por aca  ");
                            Destroy(gameObject);
                            Debug.Log("La puerta ha sido abierta.");
                        }
                        else
                        {
                            Debug.Log("No tienes la llave para abrir esta puerta.");
                        }
                    }
                    else if (isCajaDiaro)
                    {
                        if (!isAlreadyOpened)
                        {
                            if (InventoryManager.Instance.HasKeyForBox(item))
                            {
                               
                                isAlreadyOpened = true;
                                canvasToActivate.SetActive(true);
                                Cursor.visible = true;
                                Cursor.lockState = CursorLockMode.None;
                                Debug.Log("La caja / diario / cajon ha sido abierta.");
                            }
                            else
                            {
                                Debug.Log("No tienes la llave para abrir esta caja / diario / cajon.");
                                return;
                            }

                        }
                        else
                        {
                            canvasToActivate.SetActive(true);
                            Cursor.visible = true;
                            Cursor.lockState = CursorLockMode.None;
                        }
                    }
                    else if (isMochila)
                    {
                        if (canvasToActivate != null)
                        {
                            
                            canvasToActivate.SetActive(true);
                            Cursor.visible = true;
                            Cursor.lockState = CursorLockMode.None;
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
}
