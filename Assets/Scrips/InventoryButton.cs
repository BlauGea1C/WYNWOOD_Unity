using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryButton : MonoBehaviour
{
    public Item item;  // El ítem que el botón representa

    // Método que se llama cuando el jugador hace clic en el botón
    public void OnButtonClicked()
    {
        // Llama al InventoryManager para agregar el ítem al inventario
        InventoryManager.Instance.Add(item);

        // Desactiva el Canvas (puedes también eliminar los botones si es necesario)
        GameObject canvasToDeactivate = this.transform.parent.gameObject; // El canvas que contiene el botón
        if (canvasToDeactivate != null)
        {
            canvasToDeactivate.SetActive(false);
        }

        // Opcional: Destruir el botón específico (si no quieres que quede en el canvas)
        Destroy(this.gameObject);
    }
}
