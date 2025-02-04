using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class scr_InventoryItemController : MonoBehaviour
{
    Item item;

    //public Button UseBtn;  // Botón de usar
   // public Button CloseBtn; // Botón de cerrar

    public GameObject ItemPanel; // Panel donde se muestra la información del ítem
   // public Image PanelItemImage; // Imagen del ítem en el panel
   // public TextMeshProUGUI PanelItemName; // Nombre del ítem en el panel

    public void AddItem(Item newItem)
    {
        item = newItem;
        GetComponent<Button>().onClick.AddListener(SelectItem);
    }

    public void SelectItem()
    {
        if (ItemPanel != null)
        {
            ItemPanel.SetActive(true); // Mostrar el panel
          //  PanelItemName.text = item.itemsName; // Asignar nombre
           // PanelItemImage.sprite = item.ItemIcono; // Asignar imagen
        }
    }

    public void CloseItemPanel()
    {
        if (ItemPanel != null)
        {
            ItemPanel.SetActive(false); // Ocultar el panel
        }
    }
}
