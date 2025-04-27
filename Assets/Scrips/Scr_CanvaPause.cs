using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_CanvaPause : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
    public void Pausa()
    {
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
    }
    public void start()
    {
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);

    }

    public void ChangeSceneRestart(int Scene)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(Scene);
    }

    public void ChangeSceneExit(int Scene)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(Scene);
    }
}
