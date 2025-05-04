using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyPad : MonoBehaviour
{
    /*
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
            // Solo agregar el número si la longitud actual es menor a 4
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
                // Inicia la corutina para borrar el texto después de un tiempo
                StartCoroutine(ClearTextAfterDelay());
            }

        }

        // Coroutine que borra el texto después de un tiempo
        private IEnumerator ClearTextAfterDelay()
        {
            yield return new WaitForSeconds(resetTime); // Espera un tiempo (2 segundos en este caso)
            Ans.text = ""; // Borra el texto
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
    [SerializeField] private TextMeshProUGUI Ans;

    private string contra = "6247";
    private float resetTime = 2f;
    public GameObject panelToClose;
    public GameObject TaquillaUI;
    //public bool open = false;
    private KeyPad keyPad;
    public AudioSource audioCerrado;
    void OnEnable()
    {
        Ans.text = "";
     
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Number(int number)
    {
        if (Ans.text.Length < 4)
        {
            Ans.text += number.ToString();
        }
    }

    public void Execute()
    {
        if (Ans.text == contra)
        {
            Ans.text = "OK";

            if (TaquillaUI != null)
            {
                
                TaquillaUI.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }

            if (panelToClose != null)
            {
                panelToClose.SetActive(false);
               
            }
        }
        else
        {
            audioCerrado.Play();
            Ans.text = "ERROR";
            StartCoroutine(ClearTextAfterDelay());
        }
    }

    private IEnumerator ClearTextAfterDelay()
    {
        yield return new WaitForSecondsRealtime(resetTime); // Usamos tiempo real, no afectado por Time.timeScale
        Ans.text = "";
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
