using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase Instance;
    public List<Item> allItems = new List<Item>(); // Lista de todos los ítems del juego

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

    // Obtener un ítem por su ID
    public Item GetItemByID(string id)
    {
        return allItems.Find(item => item.id == id);
    }
}
