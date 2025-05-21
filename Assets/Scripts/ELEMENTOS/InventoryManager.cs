/*using System.Collections;
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
            }*//*
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
*//*
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<Item> Items = new List<Item>();

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

        Scr_Teleport teleportScript = FindObjectOfType<Scr_Teleport>();
        if (teleportScript != null)
        {
            switch (item.loc)
            {
                case "2": teleportScript.DesbloquearBoton2(); break;
                case "3": teleportScript.DesbloquearBoton3(); break;
                case "4": teleportScript.DesbloquearBoton4(); break;
                case "5": teleportScript.DesbloquearBoton5(); break;
                    // case "6": teleportScript.DesbloquearBoton6(); break;
            }
        }

        ListItems();
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

            var itemsName = obj.transform.Find("itemsName").GetComponent<TextMeshProUGUI>();
            var itemIcono = obj.transform.Find("ItemIcono").GetComponent<Image>();

            itemsName.text = item.itemsName;
            itemIcono.sprite = item.ItemIcono;

            var itemController = obj.GetComponent<scr_InventoryItemController>();
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
                Items.RemoveAt(i);
                ListItems();
                return true;
            }
        }

        DialogManager.Instance.ShowMessage("Necesitas una llave para abrir esta puerta.");
        return false;
    }

    public bool HasKeyForBox(Item boxItem)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].Llave && Items[i].LlavesCaja)
            {
                Items.RemoveAt(i);
                ListItems();
                return true;
            }
        }

        DialogManager.Instance.ShowMessage("Está cerrado. Necesitas una llave para abrirlo.");
        return false;
    }

    public void OnItemPicked(Item item)
    {
        Add(item);
    }

    /* public void ShowRawImage(Item item)
     {
         if (CanvasRawImage != null)
         {
             mo.SetActive(false);
             CanvasRawImage.SetActive(true);

             // DESTRUIR TODAS LAS REFERENCIAS PREVIAS DEL EXPOSITOR
             foreach (Transform child in Expositor.transform)
             {
                 DestroyImmediate(child.gameObject); // Usa DestroyImmediate para asegurar limpieza total en el editor y en playmode
             }

             // Buscar índice del ítem
             int itemIndex = Items.FindIndex(i => i.id == item.id);
             if (itemIndex == -1 || Items[itemIndex].Objeto3D == null)
             {
                 Debug.LogWarning("Item no encontrado o prefab inválido.");
                 return;
             }

             // Instanciar el nuevo objeto
             ObjExpositor = Instantiate(Items[itemIndex].Objeto3D, Expositor.transform);
             ObjExpositor.layer = LayerMask.NameToLayer("CamaraObj3D");

             // Asignar la capa a todos sus hijos
             foreach (Transform mesh in ObjExpositor.GetComponentsInChildren<Transform>(true))
             {
                 mesh.gameObject.layer = LayerMask.NameToLayer("CamaraObj3D");
             }

             ObjExpositor.transform.localPosition = Vector3.zero;

             // Rotador
             var rotador = FindObjectOfType<Scr_Movimiento3D>();
             if (rotador != null)
             {
                 rotador.SetObjectToRotate(ObjExpositor);
             }

             Scroll.enabled = false;
             isRawImageOpen = true;
         }
     }*//*

    public void ShowRawImage(Item item)
    {
        if (CanvasRawImage != null)
        {
            mo.SetActive(false);
            CanvasRawImage.SetActive(true);

            // Eliminar objetos anteriores del expositor
            foreach (Transform child in Expositor.transform)
            {
                DestroyImmediate(child.gameObject);
            }

            if (item.Objeto3D == null)
            {
                Debug.LogWarning("El item no tiene Objeto3D asignado.");
                return;
            }

            // Instanciar directamente desde el item dado, sin buscarlo
            ObjExpositor = Instantiate(item.Objeto3D, Expositor.transform);
            ObjExpositor.layer = LayerMask.NameToLayer("CamaraObj3D");

            foreach (Transform mesh in ObjExpositor.GetComponentsInChildren<Transform>(true))
            {
                mesh.gameObject.layer = LayerMask.NameToLayer("CamaraObj3D");
            }

            ObjExpositor.transform.localPosition = Vector3.zero;

            var rotador = FindObjectOfType<Scr_Movimiento3D>();
            if (rotador != null)
            {
                rotador.SetObjectToRotate(ObjExpositor);
            }

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

            foreach (Transform objeto in Expositor.transform)
            {
                Destroy(objeto.gameObject);
            }

            isRawImageOpen = false;
        }
    }
}
*/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<Item> Items = new List<Item>();

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

    public AudioSource audioItem;
    public AudioSource audioCerrado;
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
       

        Scr_Teleport teleportScript = FindObjectOfType<Scr_Teleport>();
        if (teleportScript != null)
        {
            switch (item.loc)
            {
                case "2": teleportScript.DesbloquearBoton2(); break;
                case "3": teleportScript.DesbloquearBoton3(); break;
                case "4": teleportScript.DesbloquearBoton4(); break;
                case "5": teleportScript.DesbloquearBoton5(); break;
                case "6": teleportScript.DesbloquearBoton5(); break;
            }
        }

        ListItems();
        audioItem.Play();
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

            var itemsName = obj.transform.Find("itemsName").GetComponent<TextMeshProUGUI>();
            var itemIcono = obj.transform.Find("ItemIcono").GetComponent<Image>();

            itemsName.text = item.itemsName;
            itemIcono.sprite = item.ItemIcono;

            var itemController = obj.GetComponent<scr_InventoryItemController>();
            itemController.AddItem(item); // Aquí se instancia el item por copia
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
                Items.RemoveAt(i);
                ListItems();
                return true;
            }
        }

        audioCerrado.Play();
        DialogManager.Instance.ShowMessage("Necesitas una llave para abrir esta puerta.");
        return false;
    }

    public bool HasKeyForBox(Item boxItem)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].Llave && Items[i].LlavesCaja)
            {
                Items.RemoveAt(i);
                ListItems();
                return true;
            }
        }
        audioCerrado.Play();
        DialogManager.Instance.ShowMessage("Está cerrado. Necesitas una llave para abrirlo.");
        return false;
    }
    public bool HasKeyForDiario(Item diarioItem)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].Llave && Items[i].LlavesDiario)
            {
                Items.RemoveAt(i);
                ListItems();
                return true;
            }
        }
        audioCerrado.Play();
        DialogManager.Instance.ShowMessage("Está cerrado. Necesitas la llave del diario.");
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
            Debug.Log("Mostrando objeto: " + item.itemsName + " (ID: " + item.id + ")");

            mo.SetActive(false);
            CanvasRawImage.SetActive(true);

            // Eliminar cualquier objeto anterior del expositor
            foreach (Transform child in Expositor.transform)
            {
                Destroy(child.gameObject);
            }

            // Instanciar el nuevo objeto
            ObjExpositor = Instantiate(item.Objeto3D, Expositor.transform);
            ObjExpositor.layer = LayerMask.NameToLayer("CamaraObj3D");

            foreach (Transform mesh in ObjExpositor.GetComponentsInChildren<Transform>(true))
            {
                mesh.gameObject.layer = LayerMask.NameToLayer("CamaraObj3D");
            }

            ObjExpositor.transform.localPosition = Vector3.zero;

            var rotador = FindObjectOfType<Scr_Movimiento3D>();
            if (rotador != null)
            {
                rotador.SetObjectToRotate(ObjExpositor);
            }

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

            foreach (Transform objeto in Expositor.transform)
            {
                Destroy(objeto.gameObject);
            }

            isRawImageOpen = false;
        }
    }
}
