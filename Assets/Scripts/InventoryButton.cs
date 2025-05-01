using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryButton : MonoBehaviour
{
    /* public GameObject panelToClose; // El panel o canvas que se va a cerrar
     public Item item;  // El �tem que el bot�n representa

     // M�todo que se llama cuando el jugador hace clic en el bot�n
     public void OnButtonClicked()
     {
         // Verifica si el InventoryManager est� disponible y agrega el �tem
         if (InventoryManager.Instance != null)
         {
             InventoryManager.Instance.Add(item);
         }
         else
         {
             Debug.LogWarning("InventoryManager no est� presente en la escena.");
         }

         // Destruye solo este bot�n (no el canvas entero)
         Destroy(this.gameObject);


     }

     // M�todo para cerrar el canvas manualmente (por ejemplo, al pulsar una "X")
     public void OnCloseButtonClicked()
     {
         if (panelToClose != null)
         {
             panelToClose.SetActive(false);
         }
     }
 }*/

    public GameObject panelToClose;
    public Item item;

    public void OnButtonClicked()
    {
        if (InventoryManager.Instance != null)
        {
            InventoryManager.Instance.Add(item);
            DialogManager.Instance.ShowMessage(item.mensajes);
        }
        else
        {
            Debug.LogWarning("InventoryManager no est� presente en la escena.");
        }

        Destroy(this.gameObject);
    }

    public void OnCloseButtonClicked()
    {
        if (panelToClose != null)
        {
            panelToClose.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
