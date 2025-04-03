using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryButton : MonoBehaviour
{
    public Item item;  // El �tem que el bot�n representa

    // M�todo que se llama cuando el jugador hace clic en el bot�n
    public void OnButtonClicked()
    {
        // Llama al InventoryManager para agregar el �tem al inventario
        InventoryManager.Instance.Add(item);

        // Desactiva el Canvas (puedes tambi�n eliminar los botones si es necesario)
        GameObject canvasToDeactivate = this.transform.parent.gameObject; // El canvas que contiene el bot�n
        if (canvasToDeactivate != null)
        {
            canvasToDeactivate.SetActive(false);
        }

        // Opcional: Destruir el bot�n espec�fico (si no quieres que quede en el canvas)
        Destroy(this.gameObject);
    }
}
