using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    // Lista que almacenará los objetos del inventario
    public List<Item> Items = new List<Item>();

    // Hace referencia al contenedor donde se mostrarán los objetos en la interfaz de usuario (UI)
    public Transform ItemContent;

    // Prefab que representa un ítem del inventario en la UI
    public GameObject InventoryItem;

    public Toggle EnableRemove;

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

    // Método para añadir un ítem al inventario
    public void Add(Item item)
    {
        Items.Add(item);
        Debug.LogWarning("Ítem añadido: " + item.itemsName);
        ListItems(); // Actualiza la UI del inventario
    }

    // Método para eliminar un ítem del inventario
    public void Remove(Item item)
    {
        Items.Remove(item);
        Debug.LogWarning("Ítem eliminado: " + item.itemsName);
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

           // var itemImage = obj.transform.Find("Image").GetComponent<Image>();


            var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();

            itemsName.text = item.itemsName;

           // itemImage.sprite = item.icon;


            Debug.LogWarning("Nombre del ítem referenciado: " + item.itemsName);

            if (EnableRemove.isOn)
            {
                removeButton.gameObject.SetActive(true);
            }
        }

        SetInvetoryItems();
    }

    // Método que se puede llamar al recoger un ítem
    public void OnItemPicked(Item item)
    {
        Add(item); // Añade el ítem al inventario
    }

    public void EnableItemsRemove()
    {
        if (EnableRemove.isOn)
        {
            foreach( Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(true);
            }

        }
        else
        {
            foreach (Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(false);
            }

        }
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
