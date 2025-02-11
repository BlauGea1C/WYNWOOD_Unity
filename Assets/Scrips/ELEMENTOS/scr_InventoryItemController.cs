using UnityEngine;
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
        //Debug.Log("�tem seleccionado: " + item.itemsName);

        // Activar RawImage cuando se selecciona el �tem
        if (InventoryManager.Instance.CanvasRawImage != null)
        {
            InventoryManager.Instance.ShowRawImage();
            Debug.Log("RawImage activado");
        }
    }
}
