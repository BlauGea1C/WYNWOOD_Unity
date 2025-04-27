using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_CanvaPause : MonoBehaviour
{
  
    [SerializeField] private GameObject menuPausa;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (menuPausa.activeSelf)
            {
                // Si el menú está activo, desactivar y reanudar el juego
                menuPausa.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                // Si el menú está desactivado, activar y pausar el juego
                menuPausa.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    public void ChangeSceneRestart(int sceneIndex)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneIndex);
    }

    public void ChangeSceneExit(int sceneIndex)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneIndex);
    }
}
