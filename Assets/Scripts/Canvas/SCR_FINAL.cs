using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_FINAL : MonoBehaviour
{
    public GameObject canvasToActivate;

    public void openCanvas()
    {
        if (canvasToActivate != null)
        {
            canvasToActivate.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
 
}
