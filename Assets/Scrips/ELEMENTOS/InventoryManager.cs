using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    
    public static InventoryManager Instance;

    public List<Item> Items = new List<Item>(); // Lista de ítems en el inventario

    public Transform ItemContent;
    public GameObject InventoryItem;
    public GameObject InventoryUI;

    public scr_InventoryItemController[] InventoryItems;

    public GameObject CanvasRawImage;
    public GameObject ObjExpositor;
    public GameObject Expositor;

    public ScrollRect Scroll;

    public bool isRawImageOpen;
    public GameObject mo;
    public LayerMask Viewer3D;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("InventoryManager creado y persistente entre escenas.");
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Se destruyó un duplicado del InventoryManager.");
        }
    }

    public void ToggleInventoryUI()
    {
        if (InventoryUI != null)
        {
            InventoryUI.SetActive(!InventoryUI.activeSelf);
        }
    }

    public void Add(Item item)
    {
        Items.Add(item);
        Debug.Log("Ítem añadido: " + item.itemsName);

        // Llamar a Scr_Teleport para desbloquear botones si el ítem tiene un loc válido
        Scr_Teleport teleportScript = FindObjectOfType<Scr_Teleport>();
        if (teleportScript != null)
        {
            if (item.loc == "2")
            {
                teleportScript.DesbloquearBoton2();
            }
            else if (item.loc == "3")
            {
                teleportScript.DesbloquearBoton3();
            }
            else if (item.loc == "4")
            {
                teleportScript.DesbloquearBoton4();
            }
            else if (item.loc == "5")
            {
                teleportScript.DesbloquearBoton5();
            }
            else if (item.loc == "6")
            {
                teleportScript.DesbloquearBoton6();
            }
        }

        ListItems(); // Actualizar la UI
    }

    public void ListItems()
    {
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

            scr_InventoryItemController itemController = obj.GetComponent<scr_InventoryItemController>();
            itemController.AddItem(item);
        }

        SetInventoryItems();
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

    public void OnItemPicked(Item item)
    {
        Add(item);
    }

    public void ShowRawImage(Item item)
    {
        if (CanvasRawImage != null)
        {
            mo.SetActive(false);
            var NewItemID = item.id;
            int ItemEnLista = Items.FindIndex(i => i.id == item.id);
            CanvasRawImage.SetActive(true);
            ObjExpositor = Instantiate(Items[ItemEnLista].Objeto3D, Expositor.transform);
            ObjExpositor.layer = LayerMask.NameToLayer("CamaraObj3D");

            foreach (Transform Meshes in ObjExpositor.transform)
            {
                Meshes.gameObject.layer = LayerMask.NameToLayer("CamaraObj3D");
            }

            ObjExpositor.transform.localPosition = Vector3.zero;
            Scroll.enabled = false;
            isRawImageOpen = true;
        }
    }

    public void DisableRawImage()
    {
        if (CanvasRawImage != null)
        {
            mo.SetActive(true);
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