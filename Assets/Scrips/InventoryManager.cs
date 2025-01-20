using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    { 
        Items.Add(item); 
    
    }

    public void Remove(Item item)
    {
        Items.Remove(item);

    }

    public void ListItemse()
    {

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemsName = obj.transform.Find("");
        
        
        }
    }
}
