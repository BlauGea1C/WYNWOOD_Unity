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
                // Si el men� est� activo, desactivar y reanudar el juego
                continuar();


            }
            else
            {
                // Si el men� est� desactivado, activar y pausar el juego
                menuPausa.SetActive(true);
            
            }
        }
    }

    public void continuar()
    {

        menuPausa.SetActive(false);
    }
    public void ChangeSceneRestart(int sceneIndex)
    {
       
        SceneManager.LoadScene(sceneIndex);
    }

    public void ChangeSceneExit(int sceneIndex)
    {
      
        SceneManager.LoadScene(sceneIndex);
    }
}
