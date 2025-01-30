using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_InventoryItemController : MonoBehaviour
{
    Item item;

    public Button UseBtn;  // Botón de usar
    public Button CloseBtn; // Botón de cerrar

    public void AddItem(Item newItem)
    {
        item = newItem;

        // Asigna el evento de clic al botón del ítem
        GetComponent<Button>().onClick.AddListener(SelectItem);
    }

    // Método que activa los botones al seleccionar un ítem
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
