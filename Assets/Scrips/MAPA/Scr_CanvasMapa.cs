using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_CanvasMapa : MonoBehaviour
{
    public void ChangeScene(int Scene)
    {
        Debug.Log("Cambiando a la escena: " + Scene);
        StartCoroutine(LoadSceneAsync(Scene)); // Usamos una carga asincr�nica
    }

    private IEnumerator LoadSceneAsync(int sceneIndex)
    {
        // Aqu� desactivamos la UI si es necesario
        // Por ejemplo: myCanvas.SetActive(false);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);

        // Espera a que la escena se haya cargado completamente
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Aqu� puedes volver a activar la UI si la desactivaste
        // Por ejemplo: myCanvas.SetActive(true);
    }
}
