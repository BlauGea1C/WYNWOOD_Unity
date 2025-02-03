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
    public GameObject mira;

    public scr_InventoryItemController[] InventroryItems;

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

    public void ToggleInventoryUI()
    {
        if (InventoryUI != null && mira != null)
        {
            InventoryUI.SetActive(!InventoryUI.activeSelf);
            mira.SetActive(!InventoryUI.activeSelf);
        }
    }

    public bool IsInventoryOpen()
    {
        return InventoryUI.activeSelf;
    }

    public void Add(Item item)
    {
        Items.Add(item);
        Debug.LogWarning("Ítem añadido: " + item.itemsName);
        ListItems();
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
            Debug.LogWarning("Objeto creado para: " + item.itemsName);

            var itemsNameTransform = obj.transform.Find("itemsName");
            var itemsName = itemsNameTransform.GetComponent<TextMeshProUGUI>();

            var itemsIconoTransform = obj.transform.Find("ItemIcono");
            var ItemIcono = itemsIconoTransform.GetComponent<Image>();

            itemsName.text = item.itemsName;
            ItemIcono.sprite = item.ItemIcono;
        }

        SetInvetoryItems();
    }

    public void OnItemPicked(Item item)
    {
        Add(item);
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
