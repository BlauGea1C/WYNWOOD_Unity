using UnityEngine;
using UnityEngine.UI;

public class scr_InventoryItemController : MonoBehaviour
{
    private Item item;
    public GameObject ItemPanel; // Panel donde se muestra el ítem
    public Visor3D visor3D; // Referencia al Visor3D

    public void AddItem(Item newItem)
    {
        item = newItem;
        // Añadir un listener al botón del inventario para activar el visor 3D
        GetComponent<Button>().onClick.AddListener(ActivarVisor);
    }

    public void ActivarVisor()
    {
        // Si el visor3D no es nulo, activamos el visor
        if (visor3D != null)
        {
            visor3D.ActivarVisor3D();
        }
    }
}
