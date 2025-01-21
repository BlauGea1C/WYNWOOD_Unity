using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    // Lista que almacenará los objetos del inventario
    public List<Item> Items = new List<Item>();

    // Hace referencia al contenedor donde se mostrarán los objetos en la interfaz de usuario (UI)
    public Transform ItemContent;

    // Prefab que representa un ítem del inventario en la UI
    public GameObject InventoryItem;

    private void Awake()
    {
        Instance = this;
    }

    // Método para añadir un ítem al inventario
    public void Add(Item item)
    { 
        Items.Add(item);
        Debug.LogWarning("ADD");
    }

    // Método para eliminar un ítem del inventario
    public void Remove(Item item)
    {
        Items.Remove(item);

    }

  // Método para mostrar todos los ítems en el inventario 
    public void ListItemse()
    {
       
        //Limpia el inventario
        /*foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
            Debug.LogWarning("Limpia el inventario");

        }*/
       // Recorre todos los ítems en la lista del inventario
        foreach (var item in Items)
        {
            Debug.LogWarning("DENTRO FOR");

            //Crea un nuevo objeto en el inventario
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            Debug.LogWarning("OBJETO CREADO");

            //Busca el objeto hijo qu tiene el nombre "itemName" y lo pone el itemsName
            var itemsName = obj.transform.Find("itemsName").GetComponent<Text>();
            
            itemsName.text = item.itemsName;
            Debug.LogWarning("REFERENCIADO");
        }
        Debug.LogWarning("Fuera del FOR");
    }

}
