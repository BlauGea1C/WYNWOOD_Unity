using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_InventoryItemController : MonoBehaviour
{
   Item item;

    public Button RemoveBtn;
    /*public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);

        Destroy(gameObject);
    }*/

    public void AddItem(Item newItem)
    {
        item = newItem;

    }
}
