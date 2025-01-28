using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    // Lista que almacenará los objetos del inventario
    public List<Item> Items = new List<Item>();

    // Hace referencia al contenedor donde se mostrarán los objetos en la interfaz de usuario (UI)
    public Transform ItemContent;

    // Prefab que representa un ítem del inventario en la UI
    public GameObject InventoryItem;

    // Contenedor de la UI del inventario
    public GameObject InventoryUI;

    public scr_InventoryItemController[] InventroryItems;

    private void Awake()
    {
        // Implementación del patrón Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Método para alternar la visibilidad del inventario
    public void ToggleInventoryUI()
    {
        if (InventoryUI != null)
        {
            InventoryUI.SetActive(!InventoryUI.activeSelf);
        }
    }

    // Método para añadir un ítem al inventario
    public void Add(Item item)
    {
        Items.Add(item);
        Debug.LogWarning("Ítem añadido: " + item.itemsName);
        ListItems(); // Actualiza la UI del inventario
    }

    // Método para mostrar todos los ítems en el inventario
    public void ListItems()
    {
        // Limpia el inventario
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        // Recorre todos los ítems en la lista del inventario
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

            Debug.LogWarning("Nombre del ítem referenciado: " + item.itemsName);
            Debug.LogWarning("Imagen del ítem referenciado: " + item.ItemIcono);
        }

        SetInvetoryItems();
    }

    // Método que se puede llamar al recoger un ítem
    public void OnItemPicked(Item item)
    {
        Add(item); // Añade el ítem al inventario
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
