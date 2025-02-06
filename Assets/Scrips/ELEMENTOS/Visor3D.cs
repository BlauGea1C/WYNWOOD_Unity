using UnityEngine;
using UnityEngine.UI;

public class Visor3D : MonoBehaviour
{
    public GameObject camaraVisual; // `CameraVista3D`
    public GameObject camaraJugador; // `Virtual Camera`
    public GameObject objEnEscena; // Objeto en la escena (por ejemplo, el �tem 3D)

    // M�todo para activar el visor 3D
    public void ActivarVisor3D()
    {
        // Liberamos el cursor para que el jugador pueda interactuar con el visor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Desactivamos la c�mara del jugador y activamos la c�mara del visor 3D
        camaraJugador.SetActive(false);
        camaraVisual.SetActive(true);

        // Ocultamos el objeto en la escena
        objEnEscena.SetActive(false);
    }

    // M�todo para desactivar el visor 3D
    public void DesactivarVisor3D()
    {
        // Rehacemos las configuraciones de la c�mara y el cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Volvemos a activar la c�mara del jugador y desactivamos la c�mara del visor 3D
        camaraJugador.SetActive(true);
        camaraVisual.SetActive(false);

        // Mostramos el objeto nuevamente en la escena
        objEnEscena.SetActive(true);
    }

    // Detectar la tecla Q para cerrar el visor
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Llamar a DesactivarVisor3D cuando se presione la tecla Q
            DesactivarVisor3D();
        }
    }
}
