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

    public GameObject panelToCloseMochila;
    public GameObject panelToCloseTaquilla;
    public GameObject panelToCloseCaixa;
    public GameObject panelToCloseCalaix;
    public GameObject panelToCloseDiario;
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
        if (panelToCloseMochila != null)
        {
            panelToCloseMochila.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (panelToCloseTaquilla != null)
        {
            panelToCloseTaquilla.SetActive(false);
            
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (panelToCloseCaixa != null)
        {
            panelToCloseCaixa.SetActive(false);

            DialogManager.Instance.ShowMessage("Si voy a casa de amelia es posible que encuentre algo sobre su padre");

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (panelToCloseCalaix != null)
        {
            panelToCloseCalaix.SetActive(false);
            DialogManager.Instance.ShowMessage("Tengo que avisar a mi madre, algo bueno habra por ser hija de la sheriff");
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (panelToCloseDiario != null)
        {
            panelToCloseDiario.SetActive(false);
            DialogManager.Instance.ShowMessage("Parece ser que Noah descubri� algo importante, espero que por esto no haya muerto");
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

   
}
