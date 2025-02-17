using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<Item> Items = new List<Item>(); // Lista de ítems en el inventario

    public Transform ItemContent;  // Contenedor en la UI para mostrar los ítems
    public GameObject InventoryItem; // Prefab de los ítems del inventario
    public GameObject InventoryUI;  // UI del inventario

    public scr_InventoryItemController[] InventoryItems;

    public GameObject CanvasRawImage; //Referencia al RawImage en la UI

    GameObject ObjExpositor;
    public GameObject Expositor;

    public ScrollRect Scroll;

    public bool isRawImageOpen;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
           
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Alterna la visibilidad del inventario
    public void ToggleInventoryUI()
    {
        if (InventoryUI != null)
        {
            InventoryUI.SetActive(!InventoryUI.activeSelf);
        }
    }

    // Añadir ítem al inventario
    public void Add(Item item)
    {
        Items.Add(item);
        Debug.Log("Ítem añadido: " + item.itemsName);
        ListItems(); // Actualizar la UI
    }

    // Actualizar la UI del inventario
    public void ListItems()
    {
        // Limpia los ítems existentes en la UI
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            Debug.Log("Objeto creado para: " + item.itemsName);

            var itemsNameTransform = obj.transform.Find("itemsName");
            var itemsName = itemsNameTransform.GetComponent<TextMeshProUGUI>();

            var itemsIconoTransform = obj.transform.Find("ItemIcono");
            var ItemIcono = itemsIconoTransform.GetComponent<Image>();

            itemsName.text = item.itemsName;
            ItemIcono.sprite = item.ItemIcono;

            //Configurar el controlador del ítem
            scr_InventoryItemController itemController = obj.GetComponent<scr_InventoryItemController>();
            itemController.AddItem(item);
        }

        SetInventoryItems();
    }

    public void OnItemPicked(Item item)
    {
        Add(item); // Añade el ítem y actualiza el inventario
    }

    public void SetInventoryItems()
    {
        InventoryItems = ItemContent.GetComponentsInChildren<scr_InventoryItemController>();

        int itemCount = Mathf.Min(Items.Count, InventoryItems.Length);
        for (int i = 0; i < itemCount; i++)
        {
            InventoryItems[i].AddItem(Items[i]);
        }
    }

    // Método para activar el RawImage al seleccionar un ítem
    public void ShowRawImage(Item item)
    {
        if (CanvasRawImage != null)
        {
            var NewItemID = item.id;

            int ItemEnLista = Items.FindIndex(i => i.id == item.id);


            CanvasRawImage.SetActive(true);
            ObjExpositor = Instantiate(Items[ItemEnLista].Objeto3D, Expositor.transform);
            ObjExpositor.transform.localPosition = Vector3.zero;

            Scroll.enabled = false;
           
            isRawImageOpen = true;
        }
    }

    public void DisableRawImage()
    {
        if (CanvasRawImage != null)
        {
            CanvasRawImage.SetActive(false);

             Scroll.enabled = true;

            foreach (Transform Objeto in Expositor.transform)
            {
                Destroy(Objeto.gameObject);
            }

            isRawImageOpen = false;
        }
    }
}
