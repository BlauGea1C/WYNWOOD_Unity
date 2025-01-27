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

    // Lista que almacenar� los objetos del inventario
    public List<Item> Items = new List<Item>();

    // Hace referencia al contenedor donde se mostrar�n los objetos en la interfaz de usuario (UI)
    public Transform ItemContent;

    // Prefab que representa un �tem del inventario en la UI
    public GameObject InventoryItem;

    public Toggle EnableRemove;

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

    // M�todo para a�adir un �tem al inventario
    public void Add(Item item)
    {
        Items.Add(item);
        Debug.LogWarning("�tem a�adido: " + item.itemsName);
        ListItems(); // Actualiza la UI del inventario
    }

    // M�todo para eliminar un �tem del inventario
    public void Remove(Item item)
    {
        Items.Remove(item);
        Debug.LogWarning("�tem eliminado: " + item.itemsName);
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

           // var itemImage = obj.transform.Find("Image").GetComponent<Image>();


            var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();

            itemsName.text = item.itemsName;

           // itemImage.sprite = item.icon;


            Debug.LogWarning("Nombre del �tem referenciado: " + item.itemsName);

            if (EnableRemove.isOn)
            {
                removeButton.gameObject.SetActive(true);
            }
        }

        SetInvetoryItems();
    }

    // M�todo que se puede llamar al recoger un �tem
    public void OnItemPicked(Item item)
    {
        Add(item); // A�ade el �tem al inventario
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
