using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyPad : MonoBehaviour
{

   [SerializeField] private TextMeshProUGUI Ans;

    private string contra = "1234";
    private float resetTime = 2f;  // Tiempo en segundos antes de limpiar el texto
    public GameObject panelToClose; // El panel o canvas que se va a cerrar

    public GameObject TaquillaUI;

    // Referencia al script de inventario
    //  public Scr_PlayerMovement Player;

    // Reiniciar el texto cada vez que se activa el panel del KeyPad
    void OnEnable()
    {
        Ans.text = "";
    }

    public void Number(int number)
    {
        // Solo agregar el n�mero si la longitud actual es menor a 4
        if (Ans.text.Length < 4)
        {
            Ans.text += number.ToString();
        }
    }

    public void Execute()
    {
        if(Ans.text == contra )
        {
            Ans.text = "OK";
            if (TaquillaUI != null)
            {
                TaquillaUI.SetActive(!TaquillaUI.activeSelf);

            }

            
        }
        else
        {
            Ans.text = "ERROR";
            // Inicia la corutina para borrar el texto despu�s de un tiempo
            StartCoroutine(ClearTextAfterDelay());
        }
       
    }

    // Coroutine que borra el texto despu�s de un tiempo
    private IEnumerator ClearTextAfterDelay()
    {
        yield return new WaitForSeconds(resetTime); // Espera un tiempo (2 segundos en este caso)
        Ans.text = ""; // Borra el texto
    }

    // M�todo para cerrar el canvas manualmente (por ejemplo, al pulsar una "X")
    public void OnCloseButtonClicked()
    {
        if (panelToClose != null)
        {
            panelToClose.SetActive(false);
        }
    }

}
