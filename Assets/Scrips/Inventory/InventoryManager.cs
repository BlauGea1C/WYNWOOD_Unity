using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    // Lista que almacenar� los objetos del inventario
    public List<Item> Items = new List<Item>();

    // Hace referencia al contenedor donde se mostrar�n los objetos en la interfaz de usuario (UI)
    public Transform ItemContent;

    // Prefab que representa un �tem del inventario en la UI
    public GameObject InventoryItem;

    // Contenedor de la UI del inventario
    public GameObject InventoryUI;

    public scr_InventoryItemController[] InventroryItems;

    private void Awake()
    {
        // Implementaci�n del patr�n Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // M�todo para alternar la visibilidad del inventario
    public void ToggleInventoryUI()
    {
        if (InventoryUI != null)
        {
            InventoryUI.SetActive(!InventoryUI.activeSelf);
        }
    }

    // M�todo para a�adir un �tem al inventario
    public void Add(Item item)
    {
        Items.Add(item);
        Debug.LogWarning("�tem a�adido: " + item.itemsName);
        ListItems(); // Actualiza la UI del inventario
    }

    // M�todo para mostrar todos los �tems en el inventario
    public void ListItems()
    {
        // Limpia el inventario
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        // Recorre todos los �tems en la lista del inventario
        foreach (var item in Items)
        {
            // Crea un nuevo objeto en el inventario
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            Debug.LogWarning("Objeto creado para: " + item.itemsName);

            // Busca el objeto hijo que tiene el nombre "itemsName"
            var itemsNameTransform = obj.transform.Find("itemsName");
            var itemsName = itemsNameTransform.GetComponent<TextMeshProUGUI>();
            Debug.LogWarning("Objeto creado para: " + item.itemsName);

            // Busca el objeto hijo que tiene el nombre "ItemIcono"
            var itemsIconoTransform = obj.transform.Find("ItemIcono");
            var ItemIcono = itemsIconoTransform.GetComponent<Image>();
            Debug.LogWarning("Objeto creado para: " + item.ItemIcono);

            itemsName.text = item.itemsName;
            ItemIcono.sprite = item.ItemIcono;

            Debug.LogWarning("Nombre del �tem referenciado: " + item.itemsName);
            Debug.LogWarning("Imagen del �tem referenciado: " + item.ItemIcono);
        }

        SetInvetoryItems();
    }

    // M�todo que se puede llamar al recoger un �tem
    public void OnItemPicked(Item item)
    {
        Add(item); // A�ade el �tem al inventario
    }

    public void SetInvetoryItems()
    {
        InventroryItems = ItemContent.GetComponentsInChildren<scr_InventoryItemController>();

        for (int i = 0; i < Items.Count; i++)
        {
            InventroryItems[i].AddItem(Items[i]);
        }
    }
}
