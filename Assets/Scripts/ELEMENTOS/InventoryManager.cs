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
            /*else if (item.loc == "6")
            {
                teleportScript.DesbloquearBoton6();
            }*/
        }

        ListItems(); // Actualizar la UI
    }

    public void AddFromCanvas(Item item, GameObject canvas)
    {
        Add(item);
       
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


    public bool HasKeyForDoor(Item doorItem)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].Llave && Items[i].LlavesPuerta)
            {
                Items.RemoveAt(i); // Eliminar la llave del inventario
                ListItems(); // Actualizar la UI del inventario
                return true; // Se encontró y eliminó la llave
            }
        }
        DialogManager.Instance.ShowMessage("Necesitas una llave para abrir esta puerta.");
        return false;
    }

    // Verifica si el jugador tiene la llave para caja/diario/cajon y la elimina si la usa
    public bool HasKeyForBox(Item boxItem)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].Llave && Items[i].LlavesCaja)
            {
                Items.RemoveAt(i); // Eliminar la llave del inventario
                ListItems(); // Actualizar la UI del inventario
                return true; // Se encontró y eliminó la llave
            }
        }
        DialogManager.Instance.ShowMessage("Está cerrado. Necesitas una llave para abrilo.");
        return false;
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

            // Activar visor
            CanvasRawImage.SetActive(true);

            // Instanciar objeto y colocarlo en el expositor
            ObjExpositor = Instantiate(Items[ItemEnLista].Objeto3D, Expositor.transform);
            ObjExpositor.layer = LayerMask.NameToLayer("CamaraObj3D");

            // Asegurar que todas las partes del objeto tengan la capa correcta
            foreach (Transform Meshes in ObjExpositor.transform)
            {
                Meshes.gameObject.layer = LayerMask.NameToLayer("CamaraObj3D");
            }

            // Alinear posición al centro del expositor
            ObjExpositor.transform.localPosition = Vector3.zero;

            // Enviar el objeto al rotador
            FindObjectOfType<Scr_Movimiento3D>().SetObjectToRotate(ObjExpositor);

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