using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryButton : MonoBehaviour
{
  

    public GameObject panelToCloseMochila;
    public GameObject panelToCloseTaquilla;
    public GameObject panelToCloseCaixa;
    public GameObject panelToCloseCalaix;
    public GameObject panelToCloseDiario;
    public Item item;

    public AudioSource audioSourceBotones;
    public void OnButtonClicked()
    {
        if (InventoryManager.Instance != null)
        {
            InventoryManager.Instance.Add(item);
            DialogManager.Instance.ShowMessage(item.mensajes);
        }
        else
        {
            Debug.LogWarning("InventoryManager no está presente en la escena.");
        }

        Destroy(this.gameObject);
    }


    public void OnCloseButtonClicked()
    {
        if (panelToCloseMochila != null)
        {
            audioSourceBotones.Play();
            panelToCloseMochila.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (panelToCloseTaquilla != null)
        {
            audioSourceBotones.Play();
            panelToCloseTaquilla.SetActive(false);
            
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (panelToCloseCaixa != null)
        {
            audioSourceBotones.Play();
            panelToCloseCaixa.SetActive(false);

            DialogManager.Instance.ShowMessage("Si voy a casa de amelia es posible que encuentre algo sobre su padre");

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (panelToCloseCalaix != null)
        {
            audioSourceBotones.Play();
            panelToCloseCalaix.SetActive(false);
            DialogManager.Instance.ShowMessage("Tengo que avisar a mi madre, algo bueno habra por ser hija de la sheriff");
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (panelToCloseDiario != null)
        {
            audioSourceBotones.Play();
            panelToCloseDiario.SetActive(false);
            DialogManager.Instance.ShowMessage("Parece ser que Noah descubrió algo importante, espero que por esto no haya muerto");
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

   
}
/* public GameObject panelToClose; // El panel o canvas que se va a cerrar
   public Item item;  // El ítem que el botón representa

   // Método que se llama cuando el jugador hace clic en el botón
   public void OnButtonClicked()
   {
       // Verifica si el InventoryManager está disponible y agrega el ítem
       if (InventoryManager.Instance != null)
       {
           InventoryManager.Instance.Add(item);
       }
       else
       {
           Debug.LogWarning("InventoryManager no está presente en la escena.");
       }

       // Destruye solo este botón (no el canvas entero)
       Destroy(this.gameObject);


   }

   // Método para cerrar el canvas manualmente (por ejemplo, al pulsar una "X")
   public void OnCloseButtonClicked()
   {
       if (panelToClose != null)
       {
           panelToClose.SetActive(false);
       }
   }
}*/