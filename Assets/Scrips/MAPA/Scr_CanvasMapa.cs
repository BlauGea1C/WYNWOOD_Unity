using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_CanvasMapa : MonoBehaviour
{
    public void ChangeScene(int Scene)
    {
        // Guardar inventario antes de cambiar de escena
        List<string> itemIDs = InventoryManager.Instance.SaveInventory();
        // Guardar en alg�n sistema de persistencia (ej., PlayerPrefs, ScriptableObjects, etc.)

        // Cargar la escena
        SceneManager.LoadScene(Scene);
    }
}
