using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_InventoryItemController : MonoBehaviour
{
    Item item;

    public Button UseBtn;  // Bot�n de usar
    public Button CloseBtn; // Bot�n de cerrar

    public void AddItem(Item newItem)
    {
        item = newItem;

        // Asigna el evento de clic al bot�n del �tem
        GetComponent<Button>().onClick.AddListener(SelectItem);
    }

    // M�todo que activa los botones al seleccionar un �tem
    public void SelectItem()
    {
        if (UseBtn != null)
        {
            UseBtn.gameObject.SetActive(true);
        }

        if (CloseBtn != null)
        {
            CloseBtn.gameObject.SetActive(true);
        }
    }
}
