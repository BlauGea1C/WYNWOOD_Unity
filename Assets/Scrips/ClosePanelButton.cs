using UnityEngine;

public class ClosePanelButton : MonoBehaviour
{
    public GameObject panelToClose; // El panel o canvas que se va a cerrar

    public void ClosePanel()
    {
        if (panelToClose != null)
        {
            panelToClose.SetActive(false);
        }
    }
}
