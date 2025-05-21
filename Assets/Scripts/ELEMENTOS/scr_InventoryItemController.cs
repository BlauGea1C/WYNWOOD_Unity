
using UnityEngine;
using UnityEngine.UI;

public class scr_InventoryItemController : MonoBehaviour
{
    private Item item;

    public Button viewButton;

    private void Start()
    {
        viewButton = GetComponent<Button>();
        if (viewButton != null)
        {
            viewButton.onClick.AddListener(OnItemButtonPressed);
        }
    }

    public void AddItem(Item newItem)
    {
        item = ScriptableObject.Instantiate(newItem); // Copia única
        Debug.Log("Item asignado al botón: " + item.itemsName);
    }

    public void OnItemButtonPressed()
    {
        if (item != null)
        {
            InventoryManager.Instance.ShowRawImage(item);
        }
    }
}
