/*using UnityEngine;
using UnityEngine.UI;

public class scr_InventoryItemController : MonoBehaviour
{
    public Item item;

    private void Start()
    {
        // Agrega un evento al bot�n del objeto en el inventario
        GetComponent<Button>().onClick.AddListener(SelectItem);
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void SelectItem()
    {
        // Activar RawImage cuando se selecciona el �tem
        if (InventoryManager.Instance.CanvasRawImage != null)
        {
            InventoryManager.Instance.ShowRawImage(item);
            Debug.Log("RawImage activado");
        }
    }
}*/

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
        item = ScriptableObject.Instantiate(newItem); // Copia �nica
        Debug.Log("Item asignado al bot�n: " + item.itemsName);
    }

    public void OnItemButtonPressed()
    {
        if (item != null)
        {
            InventoryManager.Instance.ShowRawImage(item);
        }
    }
}
